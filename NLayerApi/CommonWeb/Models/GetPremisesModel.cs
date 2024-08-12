using DataAccess.Entities;

namespace Common.Models;

public class GetPremisesModel
{
    public int PremiseId { get; set; } // Primary Key
    public string KnowAs { get; set; }
    public Address Address { get; set; }
    public bool PrimaryLocation { get; set; }
    public CompanyContact CompanyContact { get; set; }
}