using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int contentID { get; set; }
        [StringLength(1000)]
        public string contentText { get; set; }
        public DateTime contentDate { get; set; }
        public bool contentStatus { get; set; }
        public int headingID { get; set; }//baslik
        public virtual Heading heading { get; set; }//baslik
       public int? writerID { get; set; }//yazar
        public virtual Writer writer { get; set; }//yazar
    }
}
