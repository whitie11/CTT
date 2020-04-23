using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Diary;


namespace WebApi.Services

{
    public interface IDiaryService2
    {
        IEnumerable<DiaryRow> GetDiaryPage(DateTime qDate, int qClinicId);

    }

    public class DiaryService2 : IDiaryService2
    {
        private DataContext _context;
        public DiaryService2(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<DiaryRow> GetDiaryPage(DateTime qDate, int qClinicId)
        {

            List<DiaryRow> diaryPage = new List<DiaryRow>();

            var ts = _context.TimeSlots;

            var appts = (from a in _context.Appts
                         where a.Date == qDate
                         && (a.Stage.StageId != 3)
                         && a.ClinicId == qClinicId
                         //  && a.ClinicGroup == qClinicGroup
                         select a).Include(a => a.Patient).Include(a => a.Type);

            foreach (var t in ts)
            {
                DiaryRow row = new DiaryRow();
                {
                    row.timeSlot = t;
                };
                diaryPage.Add(row);
            }



            if (appts.Count() > 0)
            {

                foreach (var a in appts)
                {

                    foreach (var row in diaryPage)
                    {
                        if (row.timeSlot.TimeSlotId == a.TimeSlotId)
                        {
                            if (a.ClinicGroup == "A")
                            {
                                row.setA = new DiaryListItem()
                                {
                                    timeSlotId = a.TimeSlotId,
                                    TimeSlot = a.TimeSlot.Slot,
                                    patientId = a.PatientId,
                                    PatientName = a.Patient.FirstName + " " + a.Patient.LastName,
                                    Reason = a.Type.TypeText,
                                    apptId = a.ApptId,
                                    notes = a.Notes
                                };
                            }
                            else if (a.ClinicGroup == "B")
                            {
                                row.setB = new DiaryListItem()
                                {
                                    timeSlotId = a.TimeSlotId,
                                    TimeSlot = a.TimeSlot.Slot,
                                    patientId = a.PatientId,
                                    PatientName = a.Patient.FirstName + " " + a.Patient.LastName,
                                    Reason = a.Type.TypeText,
                                    apptId = a.ApptId,
                                    notes = a.Notes
                                };
                            }
                            else if (a.ClinicGroup == "C")
                            {
                                row.setC = new DiaryListItem()
                                {
                                    timeSlotId = a.TimeSlotId,
                                    TimeSlot = a.TimeSlot.Slot,
                                    patientId = a.PatientId,
                                    PatientName = a.Patient.FirstName + " " + a.Patient.LastName,
                                    Reason = a.Type.TypeText,
                                    apptId = a.ApptId,
                                    notes = a.Notes
                                };
                            }
                            else { }
                        }
                    }
                }

            }

            return diaryPage;
        }

        // IEnumerable<DiaryListItem> result = (IEnumerable<DiaryListItem>)diaryList;
        // return result;
    }

}
