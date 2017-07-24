namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCENTE")]
    public partial class DOCENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCENTE()
        {
            ASIGNACION_CURSO_DOCENTE = new HashSet<ASIGNACION_CURSO_DOCENTE>();
        }

        [Key]
        public int cod_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(35)]
        public string nom_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15)]
        public string app_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15)]
        public string apm_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(8)]
        [MaxLength(8)]
        public string dni_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(1)]
        public string sex_doc { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime fna_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(35)]
        public string cor_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(9)]
        [MaxLength(9)]
        public string tel_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string dir_doc { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(1)]
        [MaxLength(1)]
        public string tip_doc { get; set; }

        public int cod_dis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACION_CURSO_DOCENTE> ASIGNACION_CURSO_DOCENTE { get; set; }

        public virtual DISTRITO DISTRITO { get; set; }

        public virtual DOCENTE_FULLTIME DOCENTE_FULLTIME { get; set; }

        public virtual DOCENTE_PARTTIME DOCENTE_PARTTIME { get; set; }
    }
}
