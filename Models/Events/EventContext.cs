using Microsoft.EntityFrameworkCore;
using Smartsafe.Models;

namespace Smartsafe.Models
{

    public class EventContext : DbContext
    {
        public EventContext (DbContextOptions<EventContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Event {get; set;}        
    }

}