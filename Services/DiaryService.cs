using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Diary;


namespace WebApi.Services

{
    public interface IDiaryService
    {
        IEnumerable<DiaryListItem> GetDiaryList(DateTime qDate, int qClinicId, string qClinicGroup);

    } 

    public class DiaryService : IDiaryService
    {
        private DataContext _context;
        public DiaryService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<DiaryListItem> GetDiaryList(DateTime qDate, int qClinicId, string qClinicGroup)
        {

            List<DiaryListItem> diaryList = new List<DiaryListItem>();



            var ts = _context.TimeSlots;

            var appts = (from a in _context.Appts
                        where a.Date == qDate
                        && (a.Stage.StageId != 3)
                        && a.ClinicId == qClinicId
                        && a.ClinicGroup == qClinicGroup
                        select a).Include(a => a.Patient).Include(a => a.Type); 

            foreach (var t in ts)
            {
                DiaryListItem i = new DiaryListItem
                {
                    TimeSlot = t.Slot,
                    timeSlotId = t.TimeSlotId,
                    PatientName = null,
                    patientId = null,
                    Reason = null,
                    apptId = null
                };
                diaryList.Add(i);
            }

                if (appts.Count() > 0 ){

                    foreach( var a in appts){
                        var diaryItem = diaryList.FirstOrDefault(x => x.timeSlotId == a.TimeSlotId);
                        if (diaryItem != null) {
                           diaryItem.PatientName = a.Patient.FirstName + " " + a.Patient.LastName;
                           diaryItem.patientId = a.PatientId;
                           diaryItem.Reason = a.Type.TypeText;
                           diaryItem.apptId = a.ApptId;
                        } 
                    }
                }




            IEnumerable<DiaryListItem> result = (IEnumerable<DiaryListItem>)diaryList;
            return result;
        }



    }
}