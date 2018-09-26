namespace proyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("receta")]
    public partial class receta
    {
        [Key]
        public int codreceta { get; set; }

        public int codconsulta { get; set; }

        [Required]
        [StringLength(250)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string dosis { get; set; }

        public virtual consulta consulta { get; set; }
    }
}
