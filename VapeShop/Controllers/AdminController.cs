using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.ViewModels;

namespace VapeShop.Controllers;

public class AdminController : Controller
{
    private readonly DatabaseContext _context;
    private readonly string _set = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "set " : "export ";
        
    public AdminController(DatabaseContext context)
    {
        _context = context;
    }
    
    public IActionResult EasyData() => View();
    public async Task<IActionResult> Diagrams() => View(await GetDataForCharts());
    
    public async Task<ChartViewModel> GetDataForCharts()
    {
        var model = new ChartViewModel();
        
        //Bar - просмотр количество проданных экземпляров
        var barLabels = await _context.Products.Select(x => x.Name).ToListAsync();
        var barPrices = await _context.Products.Select(x => x.NumberSales).ToListAsync();
        
        
        //Line - количество продаж за неделю
        var records = await _context.Orders
            .Include(x => x.Products)
            .ThenInclude(x => x.Product)
            .ToListAsync();

        var now = DateTime.Now.Date.AddDays(1);
        var date = DateTime.Now.Date.AddDays(-6);

        var lineData = new List<int>();
        var lineLabels = new List<string>();
        
        while (now != date)
        {
            //количество проданной продукции за день
            int count = records
                .Where(x => x.DateTime.Date == date)
                .Select(x => x.Products.Select(z => z.Amount).Sum())
                .Sum();
            
            lineLabels.Add(date.DayOfWeek.ToString());
            lineData.Add(count);
            
            date = date.AddDays(1);
        }
        
        model.BarLabels = barLabels;
        model.BarData = barPrices;

        model.LineData = lineData;
        model.LineLabels = lineLabels;
        return model; 
    }
    
    
    public async Task ExportData()
    {
        const string dirName = @"C:\tmp\csv";
        if (!Directory.Exists(dirName)) Directory.CreateDirectory(@"C:\tmp\csv");
        await _context.Database.ExecuteSqlRawAsync("call BackupCSV();");
    }

    public ViewResult Backup()
     {
         var list = new List<string>();
         const string dirName = @"C:\tmp";
         if (Directory.Exists(dirName))
         {
             var files = Directory.GetFiles(dirName);
             list.AddRange(files.Select(Path.GetFileName)!);
         }
         else
             Directory.CreateDirectory(@"C:\tmp");
         
         return View(list);
    }

    public async Task Dump()
    {
        var date = DateTime.Now;
        var fileName = $"{date.Year}{date.Month}{date.Day}{date.Hour}{date.Minute}";
        await PSqlDump(
            @"C:\Program Files\PostgreSQL\14\bin\", 
            "333", 
            "postgres", 
            "VapeShop", 
            $"/tmp/{fileName}");
    } 
    
    public async Task Restore(string name)
    {
        await PSqlRestore(
            @"C:\Program Files\PostgreSQL\14\bin\", 
            "333", 
            "postgres", 
            "VapeShop", 
            $"/tmp/{name}");
    }

    private async Task PSqlDump(string pathToExecutableFile, string password, string login, string database, string outputFile)
    {
        string[] commands =
        {
            $"cd {pathToExecutableFile}", 
            $"{_set} PGPASSWORD={password}", 
            $"pg_dump.exe -U {login} {database} > {outputFile}.sql"
        };
        await RunCommands(commands);
    }
    
    private async Task PSqlRestore(string pathToExecutableFile, string password, string login, string database, string inputFile)
    {
        string[] commands =
        {
            $"cd {pathToExecutableFile}", 
            $"{_set} PGPASSWORD={password}", 
            $"psql -U {login} -d {database} -c \"select pg_terminate_backend(pid) from pg_stat_activity where datname = '{database}'",
            $"dropdb -U {login} {database}",
            $"createdb -U {login} {database}",
            $"psql -U {login} -d {database} -f {inputFile}",
        };
        await RunCommands(commands);
    }

    private static async Task RunCommands(string[] commands)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false

            }
        };
        process.Start();
        await using var pWriter = process.StandardInput;
        if (pWriter.BaseStream.CanWrite)
        {
            foreach (var line in commands)
                await pWriter.WriteLineAsync(line);
        }
    }
}