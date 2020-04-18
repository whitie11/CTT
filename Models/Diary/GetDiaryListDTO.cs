using System;

namespace WebApi.Models.Diary
{
    public class GetDiaryListDTO
    {
        public DateTime qDate { get; set; }
        public int qClinicId { get; set; }
        public string qClinicGroup { get; set; }

    }
}