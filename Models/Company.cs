﻿namespace InsanKaynaklariAPI.Models
{
    public class Company {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
}
