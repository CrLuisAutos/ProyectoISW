namespace LaEsmeraldaCostaRica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Bolsa_por_caja = new HashSet<Bolsa_por_caja>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [Required(ErrorMessage ="Requerido")]
        [DisplayName("Peso(g)")]
        public int peso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bolsa_por_caja> Bolsa_por_caja { get; set; }
    }
}
