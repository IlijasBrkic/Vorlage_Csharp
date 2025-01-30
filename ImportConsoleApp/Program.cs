using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Base.Core;
using Base.Tools;

using Core.Contracts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Persistence;

var configuration = ConfigurationHelper.GetConfiguration();

var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//TODO
AppService.ServiceCollection = new ServiceCollection();
AppService.ServiceCollection
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString))
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddTransient<IImportController, ImportController>()
    ;
    

AppService.BuildServiceProvider();

await RecreateDatabaseAsync();
await ImportCsvs();

async Task ImportCsvs()
{
    Console.WriteLine("=====================");
    Console.WriteLine("Import Exam Results");
    int countTotal = 0;

    using (var scope = AppService.ServiceProvider!.CreateScope())
    {
        var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var import = scope.ServiceProvider.GetRequiredService<IImportController>();

        //TODO - Add here the name of the method (csvFile.)
        var csvFiles = Array.Empty<string>();

        foreach (var csvFile in csvFiles)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //TODO
            //await import.NameOfMethod(csvFile);

            stopwatch.Stop();

            //TODO - Add here the filename (csvFile.)
            Console.WriteLine($"Imported {csvFile} in {stopwatch.Elapsed}");
            countTotal++;

        }
    }

    Console.WriteLine($"Import done: {countTotal} files");
}
async Task RecreateDatabaseAsync()
{
    using (var scope = AppService.ServiceProvider!.CreateScope())
    {
        var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        Console.WriteLine("Deleting database ...");
        await uow.DeleteDatabaseAsync();

        Console.WriteLine("Recreating and migrating database ...");
        await uow.MigrateDatabaseAsync();
    }
}