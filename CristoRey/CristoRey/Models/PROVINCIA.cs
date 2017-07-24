namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROVINCIA")]
    public partial class PROVINCIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVINCIA()
        {
            DISTRITO = new HashSet<DISTRITO>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cod_pro { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50)]
        public string nom_pro { get; set; }

        public int cod_dep { get; set; }

        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISTRITO> DISTRITO { get; set; }
    }
}
