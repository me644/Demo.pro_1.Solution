using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Services.Attachments
{
    public class AttachmentSerivce : IAttachment
    {

        List<string> allowed_Extention = [".png", ".jpg", ".jpeg"];

        const int max_size = 2_097_152;
        
     
        public string? Upload(IFormFile file, string foldername)
        {
            //check extension
            string exe = Path.GetExtension(file.FileName);

            if (!(allowed_Extention.Contains(exe))) return null;

            //chek size
            if(file.Length > max_size||file.Length==0) return null;

            //check_loactedPath

            var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\{foldername}";
           
            //make unique_name
            var fileName=$"{Guid.NewGuid()}_{file.FileName}";
            
            //_______-now i set or loacte to folderPath .ineed to locate file-path inside folderPath_______

            //filePath at this step i set the path the file puut into
            var filePath=$"{Path.Combine(folderPath, fileName)}";

            //Stream to put bytes into path
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);

            //use steam to tranfer bytes from Iform
            file.CopyTo(fileStream);

            return fileName;
        }
        public bool Delete(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                return true;
            }
            return false;   

        
        
        }        }

    }
