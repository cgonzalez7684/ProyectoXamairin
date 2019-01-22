using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Entidades
{
    public class InfoOperacion
    {
        
        public string Operacion { get; set; }
        public double MontoOperacion { get; set; }
        public double SaldoActual { get; set; }
        public double Tasa { get; set; }
        public int Plazo { get; set; }
    }
}
