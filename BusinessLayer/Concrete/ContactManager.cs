using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ContactManager : IContactService
	{
		IContactDal contactDal;

		public ContactManager(IContactDal contactDal)
		{
			this.contactDal = contactDal;
		}

		public void AddContact(Contact contact)
		{
			contactDal.Insert(contact);
		}

		public void DeleteContact(Contact contact)
		{
			contactDal.Delete(contact);
		}

		public Contact GetByID(int id)
		{
			return contactDal.Get(x => x.contactID == id);
		}

		public List<Contact> GetContactList()
		{
			return contactDal.List();
		}

		public void UpdateContact(Contact contact)
		{
			contactDal.Update(contact);
		}
	}
}
