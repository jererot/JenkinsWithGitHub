namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PADRE_FAMILIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PADRE_FAMILIA()
        {
            ALUMNO = new HashSet<ALUMNO>();
        }

        [Key]
        public int cod_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(35)]
        public string nom_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15)]
        public string app_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15)]
        public string apm_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(8)]
        [MaxLength(8, ErrorMessage = "El DNI no puede exceder ni ser menor a 8 digitos.")]
        [RegularExpression("^\\d+$", ErrorMessage = "El DNI debe contener sólo números.")]
        [MinLength(8, ErrorMessage = "El DNI no puede exceder ni ser menor a 8 digitos.")]
        public string dni_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage ="El campo debe ser una fecha")]
        public DateTime fna_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(1)]
        [MaxLength(1)]
        public string sex_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(35)]
        [MinLength(8)]
        public string cor_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(10)]
        [MaxLength(9)]
        [RegularExpression("^\\d+$", ErrorMessage = "El dni debe contener sólo números.")]
        [MinLength(7)]
        public string tel_paf { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string dir_paf { get; set; }

        [StringLength(20)]
        public string apo_paf { get; set; }

        [StringLength(9)]
        [MaxLength(9)]
        [RegularExpression("^\\d+$", ErrorMessage = "El dni debe contener sólo números.")]
        public string tel_apo { get; set; }


        [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
        public int cod_dis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUMNO> ALUMNO { get; set; }

        public virtual DISTRITO DISTRITO { get; set; }
    }
}
