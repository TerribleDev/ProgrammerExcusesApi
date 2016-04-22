using AngleSharp;
using ProgrammerExcuses.Api.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProgrammerExcuses.Api.Controllers
{
    public class HomeController : ApiController
    {
        public async Task<Result> Get()
        {
            var config = AngleSharp.Configuration.Default.WithDefaultLoader();
            var address = "http://programmingexcuses.com/";
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cells = document.QuerySelectorAll("a");
            var data = cells.First().TextContent;
            return new Result() { Content = data, Title = document.Title };
        }
    }
}