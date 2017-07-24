namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATRICULA")]
    public partial class MATRICULA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATRICULA()
        {
            EVALUACION = new HashSet<EVALUACION>();
        }

        [Key]
        public int cod_mat { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int cod_alum { get; set; }
        
        [Range(0.0, 20.0)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal pro_mat { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int cod_gra { get; set; }

        public virtual ALUMNO ALUMNO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUACION> EVALUACION { get; set; }

        public virtual GRADO GRADO { get; set; }
    }
}
