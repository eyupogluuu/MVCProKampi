using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IHeadingService
	{
		List<Heading> GetHeaadingList();
		List<Heading> GetHeaadingListByWriter(int id);
		Heading GetHeading(int id);
		void HeadingAdd(Heading heading);
		void HeadingRemove(Heading heading);
		void HeadingUpdate(Heading heading);
	}
}
