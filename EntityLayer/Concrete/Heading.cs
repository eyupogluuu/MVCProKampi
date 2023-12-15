using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int headingID { get; set; }
        [StringLength(50)]
        public string headingName { get; set; }
		
		public DateTime headindDate { get; set; }
        public bool headingStatus { get; set; }
        public int categoryID { get; set; }
        public virtual Category category { get; set; }
        public int writerID { get; set; }
        public virtual Writer writer { get; set; }
        public ICollection<Content> contents { get; set; }
    }
}
