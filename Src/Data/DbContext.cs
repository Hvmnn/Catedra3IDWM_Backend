using Catedra3Backend.Src.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catedra3Backend.Src.Data{

    public class DbContext : IdentityDbContext<User>{
        
        public DbSet<Post> Posts { get; set; } = null!;
    }
}