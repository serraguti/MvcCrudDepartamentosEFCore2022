using MvcCrudDepartamentosEFCore2022.Data;
using MvcCrudDepartamentosEFCore2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrudDepartamentosEFCore2022.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int id)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        private int GetMaxIdDepartamento()
        {
            //SI LA TABLA NO TUVIERA REGISTROS, ESTO NOS DARA
            //UNA EXCEPCION PORQUE NO PUEDE RECUPERAR EL MAX
            //DE UN NULL
            //TENDRIAMOS QUE HACER UN COUNT ANTES
            //NECESITAMOS UN LAMBDA PARA RECUPERAR EL MAXIMO
            //DE LA COLECCION DbSet DE DEPARTAMENTOS
            int maximo =
                this.context.Departamentos.Max(x => x.IdDepartamento) + 1;
            return maximo;
        }

        public void InsertarDepartamento(string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = this.GetMaxIdDepartamento();
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.Departamentos.Add(departamento);
            this.context.SaveChanges();
        }

        public void DeleteDepartamento(int id)
        {
            //BUSCAMOS EL OBJETO/S A ELIMINAR
            Departamento departamento = this.FindDepartamento(id);
            this.context.Departamentos.Remove(departamento);
            this.context.SaveChanges();
        }

        public void UpdateDepartamento
            (int id, string nombre, string localidad)
        {
            Departamento departamento = this.FindDepartamento(id);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.SaveChanges();
        }
    }
}
