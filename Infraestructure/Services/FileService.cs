using Domain.Interfaces;
using Infraestructure.Persistence.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class FileService : IFileService
    {
        private readonly IHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var fileName = Path.GetFileName(file.FileName);
            var fileExtension = Path.GetExtension(fileName);
            //var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            // Genera un nombre de archivo único con un DateTime en el nombre para evitar conflictos y que sea unico
            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

            var mediaFolderPath = Path.Combine(_env.ContentRootPath, "Media");
            var filePath = Path.Combine(mediaFolderPath, uniqueFileName);

            // Verificar si la ruta "Media" existe, y si no, crearla
            if (!Directory.Exists(mediaFolderPath))
            {
                Directory.CreateDirectory(mediaFolderPath);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
    }
}
