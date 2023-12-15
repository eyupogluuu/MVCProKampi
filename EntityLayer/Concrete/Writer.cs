﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int writerID { get; set; }
        [StringLength(50)]
        public string writerName { get; set; }
		[StringLength(50)]
		public string writerTittle { get; set; }
		[StringLength(50)]
        public string writerSurname { get; set; }
        [StringLength(150)]
        public string writerImage { get; set; }
        [StringLength(250)]
        public string writerMail { get; set; }
		[StringLength(150)]
		public string writerAbout { get; set; }
        [StringLength(220)]
        public string WriterPassword { get; set; }
        public bool writerStatus { get; set; }
        public ICollection<Heading> headings { get; set; }
        public ICollection<Content> contents { get; set; }

    }
}
