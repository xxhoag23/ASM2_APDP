using Microsoft.AspNetCore.Mvc;
using SIMS_Demo.Models;

namespace SIMS_Demo.Controllers
{
    public class StudentController : Controller
    {
        static List<Student>? students;

        public IActionResult Index()
        {
            students = StudentControllerHelpers.ReadStudentsFromFile() ?? new List<Student>();
            return View(students);
        }

        [HttpGet]
        public IActionResult NewStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewStudent(Student student)
        {
            if (students == null)
            {
                students = new List<Student>();
            }

            students.Add(student);
            StudentControllerHelpers.WriteStudentsToFile(students);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;
            existingStudent.DoB = student.DoB;
            existingStudent.Class = student.Class;

            StudentControllerHelpers.WriteStudentsToFile(students);  // Assuming this writes the updated list back to the file.

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            students.Remove(student);
            StudentControllerHelpers.WriteStudentsToFile(students);  // Assuming this writes the updated list back to the file.

            return RedirectToAction("Index");
        }

    }
}
