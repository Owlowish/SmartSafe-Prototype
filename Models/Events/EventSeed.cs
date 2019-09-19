using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Smartsafe.Models
{

    public static class EventSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EventContext (
                serviceProvider.GetRequiredService<
                DbContextOptions<EventContext>>()))
            {
                //look for any Events

                if (context.Event.Any())
                {
                    return; //DB has been seeded
                }

                context.Event.AddRange(

                    new Event{
                        Date = DateTime.Now,
                        Source = "System",
                        Criticite = 1,
                        Description = "Initialisation",           
                        }
                );
                context.SaveChanges();
            }    
            
        }
    }
    
}