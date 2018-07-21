using System;
using System.Collections.Generic;
using BlazorTest.Shared;

namespace BlazorTest.ConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			Employee e = new Employee { Name = "abe kiyotaka", InpBirthday = "20110117", InpSalary="3000000"};

			if (e.Validation())
			{

			}
			else
			{
				foreach (var i in e.ErrorMessage)
				{
					Console.Out.WriteLine($"field name={i.Key}, error message={i.Value}");
				}
			}

        }
    }
}
