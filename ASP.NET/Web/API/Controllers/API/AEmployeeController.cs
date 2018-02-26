using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using API.Controllers.Model;
using API.Models;

namespace API.Controllers.API
{
    public class AEmployeeController : ApiController
    {
        static readonly List<Employee> _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "X", Age = 25, OrgId = 20, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Y", Age = 35, OrgId = 20, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Z", Age = 50, OrgId = 30, DepartmentId = 3 },
                new Employee { Id = 3, Name = "AZ", Age = 30, OrgId = 40, DepartmentId = 3 }
            };

        // GET api/{orgId}/aemployee
        [NonAction]
        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            Configuration
                .Services
                .GetTraceWriter()
                .Info(Request, "BY ID", "Employee ID => " + id);

            return _employees.ToList().Find(x => x.Id == id);
        }


        // POI: Allowing deptId to be passed without changing route. deptId is passed via query string
        // POI: To extend actions by allowing more arguments we can use query string though ideally it's better to
        // pass value using route which makes it more obvious
        // POI: To make custom Type bind to URI values we must specify [FromUri] attribute because by default
        // only primitive Types are mapped from query string
        // TODO: Why EmployeeFilter is not enough to seperate the URIs?
        // POI: Filtering Models can be used to make code readable

        // GET api/{orgId}/aemployee?deptId={id}
        public IEnumerable<Employee> GetByDepartment([FromUri]EmployeeFilter filter/*int deptId, string name*/)
        {
            var es = _employees
                .Where(x => x.DepartmentId == filter.deptId && x.Name.Contains(filter.name))
                .ToList();

            if (es.Count == 0)
                // POI: ResponseException needs to be thrown rather than returned
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = "Invalid Department"
                });

            return es;
        }

        [HttpPut]
        public HttpResponseMessage UpdateEmployee(Employee e)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Model Not Valid"
                });

            if (_employees.Find(x => x.Id == e.Id) == null) return Request.CreateResponse(HttpStatusCode.NoContent);

            _employees.Remove(_employees.Find(x => x.Id != e.Id));
            _employees.Add(e);

            var res = Request.CreateResponse(HttpStatusCode.Created, e);
            res.Headers.Location = new Uri(Url.Link("DefaultApi", null));

            return res;
        }

        // TODO: Whitelist properties
        [HttpPost]
        public HttpResponseMessage AddEmployee(Employee e)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Employee is not valid"
                });

            Configuration
                .Services
                .GetTraceWriter()
                .Info(Request, "Id Supplied", "Employeed Id => " + e.Id);

            var maxId = _employees.Max(x => x.Id);

            e.Id = maxId + 10;

            _employees.Add(e);

            // TODO: When to use Request's CreateResponse
            var res = Request.CreateResponse(HttpStatusCode.Created, e);

            // TODO: Fix issue with passing values
            res.Headers.Location = new Uri(Url.Link("DefaultApi", null/*new { orgId = 0, id = e.Id }*/));// http://localhost:24106/web-api/0/aemployee

            return res;
        }


    }
}
