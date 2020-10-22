using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using INSERT_PROCEDURE_WEBABI.Models;
namespace INSERT_PROCEDURE_WEBABI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<TABLE_EMPLOYEE> model = null;
            HttpClient ht = new HttpClient();
            ht.BaseAddress = new Uri("http://localhost:64918/api/EmployeeAPI");

            var record = ht.GetAsync("EmployeeAPI");
            record.Wait();

            var readData = record.Result;
            if(readData.IsSuccessStatusCode)
            {
                var displayResult = readData.Content.ReadAsAsync<IEnumerable<TABLE_EMPLOYEE>>();
                displayResult.Wait();
                model = displayResult.Result;
            }
        
            return View(model);
        }
        public ActionResult CreateEmployee()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(TABLE_EMPLOYEE emp)
        {
            if(ModelState.IsValid)
            {
                HttpClient ht = new HttpClient();
                ht.BaseAddress = new Uri("http://localhost:64918/api/EmployeeAPI");

                var insertPort = ht.PostAsJsonAsync<TABLE_EMPLOYEE>("EmployeeAPI", emp);
                insertPort.Wait();
                var savePort = insertPort.Result;
                if(savePort.IsSuccessStatusCode)
                {
                    ViewBag.Messagge = emp.EMPLOYEENAME + " is success.";
                }
            }
            return View();
        }
    }
}
