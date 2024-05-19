using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiTask.Models
{
    public class Patient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalId { get; set; }
        public string City { get; set; }

        // Default constructor
        public Patient()
        {
        }

        // Constructor with parameters
        public Patient(string name, DateTime birthDate, string nationalId, string city)
        {
            Name = name;
            BirthDate = birthDate;
            NationalId = nationalId;
            City = city;
        }
    }
}