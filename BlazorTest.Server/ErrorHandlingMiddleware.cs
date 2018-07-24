using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorTest.Server
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext context /* other dependencies */)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)

		{
			/*
			exception	{System.InvalidOperationException: The SPA default page middleware could not return the default page '/index.html' because it was not found, and no other middleware handled the request.

			at Microsoft.AspNetCore.SpaServices.SpaDefaultPageMiddleware.<> c__DisplayClass0_0.< Attach > b__1(HttpContext context, Func`1 next)
   at Microsoft.AspNetCore.Builder.UseExtensions.<> c__DisplayClass0_1.< Use > b__1(HttpContext context)
   at Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(HttpContext httpContext)
   at Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(HttpContext httpContext)
   at BlazorTest.Server.ErrorHandlingMiddleware.Invoke(HttpContext context) in D:\dev\sample\20180617_BlazorTest\BlazorTest\BlazorTest.Server\ErrorHandlingMiddleware.cs:line 24}
		System.Exception {System.InvalidOperationException
	}

	*/

			var code = HttpStatusCode.InternalServerError; // 500 if unexpected

			//if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
			//else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
			//else if (exception is MyException) code = HttpStatusCode.BadRequest;

			var result = JsonConvert.SerializeObject(new { error = exception.Message });
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;
			return context.Response.WriteAsync(result);
		}
	}
}


