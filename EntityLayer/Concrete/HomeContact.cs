using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class HomeContact
	{
        [Key]
        public int contactID { get; set; }
        public string nameSurname { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string messagetext { get; set; }
    }
}
