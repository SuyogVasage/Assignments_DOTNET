

using SampleCodeFirst;
using System.Text.Json;
//dotnet ef migrations add secondMigration -c _8_March_CodeFirst_EFcore.Models.BusinessDbContext

//dotnet ef database update -c _8_March_CodeFirst_EFcore.Models.BusinessDbContext

CRUD c = new CRUD();
var departments = await c.GetAsync();
Console.WriteLine($"List of Depts\n" +
                    $"{JsonSerializer.Serialize(departments)}\n");
