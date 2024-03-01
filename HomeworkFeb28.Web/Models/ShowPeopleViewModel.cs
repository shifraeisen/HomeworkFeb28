using HomeworkFeb28.Data;
using Microsoft.AspNetCore.Identity;

namespace HomeworkFeb28.Web.Models
{
    public class ShowPeopleViewModel
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
    }
}
