using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Modelos
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El número de factura es obligatorio.")]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "El número de factura debe ser numérico y contener 12 dígitos.")]
        public string NroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }
        public decimal TotalIvaCinco { get; set; }
        public decimal TotalIvaDiez { get; set; }
        public decimal TotalIva { get; set; }
        public string TotalLetras { get; set; }
        public string Sucursal { get; set; }

    }
}
