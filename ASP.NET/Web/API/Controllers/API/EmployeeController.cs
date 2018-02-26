using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;
using API.Controllers.Model;

namespace API.Controllers.API
{
    public class EmployeeController : ApiController
    {
        // POI: List will be destroyed after request is processed
        readonly IEnumerable<Employee> _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "X", Age = 25, OrgId = 20 },
                new Employee { Id = 2, Name = "Y", Age = 35, OrgId = 20 },
                new Employee { Id = 3, Name = "Z", Age = 50, OrgId = 30 }
            };

        [HttpGet]
        // TODO: Use IHttpActionResult
        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        // POI: Other actions are dropping the orgId but matching the route against that because route configuration is set as such
        [HttpGet]
        public IEnumerable<Employee> GetOfOrg(int orgId)
        {
            return _employees.Where(x => x.OrgId == orgId);
        }

        [NonAction]
        public IEnumerable<Employee> Get()
        {
            return _employees;
        }

        [AcceptVerbs("GET")]

        // TODO: Not sure why orgId is must to make the request unambiguous
        // POI: Consider thinking about the URL
        public Employee GetById(int orgId, int id)
        {
            Configuration
                .Services
                .GetTraceWriter()
                .Info(Request, "EmployeeController extends ApiController", "EmployeeController : Getting employee with [id] for [orgId]");

            Debug.Indent();
            Debug.WriteLine("SHOW", "OTHER-CAT");
            Debug.Unindent();

            return _employees.SingleOrDefault(x => x.Id == id && x.OrgId == orgId);
        }

        // POI: Argument name is important for route matching
        public Employee GetBy(int Idd)
        {
            return _employees.SingleOrDefault(x => x.Id == Idd);
        }

        [HttpPost]
        public IEnumerable<Employee> AddEmployee(Employee e)
        {
            if (_employees is List<Employee>) (_employees as List<Employee>).Add(e);
            return _employees;
        }

        [HttpPost]
        // POI: qr can be provided as query string or using route if route is configured as such
        public IEnumerable<Employee> AddAnotherEmployee(Employee e, string qr)
        {
            if (_employees is List<Employee> && !string.IsNullOrWhiteSpace(qr)) (_employees as List<Employee>).Add(e);
            return _employees;
        }

        [HttpPost]
        // POI: Also fine because route allows id
        public IEnumerable<Employee> AddAnEmployee(int id, Employee e)
        {
            if (_employees is List<Employee> && id != 0) (_employees as List<Employee>).Add(e);
            return _employees;
        }
    }
}
