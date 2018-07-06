using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BlazorTest.Shared;
using System.Diagnostics;

namespace BlazorTest.Server
{
    public class ChatHub : Hub
    {
		public Task PostMessage(SimpleMessage msg)
		{
			Debug.WriteLine("class:ChatHubのPostMessage()が呼び出されました。");
			return Clients.All.SendAsync("AddMessage", msg);
		}
    }
}
