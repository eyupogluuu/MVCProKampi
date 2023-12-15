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
	public class ImageManager : IImageService
	{
		IImageDal _imageDal;

		public ImageManager(IImageDal imageDal)
		{
			_imageDal = imageDal;
		}

		public Image GetImage(int id)
		{
			return _imageDal.Get(x=>x.imageID == id);
		}

		public List<Image> GetImages()
		{
			return _imageDal.List();
		}

		public void ImageAdd(Image image)
		{
			 _imageDal.Insert(image);
		}

		public void ImageDelete(Image image)
		{
			_imageDal.Insert(image);
		}

		public void ImageUpdate(Image image)
		{
			_imageDal.Insert(image);
		}
	}
}
