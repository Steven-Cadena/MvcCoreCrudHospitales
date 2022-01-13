using MvcCoreCrudHospitales.Data;
using MvcCoreCrudHospitales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudHospitales.Repositories
{
    public class RepositoryHospitales
    {
        private HospitalesContext context;

        public RepositoryHospitales(HospitalesContext context) 
        {
            this.context = context;
        }
        public List<Hospital> GetHospitales() 
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }
        public Hospital FindHospital(int id) 
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == id
                           select datos;
            return consulta.FirstOrDefault();
        }
        private int GetMaxIdHospital() 
        {
            int maximo =
            this.context.Hospitales.Max(x => x.IdHospital) + 1;
            return maximo;
        }
        public void InsertarHospital(string nombre, string direccion, string telefono, int cama) 
        {
            Hospital hospital = new Hospital();
            hospital.IdHospital = this.GetMaxIdHospital();
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Cama = cama;
            this.context.Hospitales.Add(hospital);
            this.context.SaveChanges();
        }

        public void DeleteHospital(int id) 
        {
            //BUSCAMOS EL OBJETO/S A ELIMINAR
            Hospital hospital = this.FindHospital(id);
            this.context.Hospitales.Remove(hospital);
            this.context.SaveChanges();
        }

        public void UpdateHospital(int id, string nombre, string direccion, string telefono, int cama) 
        {
            Hospital hospital = this.FindHospital(id);
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Direccion = direccion;
            hospital.Cama = cama;
            this.context.SaveChanges();
        }
    }
}
