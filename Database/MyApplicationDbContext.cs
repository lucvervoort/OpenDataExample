using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace OpenDataExample.Database;

public class MyApplicationDbContext: ApplicationDbContext
{
    public MyApplicationDbContext()
    {
    }

    public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .LogTo(msg => Debug.WriteLine(msg), LogLevel.Information) // logt ook queries naar het Debug venster...
        .EnableDetailedErrors() // meer details mbt fouten! Vb mapping types tov db
        .EnableSensitiveDataLogging(); // hmmm ...
        //.AddInterceptors(new LogSQLQueriesInterceptor());
}
