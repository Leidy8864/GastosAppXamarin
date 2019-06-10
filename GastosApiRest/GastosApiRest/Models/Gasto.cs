using System;

namespace GastosApiRest
{
    public class Gasto
    {
        public string _id { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public DateTime fechaGasto { get; set; }

        public double monto { get; set; }

        public string tipoGasto { get; set; }
    }
}
