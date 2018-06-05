using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class FooBar
    {
        public int FooBarId { get; set; }
        [MaxLength(50)]
        public string FooBarValue { get; set; }
    }
}
