using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class HomeCommunication
	{
		[Key]
        public int communucationID { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string adresinfo { get; set; }
    }
}
