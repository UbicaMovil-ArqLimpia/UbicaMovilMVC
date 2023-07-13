using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicaMovil.ArqLimpia.BL.DTOs.EmpreaDTOs
{
    public class EmpresaSearchInputDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string IdCategoria { get; set; }
    }
}
