using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Owned_Types.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Address CurrentAddress { get; set; }
        public Address PermanentAddress { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
    }

    public class Address
    {
        public string HouseNo { get; set; }
        public string Society { get; set; }
        public string Details { get; set; }
        public Region Region { get; set; }
    }

    public class Region
    {
        public int RegionId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class Country
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }
}

