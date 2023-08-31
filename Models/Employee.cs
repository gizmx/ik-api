﻿namespace InsanKaynaklariAPI.Models
{
    public class Employee {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; } 
        public DateTime FirstStartDate { get; set; }
        public int Age { get; set; }

        public Guid CompanyID { get; set; } 
        public Company Company { get; set; }



    }
}
