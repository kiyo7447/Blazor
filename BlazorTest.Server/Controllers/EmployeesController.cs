using BlazorTest.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		[HttpPost("[action]")]
		public IEnumerable<string> Update([FromBody]Employee employee)
		{
			Debug.WriteLine($"code:{employee.Name}");

//            var r = this.Content();

            
            return Enumerable.Range(1, 3).Select(index => index.ToString()) ;

		}
	}
}
