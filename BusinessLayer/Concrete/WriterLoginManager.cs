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
	public class WriterLoginManager : IwriterLoginService
	{
		IWriterDal _writerDal;

		public WriterLoginManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public Writer getWriter(string username, string password)
		{
			return _writerDal.Get(x=>x.writerMail==username && x.WriterPassword==password);
		}
	}
}
