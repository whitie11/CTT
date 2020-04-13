using System;

namespace WebApi.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string NHSno { get; set; }   
        public string CPMSno { get; set; }
        public string Notes { get; set; }
    }
}