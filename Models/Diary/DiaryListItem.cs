using System;

namespace WebApi.Models.Diary
{
    public class DiaryListItem
    {
        public string TimeSlot { get; set; }
        public string PatientName { get; set; }
        public string Reason { get; set; }
        public int? apptId { get; set; }
        public int? patientId { get; set; }
        public int timeSlotId { get; set; }

    }
}

