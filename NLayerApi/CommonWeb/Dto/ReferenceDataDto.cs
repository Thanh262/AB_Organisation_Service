using DataAccess.Entities;

namespace Common.Dto;

public class ReferenceDataDto
{
    public string Code { get; set; }
    public List<RefValueDto> RefValues { get; set; }
}