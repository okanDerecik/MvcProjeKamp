using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDAL _imagefileDal;

        public ImageFileManager(IImageFileDAL imagefileDal)
        {
            _imagefileDal = imagefileDal;
        }

        public List<ImageFile> GetList()
        {
            return _imagefileDal.List();
            
        }
    }
}
