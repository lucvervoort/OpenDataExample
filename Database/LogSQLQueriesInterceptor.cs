using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace OpenDataExample.Database;

/* TIP: vergeet niet toe te voegen aan de scaffolded class een ctor voor DbContextOptions zonder template ...
  
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext(DbContextOptions options)
    : base(options)
    {
    }
*/

public class LogSQLQueriesInterceptor: DbCommandInterceptor
{
    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        LogQueryDetails(command, eventData.Duration.TotalMilliseconds);
        return base.ReaderExecuted(command, eventData, result);
    }

    public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
    {
        LogQueryDetails(command, eventData.Duration.TotalMilliseconds);
        return base.NonQueryExecuted(command, eventData, result);
    }

    public override object? ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object? result)
    {
        LogQueryDetails(command, eventData.Duration.TotalMilliseconds);
        return base.ScalarExecuted(command, eventData, result);
    }

    // e.a.

    private void LogQueryDetails(DbCommand command, double totalMs)
    {
        if (command == null)
        {
            return;
        }
        Debug.WriteLine($"==> [{DateTime.UtcNow}] : query took {totalMs} milliseconds");
    }
}
