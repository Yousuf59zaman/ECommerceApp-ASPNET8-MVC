using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ECommerceApp.ViewModels;
using ECommerceApp.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // Add this namespace
using System.Threading.Tasks;

namespace ECommerceApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger; // Add logger

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger; // Initialize logger
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Login attempt for email: {Email}", model.Email);

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in successfully with email: {Email}", model.Email);
                    return RedirectToAction("Index", "Home");
                }

                _logger.LogWarning("Invalid login attempt for email: {Email}", model.Email);
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            else
            {
                _logger.LogWarning("ModelState is invalid during login attempt for email: {Email}", model.Email);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Log start of registration process
                _logger.LogInformation("Registering new user with email: {Email}", model.Email);

                // Check if the user already exists
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    _logger.LogWarning("Registration attempt with existing email: {Email}", model.Email);
                    ModelState.AddModelError(string.Empty, "A user with this email address already exists.");
                    return View(model);
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    Age = model.Age,
                    Gender = model.Gender,
                    Address = model.Address,
                    Name = model.Name
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created successfully with email: {Email}", model.Email);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogError("Error occurred while creating user: {ErrorDescription}", error.Description);
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                // Log validation failure
                _logger.LogWarning("ModelState is invalid during registration attempt for email: {Email}", model.Email);
            }

            return View(model);
        }
    }
}
