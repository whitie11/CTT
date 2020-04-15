using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;namespace WebApi.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
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

        public IEnumerable<Patient> GetAll()
        {
           return _context.Patients;
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