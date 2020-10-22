using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using INSERT_PROCEDURE_WEBABI.Models;
namespace INSERT_PROCEDURE_WEBABI.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        EmployeeEntity context = new EmployeeEntity();
        public IHttpActionResult GetEmployee()
        {
            var model = context.PROC_EMPLOYEE_SELECT();
            return Ok(model);
        }
        [HttpPost]
        public IHttpActionResult PostEmployee(TABLE_EMPLOYEE emp)
        {
            if (ModelState.IsValid)
            {
                context.PROC_EMP(emp.EMPLOYEENAME, emp.EMPLOYEESURNAME, emp.EMPLOYEEAGE, emp.EMPLOYEEMAIL);
                context.SaveChanges();
            }
            return Ok();
        }

    }
}
