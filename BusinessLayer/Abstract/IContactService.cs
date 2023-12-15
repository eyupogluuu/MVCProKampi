using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IContactService
	{
		List<Contact> GetContactList();
		Contact GetByID(int id);
		void DeleteContact(Contact contact);
		void AddContact(Contact contact);
		void UpdateContact(Contact contact);
	}
}
