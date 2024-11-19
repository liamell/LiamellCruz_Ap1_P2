using System.ComponentModel.DataAnnotations;

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
    public int Precio { get; set; }

    [Required(ErrorMessage = " Campo obligatorio")]
    public int Vendido { get; set; }


}
