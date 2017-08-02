namespace LaEsmeraldaCostaRica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bolsa_por_caja
    {
        public int id { get; set; }

        [DisplayName("Código")]
        public int codigo { get; set; }

        [DisplayName("Bolsa")]
        [Required]
        public int id_bolsa { get; set; }

        [DisplayName("Caja")]
        [Required]
        public int id_caja { get; set; }

        [DisplayName("Producto")]
        [Required]
        public int id_producto { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Range(1,1000, ErrorMessage ="Mínimo 1 - Máximo 1000")]
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Fecha de entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? fec_entrada { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Fecha de Vencimiento")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? fech_vencimiento { get; set; }

        public ICollection<Caja> ListCajas;
        public ICollection<Bolsa> ListBolsa;
        public ICollection<Producto> ListProducto;

        public virtual Bolsa Bolsa { get; set; }

        public virtual Caja Caja { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
