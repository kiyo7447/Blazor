using BlazorTest.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorTest.Server.Controllers
{
	[Route("api/[controller]")]
	public class EmployeesController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<Employee> GetEmployees()
        {
            var rng = new Random();
			//Thread.Sleep(10000);
			return Enumerable.Range(1, 5).Select(index => new Employee
			{
				Id = index,
				Birthday = DateTime.Now.AddDays(index),
				Name = rng.Next(-20, 55).ToString()
			});
        }

		[HttpGet("[action]")]
		public IEnumerable<Employee> UpdateEmployees(IEnumerable<Employee> employees)
		{
			var rng = new Random();

			var empcode = Facade.Checker.Code.Check(123, CodeEnum.EmployeeCode);

			//Thread.Sleep(10000);
			return Enumerable.Range(1, 5).Select(index => new Employee
			{
				Id = index,
				Birthday = DateTime.Now.AddDays(index),
				Name = rng.Next(-20, 55).ToString()
			});


		}
	}
}
