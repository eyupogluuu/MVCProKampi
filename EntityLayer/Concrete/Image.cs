using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Image
	{
        [Key]
        public int imageID { get; set; }
        [StringLength(50)]
        public string imageName { get; set; }
        [StringLength(350)]
        public string imagePath { get; set; }
    }
}
