using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessegaServis
	{
		List<Message> GetMessageInbox(string p);
		List<Message> GetMessageSendbox(string p);
		Message GetMessage(int id);
		void AddMessage(Message message);
		void UpdateMessage(Message message);
		void DeleteMessage(Message message);
	}
}
