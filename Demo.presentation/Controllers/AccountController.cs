using Demo.DAL.Shared;
using Demo.PLL.Services;
using Demo.presentation.VIEW_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo.presentation.Controllers
{
    public class AccountController(EmailSettings _emailSettings    ,UserManager<ApplicationUser>_usermanger,SignInManager<ApplicationUser>_signInManager):Controller
    {

        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerView)
        {

            if (!ModelState.IsValid)
            {
                return View(registerView);
            }



            var  result=    _usermanger.CreateAsync(new ApplicationUser() { 
                    UserName = registerView.UserName,
                    LastName = registerView.LastName,
                    FirstName = registerView.FirstName,
                    Email = registerView.Email
                }
                , password: registerView.Password).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                else
                {

                    foreach (IdentityError error in result.Errors)
                    {

                        ModelState.AddModelError(string.Empty, error.Description);

                       

                    }
                return View(registerView);
            }
           

        }


        [HttpGet]
        public IActionResult Login()
        {


            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid)
            {
                return View(loginView);
            }
            else
            {
                var user = _usermanger.FindByEmailAsync(loginView.Email).Result;
                if (user is not null)
                {
                    var flag = _usermanger.CheckPasswordAsync(user, loginView.Password).Result;

                    if (flag)
                    {
                        var result = _signInManager.PasswordSignInAsync(user, loginView.Password, loginView.RememberMe, false).Result;

                        if (result.IsNotAllowed)
                        {

                            ModelState.AddModelError(string.Empty, "your account not aloowed");


                        }
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError(string.Empty, "your account not locked");

                        }
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "InValidLogIn");
                return View(loginView);

            }
        }

            [HttpGet]
            
           public  new IActionResult SignOut()
        {
                _signInManager.SignOutAsync().GetAwaiter().GetResult();
                return RedirectToAction("Login");
        }




        [HttpGet]
         public IActionResult ForgetPassword()
        {

            return View();
        }



        [HttpPost]
        public IActionResult SendResetPassURL(ForgetViewModel  forgetView)
        {
            if (ModelState.IsValid) {


                var USER = _usermanger.FindByEmailAsync(forgetView.Email).Result;

              
                if(USER is not null)
                {
                    var tooken = _usermanger.GeneratePasswordResetTokenAsync  (USER).Result;
                    //Requst schema  mean https  or https the domain is put automatic
                    var url = Url.Action("ResetPassword", "Account", new {Email=forgetView.Email, tooken=tooken},Request.Scheme);
                    var email = new Email()
                    {



                        to = forgetView.Email,
                        subject = "Reset Your Password",
                        body = url


                    };

                    _emailSettings.Send_Email(email);
                    return RedirectToAction("CheckBox");
                }
                else
                {

                    ModelState.AddModelError(string.Empty, " this email invalid");
                }

              
            }

            return View(forgetView);

        }


        [HttpGet]
        public IActionResult CheckBox()
        {

            return View();
        }




        [HttpGet]
      public IActionResult ResetPassword(string Email, string tooken)
        {
            TempData["email"] = Email;//tep only if you make refersh will lose so not sent to [post]
            TempData["tooken"] = tooken;
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (ModelState.IsValid)
            {
                var email=TempData["email"].ToString();
                var tooken= TempData["tooken"].ToString();
                var user = _usermanger.FindByEmailAsync(email).Result;
                if(user is not null)
                {
                    var result = _usermanger.ResetPasswordAsync(user, tooken, resetPassword.Password).Result;
                    if (result.Succeeded) {

                        return RedirectToAction("Login");
                    }
                    

                }



            }
            ModelState.AddModelError(string.Empty, "invalid operation");
            return View(resetPassword);

        }

        }

    }

