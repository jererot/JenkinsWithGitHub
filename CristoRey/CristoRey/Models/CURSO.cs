namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CURSO")]
    public partial class CURSO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CURSO()
        {
            ASIGNACION_CURSO_DOCENTE = new HashSet<ASIGNACION_CURSO_DOCENTE>();
            EVALUACION = new HashSet<EVALUACION>();
        }

        [Key]
        public int cod_cur { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(45)]
        public string nom_cur { get; set; }

        public TimeSpan hin_cur { get; set; }

        public TimeSpan hfi_cur { get; set; }

        public int cod_are { get; set; }

        public int cod_gra { get; set; }

        public virtual AREA AREA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACION_CURSO_DOCENTE> ASIGNACION_CURSO_DOCENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUACION> EVALUACION { get; set; }

        public virtual GRADO GRADO { get; set; }
    }
}
