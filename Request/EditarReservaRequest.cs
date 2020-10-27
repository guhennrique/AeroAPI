using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroAPI.Request
{
    public class EditarReservaRequest
    {
        public int Id { get; set; }

        public string Documento { get; set; }

        public int Poltrona { get; set; }
     
    }
}
