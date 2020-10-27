using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroAPI.Request
{
    public class EfetuarReservaRequest
    {
        public int VooId { get; set; }

        public string Documento { get; set; }

        public int Poltrona { get; set; }
     
    }
}
