namespace Investo.DataAccess.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("real_estate_types")]
public class RealEstateType : AbstractEntity<int>
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}