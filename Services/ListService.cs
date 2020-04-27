using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Diary;


namespace WebApi.Services

{
    public interface IListService
    {
     IEnumerable<Clinic> GetClinics();
IEnumerable<Locality> GetLocalities();
    }

    public class ListService : IListService
    {
        private DataContext _context;
        public ListService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Clinic> GetClinics()
        {
            return _context.Clinics;
        }

        public IEnumerable<Locality> GetLocalities()
        {
            return _context.Localities;
        }
    }
}