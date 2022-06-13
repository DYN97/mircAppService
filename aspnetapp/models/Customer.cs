namespace aspnetapp.models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Open_id { get; set; }
        public string? Merchant_id { get; set; }
        public string? NickName { get; set; }
        public string? FullName { get; set; }
        public int Mobile { get; set; }        
        public string? Head_pic_url { get; set; }
        public int Share_times { get; set; }
        public DateTime Update_time { get; set; }        
        public DateTime Create_time { get; set; }
        public List<Vehicle> Vehicle { get; set; }
    }
}
