using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public string BatchName { get; set; }
        public string Year { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}