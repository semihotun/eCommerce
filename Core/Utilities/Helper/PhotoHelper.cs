using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Utilities.Constants;

namespace Core.Utilities.Helper
{
    public class PhotoHelper
    {
        private IHostingEnvironment _hostingenvironment;
        public PhotoHelper(IHostingEnvironment hostingEnvironment)
        {
            this._hostingenvironment = hostingEnvironment;
        }
        public class PhotoHelperModel
        {
            public string Path { get; set; }
        }
        public IDataResult<PhotoHelperModel> Add(string path, IFormFile file)
        {
            try
            {
                var uniqueFileName = "";
                var uploadsFolder = _hostingenvironment.WebRootPath + path;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filepath = uploadsFolder + uniqueFileName;
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var photoModel = new PhotoHelperModel();
                photoModel.Path = path + uniqueFileName;

                return new SuccessDataResult<PhotoHelperModel>(photoModel);
            }
            catch(Exception ex)
            {
                return new ErrorDataResult<PhotoHelperModel>(ex.ToString());
            }
        }
        public IDataResult<PhotoHelperModel> Add(string path, IFormFile file, bool deleted = false, string deletePhotoUrl = null)
        {
            try
            {
                var uniqueFileName = "";
                var uploadsFolder = _hostingenvironment.WebRootPath + path;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filepath = uploadsFolder + uniqueFileName;
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var photoModel = new PhotoHelperModel();
                photoModel.Path = path + uniqueFileName;

                if (deleted == true && deletePhotoUrl != null)
                    Delete(deletePhotoUrl);

                return new SuccessDataResult<PhotoHelperModel>(photoModel);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PhotoHelperModel>(ex.ToString());
            }
        }

        public IResult Delete(string photoUrl)
        {
            try
            {
                System.IO.File.Delete(photoUrl);
                return new SuccessResult();
            }
            catch(Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }

        }
    }
}
