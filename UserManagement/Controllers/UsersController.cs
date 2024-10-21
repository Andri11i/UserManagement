using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class UsersController : Controller
    {

        private static List<User> Users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "123-456-7890" },
            new User { Id = 2, Name = "muehehehe", Email = "123@example.com", Phone = "mmmmmmmmmmmmhhhmmm" }
        };

      
        public IActionResult Index()
        {
            return View(Users);
        }


        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Users.Max(u => u.Id) + 1;
                Users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        public IActionResult Delete(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Users.Remove(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
