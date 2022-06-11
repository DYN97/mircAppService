namespace aspnetapp.models
{
    public class CustomerRequest
    {
        public string? CustomerId { get; set; }
        public string? MerchantId { get; set; }
        public string? Mobile { get; set; }
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
