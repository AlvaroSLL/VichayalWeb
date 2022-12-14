using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Modelo;

namespace Capa_Negocio
{
    public class CN_Estudiante
    {
        private CD_Estudiante objCapaDato = new CD_Estudiante();

        public List<Estudiante> CN_ListarEstudiante()
        {
            return objCapaDato.CD_ListarEstudiante();
        }
    }
}
