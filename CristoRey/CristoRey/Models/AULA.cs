namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AULA")]
    public partial class AULA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AULA()
        {
            GRADO = new HashSet<GRADO>();
        }

        [Key]
        public int cod_aula { get; set; }

        public int cod_pab { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string des_ubi { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int nca_aul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRADO> GRADO { get; set; }

        public virtual PABELLON PABELLON { get; set; }
    }
}
