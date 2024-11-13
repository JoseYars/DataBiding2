using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBiding2
{
    public class PersonaModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string fh_nac { get; set; }
        public int id_rol { get; set; }

        public string RolDescripcion
        {
            get
            {
                return id_rol switch
                {
                    1 => "Alumno",
                    2 => "Maestro",
                    3 => "Administrativo",
                    _ => "Desconocido"
                };
            }
        }
    }
}
