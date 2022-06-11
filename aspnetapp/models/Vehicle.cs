using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
namespace aspnetapp.models
{
    public class Vehicle
    {
        public int Id { get; set; }
        
        public string? Brand_Name { get; set; }
        public string? Production_Name { get; set; }
        public string? Mileage { get; set; }
        public string? License_Plate { get; set; }
        public int Is_Deleted { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
        [Column("customer_id")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
