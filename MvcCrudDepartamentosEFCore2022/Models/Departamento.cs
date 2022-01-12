using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrudDepartamentosEFCore2022.Models
{
    [Table("DEPT")]
    public class Departamento
    {
        [Key]
        [Column("DEPT_NO")]
        //ESTA INSTRUCCION SE PONDRIA EN EL CASO
        //DE QUE TUVIERAMOS UNA CLAVE IDENTITY EN LA TABLA
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDepartamento { get; set; }
        [Column("DNOMBRE")]
        public String Nombre { get; set; }
        [Column("LOC")]
        public String Localidad { get; set; }
    }
}
