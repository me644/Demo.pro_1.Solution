using Demo.DAL.Shared;
using Demo.presentation.VIEW_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.Identity.Client;
using System.Data;

namespace Demo.presentation.Controllers
{
    public class UserController(UserManager<ApplicationUser> _userManager) : Controller
    {
        public IActionResult Index(string searchvalue)
        {

            var userQuerys = _userManager.Users.AsQueryable();
            if (!string.IsNullOrEmpty(searchvalue))
            {
                userQuerys.Where(u => u.Email.ToLower().Contains(searchvalue.ToLower()));
            }
            var users = userQuerys.Select(s => new UserViewModel() { Id = s.Id, Email = s.Email, FirstName = s.FirstName, LastName = s.LastName }).ToList();
            foreach (var user in users)
            {

                user.Roles = _userManager.GetRolesAsync(_userManager.FindByIdAsync(user.Id).Result).Result;
            }
            return View(users);



        }

        public IActionResult Details(string? id)
        {
            if (id == null) { return BadRequest(); }

            var User = _userManager.FindByIdAsync(id).Result;

            if (User is null)
            {
                return BadRequest();
            }
            return View(new UserViewModel
            {

                Id = id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Roles = _userManager.GetRolesAsync(User).Result

            });

        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id is null) { return BadRequest(); }

            var USER = _userManager.FindByIdAsync(id).Result;
            if (USER is null) return BadRequest();
            return View(new UserViewModel()
            {
                Id = id,
                Email=USER.Email,
                FirstName = USER.FirstName,
                LastName = USER.LastName,
                Roles = _userManager.GetRolesAsync(USER).Result
            });
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel, [FromRoute]string id)
        {

            if (!ModelState.IsValid) { return View(userViewModel); }
            if (userViewModel.Id != id) { return BadRequest(); }
            string message = "";
            try {

                var User = _userManager.FindByIdAsync(id).Result;
                if(User is null) { return BadRequest(); }

                User.FirstName = userViewModel.FirstName;
                User.LastName = userViewModel.LastName;
                User.Email = userViewModel.Email;



                var result = _userManager.UpdateAsync(User).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "can not be added";
                }

            }
            catch(Exception e)
            {
                message=e.Message;
            }

            ModelState.AddModelError(string.Empty, message);
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {

            var user = _userManager.FindByIdAsync(id).Result;
            if (user is null) { return BadRequest(); }
            string message = "";

 

            try
            {
                var RESULT = _userManager.DeleteAsync(user).Result;
                if (RESULT.Succeeded)
                {
                    return RedirectToAction(nameof(Index)); 
                }
                else { message = "User can not delted"; }
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return RedirectToAction(nameof(Index));

        }





































    }

}


