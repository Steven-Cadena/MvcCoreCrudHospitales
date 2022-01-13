using Microsoft.EntityFrameworkCore;
using MvcCoreCrudHospitales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudHospitales.Data
{
    public class HospitalesContext: DbContext
    {
        public HospitalesContext(DbContextOptions<HospitalesContext> options):base (options) {}

        public DbSet<Hospital> Hospitales { get; set; }
    }
}
