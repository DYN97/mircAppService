namespace aspnetapp.models
{
    public class Relationship
    {
        public int Id { get; set; }
        public int Merchant_Id { get; set; }
        public int Customer_Id { get; set; }
        public int Status { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
    }
}
