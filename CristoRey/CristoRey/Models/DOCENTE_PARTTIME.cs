namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCENTE_PARTTIME 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cod_doc { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime fic_dpt { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime ffc_dpt { get; set; }

        public TimeSpan hen_dpt { get; set; }

        public TimeSpan hsa_dpt { get; set; }

        public virtual DOCENTE DOCENTE { get; set; }
    }
}
