using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiamellCruz_Ap1_P2.Models;

public class Combo
{

    [Key]
    public int ComboId{ get; set; }

    [Required(ErrorMessage = " Campo obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = " Campo obligatorio")]
    [RegularExpression(@"[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = " Campo obligatorio")]
    public double Precio { get; set; }

    [Required(ErrorMessage = " Campo obligatorio")]
    public int Vendido { get; set; }


    [ForeignKey("ComboId")]
    public ICollection<ComboDetalle> ComboDetalle { get; set; } = new List<ComboDetalle>();


}
