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
            ViewBag.selected = "all";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType,string searchTerm)
        {
            ViewBag.selected = searchType;
            if (searchType == "all")
            {
                List<Dictionary<string, string>> searchResult = JobData.FindByValue(searchTerm);
                ViewBag.title = "search results for:" + searchTerm;
                ViewBag.jobs = searchResult;                
                List<string> header = new List<string>(searchResult[0].Keys);
                ViewBag.header = header;
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            }
            
            else
            {
                List<Dictionary<string, string>> result = JobData.FindByColumnAndValue(searchType,searchTerm);
                ViewBag.title = "search results for:" + ListController.columnChoices[searchType];
                ViewBag.jobs = result;
                ViewBag.columns = ListController.columnChoices;
                List<string> header;
                if (result.Count > 0)
                {
                    header = new List<string>(result[0].Keys);
                }
                else
                {
                    header = new List<string>();
                }
                ViewBag.header = header;
                return View("Index");
            }

            
        }
       

    }
}
