using System.ComponentModel.DataAnnotations;

namespace LiamellCruz_Ap1_P2.Models;

public class ComboDetalle
{
    [Key]

    public int ComboDetalleId { get; set; }
    public int ComboId { get; set; }
    public int ArticuloId { get; set; }
    public int Cantidad { get; set; }


}
