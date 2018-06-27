namespace DispensadorDeArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registro
    {
        public int Id { get; set; }

        public string TipoDeArena { get; set; }

        public DateTime HoraYFecha { get; set; }

        public string NombreDeSandblast { get; set; }

        public int Kilos { get; set; }

        public string Name { get; set; }

        public string Clock { get; set; }
    }
}
