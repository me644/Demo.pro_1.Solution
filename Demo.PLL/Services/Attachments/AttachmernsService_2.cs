using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


//namespace Demo.PLL.Services.Attachments
//{
//    public class AttachmernsService_2 : IAttachment
//    {
    
//        public bool Delete2(string file_name)
//        {
//            if (string.IsNullOrEmpty(file_name))
//            {

//                return false;
//            }
//            var file_Path = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\Images\\{file_name}";
//            if (File.Exists(file_Path)) { File.Delete(file_Path);         return true; }
//        }
       
        
        


//        public List<string> Extentions = [".png", ".jpeg", ".jpg"];

//        const int Size = 20997152;
//        public bool Delete(string filepath)
//        {
//            if (File.Exists(filepath)) { File.Delete(filepath); return true; }
//            return false;
//        }

//        public string Upload(IFormFile file, string foldername)
//        {
//            //Check_Extention
//            var exe = Path.GetExtension(file.FileName);
//            if (!Extentions.Contains(exe))
//            {
//                return null;
//            }

//            //Check Size
//            if (file.Length > Size || file.Length == 0) { return null; }
//            //FolderPath
//            var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{foldername}";
//            if (!Directory.Exists(folderPath)) 
//            {
//                Directory.CreateDirectory(folderPath);
//            }

//            //FileName
//            var FileName = $"{Guid.NewGuid}_{file.FileName}";
//            //FilePath
//            var FilePath = Path.Combine(folderPath, FileName);

//            //Streaming
//            var Fs = new FileStream(FilePath, FileMode.Create);

//            //Copy into file
//            file.CopyTo(Fs);
//            //Retrun
//            return FileName;

//        }
//    }
//}
