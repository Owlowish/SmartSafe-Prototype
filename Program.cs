﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore;
using Smartsafe.Models;
using Smartsafe;


namespace Smartsafe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

             using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<UserContext>();
                    var context2 = services.GetRequiredService<VariableContext>();
                    var context3 = services.GetRequiredService<EventContext>();
                    
                    context.Database.Migrate();
                    context2.Database.Migrate();
                    context3.Database.Migrate();

                    UserSeed.Initialize(services);
                    VariableSeed.Initialize(services); 
                    EventSeed.Initialize(services);       
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
