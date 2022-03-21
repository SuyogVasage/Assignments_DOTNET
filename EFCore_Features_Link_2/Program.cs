using System;
using Microsoft.EntityFrameworkCore;
using EFCore_Features_Link_2.Models;

try
{
    ManageDatabase();
    var person = new Person
    {
        FisrtName = "Suyog",
        MiddleName = "Navnath",
        LastName = "Vasage",
        Address = "VimanNagar-Pune",
        ContactNo = "7972011655",
        Email = "suyog.vasage@coditas.com"
    };

    //person.SetEmail("suyog.vasage@coditas.com");

    var db = new PersonalInformationDB();
    db.Persons.Add(person);
    db.SaveChanges();
    var persons = db.Persons.ToListAsync().Result;
    foreach (var item in persons)
    {
        Console.WriteLine($" Person Details {item.FisrtName} {item.MiddleName} {item.LastName} {item.Address}  {item.ContactNo}  {item.Email}");
    }

}
    catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


static void ManageDatabase()
{

    using (var ctx = new PersonalInformationDB())
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }
}

//dotnet ef migrations add firstMigration -c CS_Owned_Types.Models.PersonalInformationDB

//dotnet ef database update -c CS_Owned_Types.Models.PersonalInformationDB
