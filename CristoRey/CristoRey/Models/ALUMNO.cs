namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALUMNO")]
    public partial class ALUMNO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALUMNO()
        {
            MATRICULA = new HashSet<MATRICULA>();
        }

        [Key]
        public int cod_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(35)]
        public string nom_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15)]
        public string app_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(15)]
        public string apm_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(8)]
        [MaxLength(8,ErrorMessage = "El DNI no puede exceder ni ser menor a 8 digitos.")]
        [RegularExpression("^\\d+$", ErrorMessage = "El DNI debe contener sólo números.")]
        [MinLength(8, ErrorMessage = "El DNI no puede exceder ni ser menor a 8 digitos.")]
        public string dni_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha")]
        public DateTime fna_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(1)]
        [MaxLength(1)]
        public string sex_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(35)]
        [MinLength(8)]
        public string cor_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(10)]
        [MaxLength(9)]
        [RegularExpression("^\\d+$", ErrorMessage = "El dni debe contener sólo números.")]
        [MinLength(7)]
        public string tel_alum { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string dir_alum { get; set; }

        [Required(ErrorMessage = "Este cambo es obligatorio")]
        public int cod_dis { get; set; }


        [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
        public int cod_paf { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATRICULA> MATRICULA { get; set; }

        public virtual DISTRITO DISTRITO { get; set; }

        public virtual PADRE_FAMILIA PADRE_FAMILIA { get; set; }
        
    }
}
