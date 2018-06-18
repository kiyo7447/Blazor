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
        public IEnumerable<Employee> Update([FromBody]IEnumerable<Employee> employees)
        {
            //パラメータの表示
            employees.All(e => {
                Debug.WriteLine($"Id:{e.Id}, Code:{e.Code}, Name:{e.Name}, Birthday:{e.Birthday}, Age:{e.Age}");
                Debug.WriteLine($"e.HasError():{e.HasError()}");
                e.ErrorMessage.All(d =>
                {
                    Debug.WriteLine($"key:{d.Key}, ErrorMessage:{d.Value}");
                    return true;
                });
                return true;
            });
#if true
            //DB以外の入力チェック（サーバ版）
            employees.All(e => {
                e.ErrorMessage.Clear();
                e.Check();
                return true;
            });

            Thread.Sleep(1300);

            return employees;
#else
            return Enumerable.Range(1, 3).Select(index => new Employee {
                Id = index,
                Code = $"{index:D6}",
                Name = "hogehoge",
                Birthday = DateTime.Now.AddYears(-7)
            });
#endif
        }
    }
}
