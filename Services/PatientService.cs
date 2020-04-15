using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Patients;

namespace WebApi.Services

{
    public interface IPatientService
    {
        IEnumerable<PatientsListModel> GetAll();
        Patient GetById(int id);
        Patient Create(Patient patient);
        void Update(Patient patient);
        void Delete(int id);  
    }

    public class PatientService : IPatientService
    {
       private DataContext _context;
        public PatientService(DataContext context)
        {
             _context = context;
        }
        public Patient Create(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientsListModel> GetAll()
        {
           
           var pts =(from p in  _context.Patients
            select new PatientsListModel
            {
            PatientId = p.PatientId,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Dob = p.Dob,
            nhsNo = p.nhsNo,
            cpmsNo = p.cpmsNo,
            Notes = p.Notes,
            IsOpen = p.IsOpen,
            Locality = p.Localities.Name
            }).ToList();

            return pts;
        }

        public Patient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}