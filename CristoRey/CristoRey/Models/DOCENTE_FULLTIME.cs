namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCENTE_FULLTIME
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cod_doc { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime fic_dft { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime ffc_dft { get; set; }

        public TimeSpan hen_dft { get; set; }

        public TimeSpan hsa_dft { get; set; }

        public virtual DOCENTE DOCENTE { get; set; }
    }
}
