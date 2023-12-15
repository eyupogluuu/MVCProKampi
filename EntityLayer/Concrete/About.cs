﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int aboutID { get; set; }
        [StringLength(1000)]
        public string aboutDetails { get; set; }
        [StringLength(1000)]
        public string aboutDetails2 { get; set; }
        [StringLength(200)]
        public string aboutImage { get; set; }
        [StringLength(200)]
        public string aboutImage2 { get; set; }
    }
}
