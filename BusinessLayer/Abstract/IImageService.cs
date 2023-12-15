using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IImageService
	{
		List<Image> GetImages();
		Image GetImage(int id);
		void ImageAdd(Image image);
		void ImageDelete(Image image);
		void ImageUpdate(Image image);
	}
}
