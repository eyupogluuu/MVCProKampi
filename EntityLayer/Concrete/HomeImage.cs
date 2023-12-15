using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class HomeImage
	{
		[Key]
        public int himageID { get; set; }
        public string tittle { get; set; }
        public string imageUrl { get; set; }
    }
}
