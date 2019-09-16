using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Smartsafe.Models
{

    public static class VariableSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VariableContext (
                serviceProvider.GetRequiredService<
                DbContextOptions<VariableContext>>()))
            {
                //look for any variable

                if (context.Variable.Any())
                {
                    return; //DB has been seeded
                }

                context.Variable.AddRange(

                    new Variable{           
                     SignedIn = 0,
                     SignedInUser = "",
                    }
                );
                context.SaveChanges();
            }    
            
        }
    }
    
}