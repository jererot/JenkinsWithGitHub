namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EVALUACION")]
    public partial class EVALUACION
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cod_per { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cod_mat { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0.0,20.0)]
        public decimal n1p_eva { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0.0, 20.0)]
        public decimal n2p_eva { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0.0, 20.0)]
        public decimal n1e_eva { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0.0, 20.0)]
        public decimal n2e_eva { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0.0, 20.0)]
        public decimal pro_eva { get; set; }

        public int cod_cur { get; set; }

        public virtual CURSO CURSO { get; set; }

        public virtual MATRICULA MATRICULA { get; set; }

        public virtual PERIODO PERIODO { get; set; }
    }
}
