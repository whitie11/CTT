using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string nhsNo { get; set; }   
        public string cpmsNo { get; set; }
        public string Notes { get; set; }
       public Boolean IsOpen { get; set; }

        [ForeignKey("LocalityId")]
        public int LocalityId { get; set; }
        public Locality Localities { get; set; }
    }
}