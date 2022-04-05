using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Utilities.Constants;

namespace Core.Utilities.Helper
{
    public class PhotoHelper
    {

    

        public class PhotoHelperModel
        {
            public string Path { get; set; }
        }
        public IDataResult<PhotoHelperModel> Add(string path, IFormFile file)
        {
            try
            {
                var uploadsFolder = Directory.GetCurrentDirectory()+"\\wwwroot"+path;
                var mimeType = System.IO.Path.GetExtension(file.FileName).ToLower();
                var uniqueFileName = Guid.NewGuid().ToString()+ mimeType; 
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
                var uploadsFolder = Directory.GetCurrentDirectory() + "\\wwwroot" + path;
                var mimeType = System.IO.Path.GetExtension(file.FileName).ToLower();
                var uniqueFileName = Guid.NewGuid().ToString() + mimeType;
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
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\"+ photoUrl);
                return new SuccessResult();
            }
            catch(Exception ex)
            {
                return new ErrorResult(ex.ToString());
            }

        }
    }
}
