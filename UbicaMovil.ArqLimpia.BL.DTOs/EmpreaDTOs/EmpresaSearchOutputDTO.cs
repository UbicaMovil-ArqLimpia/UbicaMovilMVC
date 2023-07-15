using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicaMovil.ArqLimpia.BL.DTOs.EmpreaDTOs
{
    public class EmpresaSearchOutputDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string IdCategoria { get; set; }
    }
}
