// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
//
// namespace Infrastructure.Persistence;
//
// public class ApplicationDbFactory
//     : IDesignTimeDbContextFactory<ApplicationDbContext>
// {
//     public ApplicationDbContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//
//         optionsBuilder.UseSqlite("Data Source=sqlite_forum.db");
//
//         return new ApplicationDbContext(optionsBuilder.Options);
//     }
// }

// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
//
// namespace Infrastructure.ApplicationDbContext;
//
// public class ApplicationDbFactory
//     : IDesignTimeDbContextFactory<ApplicationDbContext>
// {
//     public ApplicationDbContext CreateDbContext(string[] args)
//     {
//         var configuration = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())
//             .AddJsonFile("appsettings.json", optional: false)
//             .Build();
//
//         var connectionString =
//             configuration.GetConnectionString("DefaultConnection");
//
//         var optionsBuilder =
//             new DbContextOptionsBuilder<ApplicationDbContext>();
//
//         optionsBuilder.UseSqlite(connectionString);
//
//         return new global::Infrastructure.ApplicationDbContext.ApplicationDbContext(optionsBuilder.Options);
//     }
// }