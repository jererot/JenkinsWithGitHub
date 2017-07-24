namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DISTRITO")]
    public partial class DISTRITO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISTRITO()
        {
            ALUMNO = new HashSet<ALUMNO>();
            DOCENTE = new HashSet<DOCENTE>();
            PADRE_FAMILIA = new HashSet<PADRE_FAMILIA>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cod_dis { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50)]
        public string nom_dis { get; set; }

        public int cod_pro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUMNO> ALUMNO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCENTE> DOCENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PADRE_FAMILIA> PADRE_FAMILIA { get; set; }

        public virtual PROVINCIA PROVINCIA { get; set; }
    }
}
