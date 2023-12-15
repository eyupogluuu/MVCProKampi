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
	public class HeadingManager : IHeadingService
	{
		IHeadingDal _headingDal;

		public HeadingManager(IHeadingDal headingDal)
		{
			_headingDal = headingDal;
		}

		public List<Heading> GetHeaadingList()
		{
			return _headingDal.List();
		}

		public List<Heading> GetHeaadingListByWriter(int id)
		{
			return _headingDal.FList(x => x.writerID == id);
		}

		public Heading GetHeading(int id)
		{
			return _headingDal.Get(x=>x.headingID== id);
		}

		public void HeadingAdd(Heading heading)
		{
			_headingDal.Insert(heading);
		}

		public void HeadingRemove(Heading heading)
		{
			
			_headingDal.Delete(heading);
		}

		public void HeadingUpdate(Heading heading)
		{
			_headingDal.Update(heading);
		}
	}
}
