using HomeworkFeb28.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HomeworkFeb28.Data;

namespace HomeworkFeb28.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _conStr = @"Data Source=.\sqlexpress;Initial Catalog=People; Integrated Security=true;";
        public IActionResult Index()
        {
            PeopleDbMngr mgr = new(_conStr);
            var vm = new ShowPeopleViewModel
            {
                People = mgr.GetAllPeople()
            };
            if(TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult ShowAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            people = people.Where(p => p.FirstName != null && p.LastName != null && p.Age > 0).ToList();
            if(people.Count == 0)
            {
                return Redirect("/");
            }
            PeopleDbMngr mgr = new(_conStr);
            mgr.AddPeople(people);
            string text = people.Count == 1 ? "person" : "people";
            TempData["message"] = $"{people.Count} {text} added successfully!";
            return Redirect("/");
        }
    }
}