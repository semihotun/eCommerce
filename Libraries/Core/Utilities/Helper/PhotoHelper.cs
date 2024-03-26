using Core.Utilities.Helper.Models;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
namespace Core.Utilities.Helper
{
    public static class PhotoHelper
    {
        public static Result<PhotoHelperModel> Add(string path, IFormFile file)
        {
            var uploadsFolder = Directory.GetCurrentDirectory() + "\\wwwroot" + path;
            var mimeType = System.IO.Path.GetExtension(file.FileName).ToLower();
            var uniqueFileName = Guid.NewGuid().ToString() + mimeType;
            var filepath = uploadsFolder + uniqueFileName;
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            var photoModel = new PhotoHelperModel
            {
                Path = path + uniqueFileName
            };
            return Result.SuccessDataResult(photoModel);
        }
        public static Result<PhotoHelperModel> Add(string path, IFormFile file, bool deleted = false, string deletePhotoUrl = null)
        {
            var uploadsFolder = Directory.GetCurrentDirectory() + "\\wwwroot" + path;
            var mimeType = System.IO.Path.GetExtension(file.FileName).ToLower();
            var uniqueFileName = Guid.NewGuid().ToString() + mimeType;
            var filepath = uploadsFolder + uniqueFileName;
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            var photoModel = new PhotoHelperModel
            {
                Path = path + uniqueFileName
            };
            if (deleted && deletePhotoUrl != null)
                Delete(deletePhotoUrl);
            return Result.SuccessDataResult(photoModel);
        }
        public static Result Delete(string photoUrl)
        {
            System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\" + photoUrl);
            return Result.SuccessResult();
        }
    }
}
