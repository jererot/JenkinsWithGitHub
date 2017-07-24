namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ASIGNACION_CURSO_DOCENTE
    {
        [Key]
        public int cod_acd { get; set; }

        public int cod_doc { get; set; }

        public int cod_cur { get; set; }

        public virtual CURSO CURSO { get; set; }

        public virtual DOCENTE DOCENTE { get; set; }
    }
}
