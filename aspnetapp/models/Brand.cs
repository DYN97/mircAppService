using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetapp.models
{
    public class Brand
    {
        public int Id { get; set; }
        [Column("brand_name")]
        public string? BrandName { get; set; }
    }
}
