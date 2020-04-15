using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Appt
    {
        public int ApptId { get; set; }

        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }


        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public string ClinicGroup { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }

        public int StageId { get; set; }
        public Stage Stage { get; set; }

        public string Notes { get; set; }

    }
}