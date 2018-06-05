using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DAL.Identity.Interfaces;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Identity
{

    

    public class RoleStore<TKey, TUser, TRole, TUserRole, TRoleClaim, TUOW > : IRoleClaimStore<TRole>
        where TKey : IEquatable<TKey>
        where TUser: IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TUserRole : IdentityUserRole<TKey>, new()
        where TRoleClaim : IdentityRoleClaim<TKey>, new()
        where TUOW : IIdentityUnitOfWork<TKey, TUser, TRole>
    {
        private bool _disposed;
        private readonly TUOW _uow;
        /// <summary>
        /// Gets or sets the <see cref="IdentityErrorDescriber"/> for any error that occurred with the current operation.
        /// </summary>
        public IdentityErrorDescriber ErrorDescriber { get; set; }

        public RoleStore(TUOW uow, IdentityErrorDescriber describer)
        {
            _uow = uow;
            ErrorDescriber = describer ?? throw new ArgumentNullException(nameof(describer));
        }


        public virtual async Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(paramName: nameof(role));
            }
            _uow.IdentityRoleRepository.Add(role);
            await _uow.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public virtual async Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            role.ConcurrencyStamp = Guid.NewGuid().ToString();
            _uow.IdentityRoleRepository.Update(role);
            try
            {
                await _uow.SaveChangesAsync(cancellationToken: cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return IdentityResult.Failed(ErrorDescriber.ConcurrencyFailure());
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError() { Code = ex.GetType().Name, Description = ex.Message });
            }
            return IdentityResult.Success;
            throw new NotImplementedException();
        }

        public virtual async Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(paramName: nameof(role));
            }
            _uow.IdentityRoleRepository.Remove(role);
            try
            {
                await _uow.SaveChangesAsync(cancellationToken: cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return IdentityResult.Failed(ErrorDescriber.ConcurrencyFailure());
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError() { Code = ex.GetType().Name, Description = ex.Message });
            }
            return IdentityResult.Success;
        }

        
        public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return Task.FromResult(ConvertIdToString(role.IdentityRoleId));
        }

        public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public virtual Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            var id = ConvertIdFromString(id: roleId);
            return _uow.IdentityRoleRepository.FindAsync(id, cancellationToken);
        }

        public Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return _uow.IdentityRoleRepository.FindByNameAsync(normalizedRoleName, cancellationToken);
        }


        public Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(paramName: nameof(role));
            }
            return _uow.IdentityRoleClaimRepository.GetClaimsAsync(role.IdentityRoleId, cancellationToken);
        }

        public Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(paramName: nameof(role));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(paramName: nameof(claim));
            }
            _uow.IdentityRoleClaimRepository.Add(CreateRoleClaim(role: role, claim: claim));
            return Task.FromResult(result: false);
        }

        public Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(paramName: nameof(role));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(paramName: nameof(claim));
            }

            _uow.IdentityRoleClaimRepository.RemoveClaimAsync(role.IdentityRoleId, claim, cancellationToken);
            throw new NotImplementedException();
        }


        /// <summary>
        /// Creates a entity representing a role claim.
        /// </summary>
        /// <param name="role">The associated role.</param>
        /// <param name="claim">The associated claim.</param>
        /// <returns>The role claim entity.</returns>
        protected virtual TRoleClaim CreateRoleClaim(TRole role, Claim claim)
            => new TRoleClaim { IdentityRoleId = role.IdentityRoleId, ClaimType = claim.Type, ClaimValue = claim.Value };


        /// <summary>
        /// Converts the provided <paramref name="id"/> to a strongly typed key object.
        /// </summary>
        /// <param name="id">The id to convert.</param>
        /// <returns>An instance of <typeparamref name="TKey"/> representing the provided <paramref name="id"/>.</returns>
        public virtual TKey ConvertIdFromString(string id)
        {
            if (id == null)
            {
                return default(TKey);
            }
            return (TKey)TypeDescriptor.GetConverter(typeof(TKey)).ConvertFromInvariantString(id);
        }

        /// <summary>
        /// Converts the provided <paramref name="id"/> to its string representation.
        /// </summary>
        /// <param name="id">The id to convert.</param>
        /// <returns>An <see cref="string"/> representation of the provided <paramref name="id"/>.</returns>
        public virtual string ConvertIdToString(TKey id)
        {
            if (id.Equals(default(TKey)))
            {
                return null;
            }
            return id.ToString();
        }

        /// <summary>
        /// Throws if this class has been disposed.
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        /// <summary>
        /// Dispose the stores
        /// </summary>
        public void Dispose() => _disposed = true;

    }
}
