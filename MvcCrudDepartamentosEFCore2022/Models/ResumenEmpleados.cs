using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrudDepartamentosEFCore2022.Models
{
    public class ResumenEmpleados
    {
        public int MaximoSalario { get; set; }
        public double MediaSalarial { get; set; }
        public int SumaSalarial { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}
