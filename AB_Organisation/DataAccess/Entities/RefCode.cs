using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class RefCode
{
    [Key]
    public int RefCodeId { get; set; }

    [Required]
    public string Code { get; set; }
    public ICollection<RefValue> RefValues { get; set; }
}