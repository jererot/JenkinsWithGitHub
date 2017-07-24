namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GRADO")]
    public partial class GRADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GRADO()
        {
            CURSO = new HashSet<CURSO>();
            MATRICULA = new HashSet<MATRICULA>();
        }

        [Key]
        public int cod_gra { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(20)]
        public string des_gra { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(1)]
        public string niv_gra { get; set; }

        [Required]
        [StringLength(1)]
        public string sec_gra { get; set; }

        public int cod_aula { get; set; }

        public string gradoSeccion { get { return des_gra + " - " + sec_gra; } }

        public virtual AULA AULA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CURSO> CURSO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATRICULA> MATRICULA { get; set; }
    }
}
