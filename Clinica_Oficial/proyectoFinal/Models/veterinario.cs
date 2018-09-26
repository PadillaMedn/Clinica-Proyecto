namespace proyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("veterinario")]
    public partial class veterinario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public veterinario()
        {
            cita = new HashSet<cita>();
        }

        [Key]
        public int codVeterinario { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z Ò—·ÈÌÛ˙¡…Õ”⁄]+?$", ErrorMessage = "Solo se permiten letras")]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z Ò—·ÈÌÛ˙¡…Õ”⁄]+?$", ErrorMessage = "Solo se permiten letras")]
        public string apellido { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{8})\)?[-]([0-9]{1})$", ErrorMessage = "Introduzca un N˙mero V·lido")]
        [StringLength(10)]
        public string dui { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-]([0-9]{4})$", ErrorMessage = "Introduzca un N˙mero V·lido")]
        [StringLength(10)]
        public string telefono { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+?$", ErrorMessage = "Solo se Permiten Letras")]
        [StringLength(10)]
        public string sexo { get; set; }

        [Required]
        [StringLength(150)]
        public string direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cita> cita { get; set; }
    }
}
