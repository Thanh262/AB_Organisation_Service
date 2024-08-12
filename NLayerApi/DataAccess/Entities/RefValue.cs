using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class RefValue
{
    [Key]
    public int RefValueId { get; set; }

    [Required]
    public string Value { get; set; }
    
    public int RefCodeId { get; set; }
    
    [ForeignKey("RefCodeId")]
    public RefCode RefCode { get; set; }
}