using System;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Models.Diary
{
    public class DiaryPageItem
    {
        public  TimeSlot timeSlot { get; set;}
        public IEnumerable<DiaryListItem> setA { get; set; }
        public IEnumerable<DiaryListItem> setB { get; set; }
        public IEnumerable<DiaryListItem> setC { get; set; }
    }

}