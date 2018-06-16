using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public DateTime Birthday { get; set; }

		public int Age => DateTime.Now.Year - Birthday.Year;
	}
}
