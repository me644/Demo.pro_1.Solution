using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Services.Attachments
{
    public interface IAttachment
    {

        public string Upload(IFormFile file, string foldername);

        public bool Delete(string filepath);


    }
}
