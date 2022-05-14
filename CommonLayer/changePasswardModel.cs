using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class changePasswardModel
    {
        [Required]
        public string Passward { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string conformpassward { get; set; }
    }
}
