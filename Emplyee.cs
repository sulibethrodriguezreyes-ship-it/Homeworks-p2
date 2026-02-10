using System;
using System.Collections.Generic;
using System.Text;

namespace first_homework
{
    public class Emplyee : Person 
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int YearsExperience { get; set; }
        public string ContractType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

    }
}
