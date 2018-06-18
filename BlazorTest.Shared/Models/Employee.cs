using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
	public class Employee
	{
		public int Id { get; set; }
        public string Code{ get; set; }

        public string Name { get; set; }

		public DateTime Birthday { get; set; }

		public int Age => DateTime.Now.Year - Birthday.Year;

        public Dictionary<string, string> ErrorMessage = new Dictionary<string, string>();

        public bool HasError()
        {
            return ErrorMessage.Count > 0 ? true : false;
        }

        //public void SetError(string errorMessage)
        //{
        //    ErrorMessage[""] = errorMessage;
        //}
        
        //public void SetError(string key, string errorMessage)
        //{
        //    ErrorMessage[key] = errorMessage;
        //}

        //public string GetError(string key)
        //{
        //    //if (key == "")
        //    if (ErrorMessage.ContainsKey(key) == false) return "";
        //    return ErrorMessage[key];
        //}
        //public void ClearError()
        //{
        //    ErrorMessage.Clear();

        //}
    }
}
