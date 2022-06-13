using System.ComponentModel.DataAnnotations;

namespace aspnetapp.models
{
    public class CustomerRequest
    {
        [Required(ErrorMessage = "Please enter the user's merchant_id.")]
        public string merchant_id { get; set; }
        [Required(ErrorMessage = "Please enter a mobile.")]
        public string mobile { get; set; }
    }
    public class VehicleRequest 
    {
        public int? VehicleId { get; set; }
        public string? BrandName { get; set; }
        public string? ProductionName { get; set; }
        public string? Mileage { get; set; }
        public string? LicensePlate { get; set; }
    }
}
