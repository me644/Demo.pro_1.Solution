using AutoMapper;
using Demo.DAL.Emp_Module;
using Demo.DAL.Shared;
using Demo.PLL.DDTO_S;
using Demo.PLL.EDTO_S;
using Demo.PLL.Services;
using Demo.presentation.VIEW_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography.Pkcs;


namespace Demo.presentation.Controllers
{

    [Authorize]
    public class EmployeeController(EmployeeService _Es ,IMapper _mapper) : Controller
    {


        public IActionResult Index()
        {



            //ViewData["id"] = "hello from v_data";
            //ViewBag.bag = "hello from bag";



            ViewData["Message"] = new EmpDto_s() { Name = "Test" };
            var Emps = _Es.GetAll();
            return View(Emps);

        }


        [HttpGet]
        public IActionResult Create([FromServices]DepartmentServices _DS)
        {

            ViewData["Dept"] = _DS.Get_all();
            return View();

        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeView)
        {




            if (ModelState.IsValid)
            {

                try
                {


                       
                    int result = _Es.Create(new CreateDto_s()
                    {


                        Name = employeeView.Name,
                        Address = employeeView.Address,
                        Age = employeeView.Age,
                        Email = employeeView.Email,
                        gender = employeeView.gender,
                        Is_Active = employeeView.Is_Active,
                        Phone_NUMBER = employeeView.Phone_NUMBER,
                        Type = employeeView.Type,
                        Department_ID = employeeView.Department_ID,

                        Image = employeeView.Image


                    });
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
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

            else { return Content("not equal 4"); }
                return View(employeeView);
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


                var employeeView = _Es.GetById(id.Value);

                return View(new EmployeeViewModel()
                {
                  
                    Name = employeeView.Name,
                    Address = employeeView.Address,
                    Age = employeeView.Age,
                    Email = employeeView.Email,
                    gender = (Gender)Enum.Parse(typeof(Gender), employeeView.gender),
                    Is_Active = employeeView.Is_Active,
                    Phone_NUMBER = employeeView.Phone_NUMBER,
                    Type = (Employe_Type)Enum.Parse(typeof(Employe_Type), employeeView.Type),
                   id = employeeView.id



                });
               // return empl is not null ? View(_mapper.Map<EmpUpdatedDto_s>(empl)) : NotFound();
            }
            return BadRequest();

        }

        [HttpPost]
        public IActionResult Edit( [FromRoute]int? id, EmployeeViewModel employeeView)
        {
            if (id.HasValue && id == employeeView.Department_ID)
            {

                if (ModelState.IsValid)
                {


                    try
                    {
                        if (_Es.Update(new EmpUpdatedDto_s()
                        {

                            Name = employeeView.Name,
                            Address = employeeView.Address,
                            Age = employeeView.Age,
                            Email = employeeView.Email,
                            gender = employeeView.gender,
                            Is_Active = employeeView.Is_Active,
                            Phone_NUMBER = employeeView.Phone_NUMBER,
                            Type = employeeView.Type

                        }) > 0)
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




                else { return Content("no id"); }

            }     return View(employeeView);

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
