using Microsoft.AspNetCore.Mvc;
using SIMS_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS_Demo.Controllers
{
    public class TeacherController : Controller
    {
        static List<Teacher> teachers = new List<Teacher>();

        public IActionResult Index()
        {
            return View(teachers);
        }

        public IActionResult NewTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            var existingTeacher = teachers.FirstOrDefault(t => t.Id == teacher.Id);
            if (existingTeacher == null)
            {
                return NotFound();
            }

            existingTeacher.Name = teacher.Name;
            existingTeacher.DoB = teacher.DoB;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            teachers.Remove(teacher);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
