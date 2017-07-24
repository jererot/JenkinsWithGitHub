namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERIODO")]
    public partial class PERIODO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERIODO()
        {
            EVALUACION = new HashSet<EVALUACION>();
        }

        [Key]
        public int cod_per { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(20)]
        public string des_per { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime fei_per { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime fef_per { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVALUACION> EVALUACION { get; set; }
    }
}
