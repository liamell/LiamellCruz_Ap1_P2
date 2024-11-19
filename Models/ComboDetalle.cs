using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiamellCruz_Ap1_P2.Models;

public class ComboDetalle
{
    [Key]

    public int DetalleId { get; set; }

    [Required]
    [ForeignKey("Combo")]
    public int ComboId { get; set; }
    public Combo? Combo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [ForeignKey("Articulo")]
    public int ArticuloId { get; set; }
    public Articulo? Articulo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Costo { get; set; }


}
