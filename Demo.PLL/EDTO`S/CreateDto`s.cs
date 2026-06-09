 using Demo.DAL.Emp_Module;
using Demo.DAL.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.EDTO_S
{
    public class CreateDto_s
    {

    
        [Required(ErrorMessage="Name is required")]
        [MaxLength(length:15,ErrorMessage ="max should be 15")]
        [MinLength(length: 5, ErrorMessage = "min should be 4")]

        public string Name { get; set; }

        [Range(22,37)]
        public int Age { get; set; }
        [RegularExpression(@"^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",ErrorMessage ="not match")]
        public string? Address { get; set; }



        [Display(Name="Is active")]
        public bool Is_Active { get; set; }


        [EmailAddress]
        public string? Email { get; set; }

   
        public string? Phone_NUMBER { get; set; }
    


        public Employe_Type Type { get; set; }

        public Gender gender { get; set; }

        public int ?Department_ID { get; set; }


        public  IFormFile? Image { get; set; }
    }
}
