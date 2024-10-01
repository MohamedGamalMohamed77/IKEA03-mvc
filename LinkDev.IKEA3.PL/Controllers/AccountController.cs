using LinkDev.IKEA3.DAL.Models.Identities;
using LinkDev.IKEA3.PL.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA3.PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager
			, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}


		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{

			if (!ModelState.IsValid)
				return BadRequest();
			var user = await _userManager.FindByNameAsync(model.UserName);

			if (user is null)
			{
				ModelState.AddModelError(nameof(SignUpViewModel.UserName), "the UserName is already present");
				return View(model);
			}

			user = new ApplicationUser
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserName = model.UserName,
				Email = model.Email,
				IsAgree = model.IsAgree,

			};
			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
				return RedirectToAction(nameof(SignIn));

			foreach (var error in result.Errors)
				ModelState.AddModelError(string.Empty, error.Description);

			return View(model);
		}

		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{

			if (!ModelState.IsValid)
				return BadRequest();
			
			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user is { })
			{
				var flag = await _userManager.CheckPasswordAsync(user,model.Password);

				if (flag)
				{ 
				var result = await _signInManager.PasswordSignInAsync(user, model.Password,model.RememberMe,true);
					
					if (result.IsNotAllowed)
						ModelState.AddModelError(string.Empty,"Your account isn't confirmed yet");
					if (result.IsLockedOut)
						ModelState.AddModelError(string.Empty, "Your account is Locked");
					if (result.Succeeded)
						return RedirectToAction(nameof(HomeController),"Home");
				}
			}
			
			else
				ModelState.AddModelError(string.Empty, "Invalid Login attempt");
				
			

			return View(model);
		}

	}
}
