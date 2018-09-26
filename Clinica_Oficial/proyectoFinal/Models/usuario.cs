namespace proyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            cita = new HashSet<cita>();
        }

        public int id { get; set; }

        [Column("usuario")]
        [StringLength(100)]
        [Required]
        public string usuario1 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string pass { get; set; }

        public int id_rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cita> cita { get; set; }

        public virtual rol rol { get; set; }
    }
}
