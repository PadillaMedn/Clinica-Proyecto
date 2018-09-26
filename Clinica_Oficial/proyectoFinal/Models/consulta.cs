namespace proyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("consulta")]
    public partial class consulta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public consulta()
        {
            receta = new HashSet<receta>();
        }

        [Key]
        public int codconsulta { get; set; }

        [Required]
        [StringLength(150)]
        public string diagnostico { get; set; }

        [Required]
        [StringLength(150)]
        public string observaciones { get; set; }

        public int codcita { get; set; }

        public virtual cita cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receta> receta { get; set; }
    }
}
