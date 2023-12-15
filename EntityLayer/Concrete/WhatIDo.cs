using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class WhatIDo
	{
		[Key]
        public int whatIDoID { get; set; }
        public string tittle { get; set; }
        public string descreption { get; set; }
    }
}
