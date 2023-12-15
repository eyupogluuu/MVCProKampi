using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Tool
	{
        [Key]
        public int toolID { get; set; }
        public string toolName { get; set; }
        public int toolRating { get; set; }
    }
}
