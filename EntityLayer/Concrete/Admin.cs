﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Admin
	{
        [Key]
        public int adminID { get; set; }
        [StringLength(20)]
        public string adminUsername { get; set; }
		[StringLength(10)]
		public string password { get; set; }
		[StringLength(1)]
		public string role { get; set; }
    }
}
