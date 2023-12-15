using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Message
	{
        [Key]
        public int messageID { get; set; }
        [StringLength(50)]
        
        public string senderMail { get; set; }
		[StringLength(50)]
		public string receiverMail { get; set; }
		[StringLength(150)]
		public string subject { get; set; }
        public string messageContent { get; set; }
        public DateTime messageDate { get; set; }
        public bool isDraft { get; set; }
        public bool IsRead { get; set; }

    }
}
