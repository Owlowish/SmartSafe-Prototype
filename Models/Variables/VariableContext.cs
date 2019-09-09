using Microsoft.EntityFrameworkCore;

namespace Smartsafe.Models
{

    public class VariableContext : DbContext
    {
        public VariableContext (DbContextOptions<VariableContext> options)
            : base(options)
        {

        }

        public DbSet<Variable> Variable {get; set;}        
    }

}