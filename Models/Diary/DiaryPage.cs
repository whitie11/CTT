using System;
using System.Collections.Generic;

namespace WebApi.Models.Diary
{
    public class DiaryPage
    {
        public IEnumerable<DiaryListItem> setA { get; set; }
        public IEnumerable<DiaryListItem> setB { get; set; }
        public IEnumerable<DiaryListItem> setC { get; set; }
    }

}