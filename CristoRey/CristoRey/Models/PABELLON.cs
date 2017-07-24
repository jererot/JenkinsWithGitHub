namespace CristoRey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PABELLON")]
    public partial class PABELLON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PABELLON()
        {
            AULA = new HashSet<AULA>();
        }

        [Key]
        public int cod_pab { get; set; }

        public int nrp_pab { get; set; }

        public int nra_pab { get; set; }

        public int nap_pab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AULA> AULA { get; set; }
    }
}
