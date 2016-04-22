using AngleSharp;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgrammerExcusesApi.Controllers
{
    [Route("api/[Controller]")]
    public class HomeController : Controller
    {
        // GET: /<controller>/

        public async Task<IActionResult> Index()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "http://programmingexcuses.com/";
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cells = document.QuerySelectorAll("a");
            var data = cells.First().TextContent;
            return new JsonResult(new { content = data, title = document.Title });
        }
    }
}