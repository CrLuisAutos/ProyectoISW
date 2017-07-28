namespace LaEsmeraldaCostaRica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bolsa")]
    public partial class Bolsa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bolsa()
        {
            Bolsa_por_caja = new HashSet<Bolsa_por_caja>();
        }

        public int id { get; set; }

        [Required(ErrorMessage ="Requerido")]
        [StringLength(30, ErrorMessage = "M�ximo 30 caracteres")]
        [DisplayName("C�digo")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [StringLength(30, ErrorMessage = "M�ximo 30 caracteres")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [StringLength(200, ErrorMessage = "M�ximo 200 caracteres")]
        [DisplayName("Descripci�n")]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bolsa_por_caja> Bolsa_por_caja { get; set; }
    }
}
