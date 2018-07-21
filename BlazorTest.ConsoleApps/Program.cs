using System;
using BlazorTest.Shared;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BlazorTest.ConsoleApps
{
	class Program
	{
		static void Main(string[] args)
		{
			var program = new Program();

			program.Run();

			if (Debugger.IsAttached) Console.In.ReadLine();
		}

		async void Run()
		{
			Console.WriteLine("Hello World!");

			Employee emp = new Employee { Code = "6", Name = "abe kiyotaka", InpBirthday = "2011/01/17", InpSalary = "3000000" };

			if (emp.Validation())
			{
				List<Employee> emps = new List<Employee> { emp };
				using (var client = new HttpClient())
				{
#if false
					System.Runtime.Serialization.Json.DataContractJsonSerializer jsonSerializor = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<Employee>));
					using (var mem = new MemoryStream())
					{
						jsonSerializor.WriteObject(mem, emps);
						var json = Encoding.UTF8.GetString(mem.ToArray());
						Console.Out.WriteLine("json=" + json);
						var content = new StringContent(json, Encoding.UTF8, "application/json");

						var ret = await client.PostAsync("http://localhost:40294/api/Employee/Update", content);
						Console.Out.WriteLine($"{ret}");
				}
#else
					//Nuget Libraryを取込簡略化
					client.BaseAddress = new Uri("http://localhost:40294/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					var ret = await client.PostAsJsonAsync<List<Employee>>("api/Employee/Update", emps);

					Console.Out.WriteLine($"{ret}");
#endif



				}
				//var ret = await client.GetAsync("");

				//			Microsoft.AspNetCore.Blazor.JsonUtil.Serialize()

				//new HttpClient
			}
			else
			{
				emp.ErrorMessage.All(em =>
				{
					Console.Out.WriteLine($"field name={em.Key}, error message={em.Value}");
					return true;
				});
			}

		}
	}
}
