

using System.Diagnostics;
using Demo.PLL.DTO_S;
using Demo.PLL.Services;
using Demo.presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Demo.presentation.Controllers
{
    public class DepartemntController(IDepartmentServices _dr, IWebHostEnvironment env) : Controller
    {


        public IActionResult Index()
        {
            var departments = _dr.Get_all();
            return View(departments);
        }



        //public IActionResult Create()
        //{

        //    return View();


        //}


        [HttpPost]
        //public IActionResult Create(Create_Dot_s c)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        try
        //        {


        //            int result = _dr.add(c);
        //            if (result > 0)
        //            {
        //                return Redirect(nameof(Index));
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "can NOT !!!!");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            //if (env.IsDevelopment())
        //            //{
        //            //    logger.LogError("not created bec ", ex);
        //            //}
        //            //else
        //            //{

        //            //    //// {}   not yet
        //            //}
        //        }
        //    }
        //    return View(c);


        //}


        //public IActionResult Edit(int? id)
        //{

        //    if (id == null) return BadRequest();

        //    else
        //    {
        //        var dept = _dr.GetDepartemntRepository_ID(id.Value);

        //        return View(new UpdateDto() { Code = dept.Code, Name = dept.Name });
        //    }

        //}

        [HttpPost]
        public IActionResult Edit(UpdateDto U)
        {
            if (!ModelState.IsValid) return BadRequest();


            else
            {
             
                var result = _dr.Dto_update(U);
            }


            return View(U);
        }
    }
}
