using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIMS_Demo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIMS_Demo.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public IActionResult Login(User user)
        {
            List<User>? users = ReadFileToUserList("User.json");
            var result =
                users.FirstOrDefault(u => u.UserName == user.UserName && u.PassWord == user.PassWord);
            if (result != null)
            {
                //   HttpContext.Session.SetString("UserName", result.UserName);
                //  HttpContext.Session.SetString("Role", result.Role);
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                ViewBag.error = "Invalid user";
                return View();
            }

        }

        public List<User>? ReadFileToUserList(String filePath)
        {
            // Read a file 
            string readText = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(readText);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        // Register

        [HttpPost]
        public IActionResult Register(User user)
        {
            List<User>? users = ReadFileToUserList("User.json");
            var result =
                users.FirstOrDefault(u => u.UserName == user.UserName);
            if (result != null)
            {
            
                ViewBag.error = "User existed";
                return View();
            }
            else
            {
                User data = new User(0,user.UserName,user.PassWord,"Admin");
                List<User> usersData = new List<User>();
                usersData.Add(data);
                WriteUserToFile(usersData);
                return RedirectToAction("Login", "Authentication");

            }



        }
        private static string filePath = "User.json";
        public static void WriteUserToFile(List<User> user)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(user, options);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(jsonString);
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


    }
}
