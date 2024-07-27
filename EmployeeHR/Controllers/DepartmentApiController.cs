using EmployeeHR.Models;
using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace EmployeeHR.Controllers
{
    public class DepartmentApiController : Controller
    {
        Uri BaseUri = new Uri("https://localhost:7117/api");
        private readonly HttpClient _httpClient;
        public DepartmentApiController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress= BaseUri;
        }

        

        

        public IActionResult Index()
        {
            
         
            HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress+ "/Department/GetAll").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                string content=responseMessage.Content.ReadAsStringAsync().Result;

                var departments = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(content);
                return View(departments);

            }

            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentViewModel department)
        {
           using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_httpClient.BaseAddress + "/Department");

                var respoonseMassge = httpClient.PatchAsJsonAsync<DepartmentViewModel>("department", department);
                respoonseMassge.Wait();
                var response = respoonseMassge.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                }
            }

            return View();
        }
        
        









    }
}
