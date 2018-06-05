using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Blah
    {
        public int BlahId { get; set; }
        [MaxLength(50)]
        public string BlahValue { get; set; }
    }
}
