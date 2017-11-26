using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

            if (searchType.Equals("all"))
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    jobs = JobData.FindAll();
                }
                else
                {
                    jobs = JobData.FindByValue(searchTerm);
                }

                ViewBag.jobs = jobs;
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
            }

            ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
            ViewBag.columns = ListController.columnChoices;
            return View("Index");
        }

    }
}
