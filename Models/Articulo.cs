using System.ComponentModel.DataAnnotations;

namespace LiamellCruz_Ap1_P2.Models;

public class Articulo
{
    [Key]

    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int Existencia { get; set; }
}
