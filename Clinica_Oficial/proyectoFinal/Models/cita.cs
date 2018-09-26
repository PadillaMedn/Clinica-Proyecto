namespace proyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cita")]
    public partial class cita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cita()
        {
            consulta = new HashSet<consulta>();
        }

        [Key]
        public int codcita { get; set; }

        public int codusuario { get; set; }

        public int codmascota { get; set; }

        public int codveterinario { get; set; }

        [StringLength(12)]
        [Required]
        [DataType(DataType.Date)]
        public string fecha { get; set; }

        [StringLength(8)]
        [Required]
        [DataType(DataType.Time)]
        public string hora { get; set; }

        public int codestado { get; set; }

        public virtual usuario usuario { get; set; }

        public virtual mascota mascota { get; set; }

        public virtual veterinario veterinario { get; set; }

        public virtual estado estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consulta> consulta { get; set; }
    }
}
