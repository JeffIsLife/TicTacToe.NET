﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace TicTacToe.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Configuration.Properties.TryGetValue("BaseUrl", out var baseAddressObj);
			builder.Services.AddTransient(sp =>
			new HttpClient
			{
				BaseAddress = new Uri(baseAddressObj.ToString())
			});

			await builder.Build().RunAsync();
		}
	}
}
