using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MessageManager : IMessegaServis
	{
		IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void AddMessage(Message message)
		{
			_messageDal.Insert(message);
		}

		public void DeleteMessage(Message message)
		{
			_messageDal.Delete(message);
		}

		public Message GetMessage(int id)
		{
			return _messageDal.Get(x=>x.messageID==id);
		}

		public List<Message> GetMessageInbox(string p)
		{
			return _messageDal.FList(x => x.receiverMail == p );//mesajı alan kişinin maili
		}

		

		public List<Message> GetMessageSendbox(string p)
		{
			return _messageDal.FList(x => x.senderMail == p );// mesajı gönderen kişinin maili
		}

		public void UpdateMessage(Message message)
		{
			_messageDal.Update(message);
		}
	}
}
