using MvcCrudDepartamentosEFCore2022.Data;
using MvcCrudDepartamentosEFCore2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrudDepartamentosEFCore2022.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        //METODO PARA BUSCAR UN EMPLEADO
        public Empleado FindEmpleado(int id)
        {
            return
            this.context.Empleados.FirstOrDefault(z => z.IdEmpleado == id);
        }

        public ResumenEmpleados GetResumenEmpleados(int iddepartamento)
        {
            //VOY A UTILIZAR LAMBDA PARA EL FILTRO
            List<Empleado> empleados =
                this.context.Empleados.Where
                (x => x.IdDepartamento == iddepartamento).ToList();
            if (empleados.Count() == 0)
            {
                return null;
            }
            else
            {
                ResumenEmpleados resumen = new ResumenEmpleados();
                resumen.MaximoSalario =
                    empleados.Max(z => z.Salario);
                resumen.MediaSalarial =
                    empleados.Average(z => z.Salario);
                resumen.SumaSalarial =
                    empleados.Sum(z => z.Salario);
                resumen.Empleados = empleados;
                return resumen;
            }
        }

        //CONSULTA PARA MOSTRAR TODOS LOS EMPLEADOS
        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        //CONSULTA PARA MOSTRAR EMPLEADOS POR SU OFICIO
        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }

        //CONSULTA PARA MOSTRAR LOS DIFERENTES OFICIOS
        //DEBEMOS DEVOLVER UNA COLECCION DE TIPO String
        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                           select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        //CONSULTA PARA MODIFICAR EL SALARIO DE LOS EMPLEADOS
        //POR SU OFICIO
        public void IncrementarSalarioOficio
            (string oficio, int incremento)
        {
            //NECESITAMOS EXTRAER DEL CONTEXT TODOS LOS 
            //EMPLEADOS POR SU OFICIO
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            //TENEMOS QUE RECORRER UNO A UNO CADA EMPLEADO
            //PARA IR MODIFICANDO SU SALARIO CON EL INCREMENTO
            foreach (Empleado emp in empleados)
            {
                emp.Salario += incremento;
            }
            this.context.SaveChanges();
        }
    }
}
