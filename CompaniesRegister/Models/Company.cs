using System;
using System.ComponentModel.DataAnnotations;

namespace CompaniesRegister.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string rnc { get; set; }

        public string name { get; set; }

        public string tradeName { get; set; }

        public string category { get; set; }

        public string paymentScheme { get; set; }

        public string state { get; set; }

        public string economicActivity { get; set; }

        public string localManagement { get; set; }

        [DataType(DataType.Date)]
        public DateTime createdDate { get; set; }

        //public DateTime modifedDate { get; set; }
    }
}
