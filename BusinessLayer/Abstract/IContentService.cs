using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IContentService
	{
		List<Content> GetContentList(string p);
		List<Content> GetContentByHeadingId(int id);
		List<Content> GetContentByWriter(int id);
		Content GetByID(int id);
		void ContentAdd(Content content);
		void ContentDelete(Content content);
		void ContentUpdate(Content content);
		
	}
}
