using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AeroAPI.Model
{
    public class Voo
    {
        public int Id { get; set; }

        public DateTime DataIda { get; set; }

        public DateTime DataVolta { get; set; }

        public int LocalOrigemId { get; set; }

        public Local LocalOrigem { get; set; }

        public int LocalDestinoId { get; set; }

        public Local LocalDestino { get; set; }

        public int NumeroParadas { get; set; }

        public TimeSpan TempoVolta { get; set; }

        public double Preco { get; set; }
    }
}