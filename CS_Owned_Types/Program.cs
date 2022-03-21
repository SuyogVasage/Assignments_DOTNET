using System;
using Microsoft.EntityFrameworkCore;
using CS_Owned_Types.Models;


            try
            {
                ManageDatabase();
                var db = new PersonalInformationDB();
                var india = new Country { CountryId = "IN", CountryName = "India" };
                db.Add(india);

                var person = new Person
                {
                    FirstName = "Suyog",
                    MiddleName = "Navnath",
                    LastName = "Vasage",
                    ContactNo = "9067109810",
                    Email = "suyog15312@gmail.com",
                    CurrentAddress = new Address()
                    {
                        HouseNo = "404",
                        Society = "Morya",
                        Details = "Viman Nagar",
                        Region = new Region()
                        {
                            RegionId = 1001,
                            City = "Pune",
                            District = "Pune",
                            State = "Maharashtra",
                            Country = india
                        }
                    },
                    PermanentAddress = new Address()
                    {
                        HouseNo = "54",
                        Society = "Diksha",
                        Details = "Ratnagiri",
                        Region = new Region()
                        {
                            City = "Pune",
                            District = "Pune",
                            State = "Maharashtra",
                            Country = india
                        }
                    }

                };


                db.Persons.Add(person);
                db.SaveChanges();
                var persons = db.Persons.ToListAsync().Result;
                foreach (var item in persons)
                {
                    Console.WriteLine($"Person Details {item.FirstName} {item.MiddleName} {item.LastName}  {item.Email} {item.ContactNo}");
                    Console.WriteLine($"Address {item.CurrentAddress.HouseNo} {item.CurrentAddress.Society} {item.CurrentAddress.Details}");
                    Console.WriteLine($"Region {item.CurrentAddress.Region.City} {item.CurrentAddress.Region.District} {item.CurrentAddress.Region.State}");
                    Console.WriteLine($"Address {item.PermanentAddress.HouseNo} {item.PermanentAddress.Society} {item.PermanentAddress.Details}");
                    Console.WriteLine($"Region {item.PermanentAddress.Region.City} {item.PermanentAddress.Region.District} {item.PermanentAddress.Region.State}");
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        

        static void ManageDatabase()
        {

            using (var ctx = new PersonalInformationDB())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    
