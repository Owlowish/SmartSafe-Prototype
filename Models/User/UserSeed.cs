using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Smartsafe.Models
{

    public static class UserSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserContext (
                serviceProvider.GetRequiredService<
                DbContextOptions<UserContext>>()))
            {
                //loook for any users

                if (context.User.Any())
                {
                    return; //DB has been seeded
                }

                context.User.AddRange(

                    new User{
                        
                        UserNumber = "1111",
                        Password = "1111",
                        FirstName = "Yuhan",
                        FamilyName = "Chen",            
                    },

                      new User{                       
                        UserNumber = "2222",
                        Password = "2222",
                        FirstName = "Hugo",
                        FamilyName = "Ruellet",                      
                    },

                        new User{ 
                        UserNumber = "9999",
                        Password = "9999",
                        FirstName = "Donald",
                        FamilyName = "Trump",  
                    }
                );
                context.SaveChanges();
            }    
            
        }
    }
    
}