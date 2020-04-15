using System;

namespace WebApi.Models.Patients
{
    public class PatientsListModel
    {

   public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string nhsNo { get; set; }   
        public string cpmsNo { get; set; }
        public string Notes { get; set; }
       public Boolean IsOpen { get; set; }
        public String Locality { get; set; }
    } 

}