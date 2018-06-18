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

        public Dictionary<string, string> ErrorMessage = new Dictionary<string, string>();

        public bool IsValid()
        {
            return ErrorMessage.Count > 0 ? true : false;
        }

        public bool Validation()
        {
            ErrorMessage.Clear();
            bool _ret = true;
            try
            {
                Facade.Checker.Code.IsRequire(Code, CodeEnum.EmployeeCode);
                Code = Facade.Checker.Code.Check(Code, CodeEnum.EmployeeCode);
            }
            catch (ApplicationException ae)
            {
                ErrorMessage[nameof(Employee.Code)] = ae.Message;
                _ret =  false;
            }

            return _ret;
        }

    }
}
