using AutoMapper;
using Demo.PLL.EDTO_S;
using Demo.PLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography.Pkcs;


namespace Demo.presentation.Controllers
{
    public class EmployeeController(EmployeeService _Es, IMapper _mapper) : Controller
    {


        public IActionResult Index()
        {

            var Emps = _Es.GetAll();

            return View(Emps);

        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(CreateDto_s CS)
        {




            if (ModelState.IsValid)
            {

                try
                {


                    int result = _Es.Create(CS);
                    if (result > 0)
                    {
                        return Redirect(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "can NOT !!!!");
                    }

                }
                catch (Exception ex)
                {

                    return Content("FROM CATCH");

                }
            }
            return View(CS);
        }



        public IActionResult Details(int? id)
        {


            if (id.HasValue)
            {
                var empl = _Es.GetById(id.Value);
                if (empl is not null)
                {
                    return View(empl);
                }
                else return NotFound();
            }
            return BadRequest();

        }
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {


                var empl = _Es.GetById(id.Value);
                return empl is not null ? View(_mapper.Map<EmpUpdatedDto_s>(empl)) : NotFound();
            }
            return BadRequest();

        }

        [HttpPost]
        public IActionResult Edit( int? id, EmpUpdatedDto_s empl)
        {
            if (id.HasValue && id == empl.id)
            {

                if (ModelState.IsValid)
                {


                    try
                    {
                        if (_Es.Update(empl) > 0)
                        {
                            return Redirect(nameof(Index));
                        }
                        else
                        {
                            ModelState.AddModelError("", "Not allowed");
                        }
                    }


                    catch
                    {

                        return Content("exception");

                    }
                }
                
           
        }

            else { return Content("no id"); }

                return View(empl);

        }


        [HttpPost]
       public IActionResult Delete(int id)
        {

            if (! (id > 0)) { return BadRequest(); }

           
           

                try
                {
                    bool is_del = _Es.Delete(id);


                    if (is_del is false)
                    {
                        return BadRequest();
                    }

                    else
                    {

                        return Redirect(nameof(Index));
                    }
                }


                catch (Exception ex) { 
                    
                return BadRequest(ex.Message);
                }
            }




        


    } } 
