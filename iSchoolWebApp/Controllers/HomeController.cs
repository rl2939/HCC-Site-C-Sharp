using iSchoolWebApp.Models;
using iSchoolWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;

namespace iSchoolWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> About()
        {
            //I nned to create my model
            var aboutMod = new AboutModel();

            //I need to get the data
            //need a utility method to go tet the data
            GetData gd = new GetData();
            var rtnResults = await gd.GetMyData("about/");
            //now rtn results is a string,need to cast to JSON
            //so we loaded Newtonsoft in JSON in NuGet
            var rtnJson = JsonConvert.DeserializeObject<AboutModel>(rtnResults);
            //add to the object
            rtnJson.pageTitle = "About RIT";

            //I need to populate the model with the data
            //I may need to add more to te model
            //I neeed to send the model to the view

            return View(rtnJson);
        }

        public async Task<IActionResult> Degrees()
        {
            //I need to create my model
            var DegreesMod = new DegreesModel();
            //I need to get the data
            GetData gd = new GetData();
            var rtnResults = await gd.GetMyData("degrees/");
            //now rtn results is a string,need to cast to JSON
            var rtnJson = JsonConvert.DeserializeObject<DegreesModel>(rtnResults);
            //add to the object
            rtnJson.pageTitle = "Our Degrees";

            return View(rtnJson);
        }
        public async Task<IActionResult> Minors()
        {
            //load the data...
            GetData gd = new GetData();
            //tell the instance to get the data...
            var loadedMinors = await gd.GetMyData("minors/");
            //cast it to JSON and the object we want.
            var rtnMinors = JsonConvert.DeserializeObject<MinorsModel>(loadedMinors);

            //second get
            var loadedCourse = await gd.GetMyData("course/");
            var courseRtnResult = JsonConvert.DeserializeObject<List<CourseModel>>(loadedCourse);

            //using System.dymanic
            dynamic expando = new ExpandoObject();
            var comboModel = expando as IDictionary<string, object>;

            comboModel.Add("Minors", rtnMinors);
            comboModel.Add("Course", courseRtnResult);
            comboModel.Add("pageTitle", "Minors @ RIT");

            return View(comboModel);
        }

        public async Task<IActionResult> Employment()
        {
            //I need to create my model
            var employmentMod = new EmploymentModel();
            //I need to get the data
            GetData gd = new GetData();
            var rtnResults = await gd.GetMyData("Employment/");
            //now rtn results is a string,need to cast to JSON
            var rtnJson = JsonConvert.DeserializeObject<EmploymentModel>(rtnResults);
            //add to the object
            rtnJson.pageTitle = "RIT and Employment";

            return View(rtnJson);
        }

        public async Task<IActionResult> People()
        {
            //I need to create my model
            var peopleMod = new PeopleModel();
            //I need to get the data
            GetData gd = new GetData();
            var rtnResults = await gd.GetMyData("people/");
            //now rtn results is a string,need to cast to JSON
            var rtnJson = JsonConvert.DeserializeObject<PeopleModel>(rtnResults);
            //add to the object
            rtnJson.pageTitle = "Our People";

            return View(rtnJson);
        }

        public async Task<IActionResult> News()
        {
            //I need to create my model
            var NewsMod = new NewsModel();
            //I need to get the data
            GetData gd = new GetData();
            var rtnResults = await gd.GetMyData("news/");
            //now rtn results is a string,need to cast to JSON
            var rtnJson = JsonConvert.DeserializeObject<NewsModel>(rtnResults);
            //add to the object
            rtnJson.pageTitle = "RIT News";

            return View(rtnJson);
        }

        public async Task<IActionResult> DynTest()
        {
            //load the data...
            GetData gd = new GetData();
            //tell the instance to get the data...
            var loadedAbout = await gd.GetMyData("about/");
            //cast it to JSON and the object we want.
            var rtnResults = JsonConvert.DeserializeObject<AboutModel>(loadedAbout);

            //second get
            var loadedCourse = await gd.GetMyData("course/courseID=ISTE-340");
            var courseRtnResult = JsonConvert.DeserializeObject<CourseModel>(loadedCourse);

            //using System.dymanic
            dynamic expando = new ExpandoObject();
            var comboModel = expando as IDictionary<string, object>;

            comboModel.Add("About", rtnResults);
            comboModel.Add("Course", courseRtnResult);
            comboModel.Add("pageTitle", "Test with a Dynamic Object");

            return View(comboModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}