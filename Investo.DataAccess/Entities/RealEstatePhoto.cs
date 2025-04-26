namespace Investo.DataAccess.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("real_estate_photos")]
public class RealEstatePhoto : AbstractEntity<int>
{
    [Column("real_estate_id")]
    [ForeignKey(nameof(RealEstate))]
    public int RealEstateId { get; set; }
    
    public RealEstate RealEstate { get; set; }
    
    [Column("url")]
    public string Url { get; set; } = string.Empty;
}