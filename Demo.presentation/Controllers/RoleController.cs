using Demo.DAL.Shared;
using Demo.presentation.VIEW_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.presentation.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager) : Controller
    {

        public IActionResult Index(string searchvalue)
        {


            var userQuerys = _roleManager.Roles.AsQueryable();
            if (!string.IsNullOrEmpty(searchvalue))
            {
                userQuerys = userQuerys.Where(u => u.Name.ToLower().Contains(searchvalue.ToLower()));
            }
            var roles = userQuerys.Select(u => new RoleViewModel() { Id = u.Id, Name = u.Name }).ToList();

            return View(roles);
        }




        public IActionResult Detalis(string? id)
        {
            if (id == null) { return BadRequest(); }

            var role = _roleManager.FindByIdAsync(id).Result;
            if (role is null) { return BadRequest(); }
            return View(new RoleViewModel() { Id = role.Id, Name = role.Name });

        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {

            if (id is null) { return BadRequest(); }

            var role = _roleManager.FindByIdAsync(id).Result;
            if (role is null) return BadRequest();

            var users = _userManager.Users.ToList();

            return View(new RoleViewModel()
            {
                Id = id,

                Name = role.Name,
                Users = users.Select(user => new UserRoleViewModelcs()
                {
                    Id = user.Id,
                    UserName = user.UserName,

                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result

                }).ToList()


            });

        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel roleViewModel)
        {



            if (!ModelState.IsValid) { return View(roleViewModel); }
           // if (roleViewModel.Id != id) { return BadRequest(); }
            string message = "";
            try
            {

                var role = await _roleManager.FindByIdAsync(roleViewModel.Id);
                if (role is null) { return BadRequest(); }


                

                role.Name = roleViewModel.Name;
                var result = _roleManager.UpdateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "can not be added";
                }

                foreach (var userrole in roleViewModel.Users)
                {

                    var user=_userManager.FindByIdAsync(userrole.Id).Result;
                    if (userrole is null) { return BadRequest(); }

                    if (userrole.IsSelected && !(_userManager.IsInRoleAsync(user, role.Name)).Result)
                    {

                     await   _userManager.AddToRoleAsync(user, role.Name);

                    }
                    else if (!userrole.IsSelected && (await _userManager.IsInRoleAsync(user, role.Name))) { 
                    await _userManager.RemoveFromRoleAsync(user,role.Name);
                    }
                        

                }
        

            }
            catch (Exception e)
            {
                message = e.Message;
            }

            ModelState.AddModelError(string.Empty, message);
            return View(roleViewModel);
        }


        public IActionResult Delete(string id)
        {

            var role = _roleManager.FindByIdAsync(id).Result;
            if (role is null) { return BadRequest(); }
            string message = "";



            try
            {
                var RESULT = _roleManager.DeleteAsync(role).Result;
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

        [HttpGet]
        public IActionResult Create()
        {


            return View();

        }

        [HttpPost]
        public IActionResult Create(RoleViewModel roleView)
        {

            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _roleManager.CreateAsync(new IdentityRole() { Name = roleView.Name }).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else { message = "not allowed to create"; }

                }

                catch (Exception e)
                {
                    message = e.Message;
                }


            }

            ModelState.AddModelError(string.Empty, message);
            return View(roleView);


        }
      



    }
}
    


   

