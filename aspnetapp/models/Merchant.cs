namespace aspnetapp.models
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Open_id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public int Mobile { get; set; }        
        public string? Qrcode_Url { get; set; }
        public string? Address { get; set; }
        public string? Introduction { get; set; }
        public string? Longtiude { get; set; }
        public string? Latitude { get; set; }
        public DateTime Update_Time { get; set; }        
        public DateTime Create_time { get; set; }
    }
}
