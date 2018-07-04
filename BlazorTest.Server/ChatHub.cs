using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BlazorTest.Shared;

namespace BlazorTest.Server
{
    public class ChatHub : Hub
    {
		public Task PostMessage(SimpleMessage msg)
		{
			return Clients.All.SendAsync("AddMessage", msg);
		}
    }
}
