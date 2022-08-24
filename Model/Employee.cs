﻿namespace SalesSystemAPI.Model
{
    public class Employee
    {
        private int id;
        private string name;
        private string lastName;
        private string logOnCredential;
        private string password;
        private string mail;

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LogOnCredential { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public Employee()
        {
            Id = 0;
            Name = String.Empty;
            LastName = String.Empty;
            LogOnCredential = String.Empty;
            Password = String.Empty;
            Mail = String.Empty;
        }

    }
}
