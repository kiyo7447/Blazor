using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
	public class SimpleMessage
	{
		//[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;
		//[JsonProperty("message")]
		public string Message { get; set; } = string.Empty;

		public DateTime DateTime { get; set; }
	}
}
