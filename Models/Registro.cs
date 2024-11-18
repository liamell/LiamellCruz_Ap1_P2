using System.ComponentModel.DataAnnotations;

namespace LiamellCruz_Ap1_P2.Models;

public class Registro
{
    [Key]
    public int id{ get; set; }
    public int MyProperty1 { get; set; }
    public int MyProperty2 { get; set; }
    public int MyProperty3 { get; set; }
}
