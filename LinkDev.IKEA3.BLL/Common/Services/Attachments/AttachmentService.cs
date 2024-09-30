using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LinkDev.IKEA3.BLL.Common.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        private readonly List<string> _allowedExtensions = new() { ".png", ".jpg", ".jpeg" };
        private const int _allowedSize = 2_097_152;

        public async Task<string?> UploadAsync(IFormFile file, string folderName)
        {
            var extension =  Path.GetExtension(file.FileName);

            if (!_allowedExtensions.Contains(extension))
                return null;

            if (file.Length > _allowedSize)
                return null;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            if (!Directory.Exists(folderPath))
                 Directory.CreateDirectory(folderPath);


            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);

           await file.CopyToAsync(fileStream);

            return fileName;
        }

        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            { 
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
