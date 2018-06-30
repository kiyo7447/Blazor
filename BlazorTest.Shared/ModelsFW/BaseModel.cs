using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class BaseModel
    {
        public Dictionary<string, string> ErrorMessage = new Dictionary<string, string>();

        public bool IsValid(string propertyName= null)
        {
            if (propertyName != null)
                return ErrorMessage.ContainsKey(propertyName);
            else
               return ErrorMessage.Count > 0 ? true : false;
        }

    }
}
