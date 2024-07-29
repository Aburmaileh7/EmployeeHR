using EmployeeHR.Models;
using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;


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

                var respoonseMassge = httpClient.PostAsJsonAsync<DepartmentViewModel>("department", department);
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



        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + $"/Department/GetById/{id}").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = responseMessage.Content.ReadAsStringAsync().Result;

                var department = JsonConvert.DeserializeObject<DepartmentViewModel>(content);
                return View(department);

            }

            return View();
           
        }

        [HttpPost]
        public ActionResult Edit(int id ,DepartmentViewModel department)
        {

            var responseMessage = _httpClient.PutAsJsonAsync<DepartmentViewModel>(_httpClient.BaseAddress + "/Department", department);
            responseMessage.Wait();
            var resp = responseMessage.Result;


            if (resp.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();

        }




    }
}
