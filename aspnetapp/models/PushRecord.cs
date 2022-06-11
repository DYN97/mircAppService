namespace aspnetapp.models
{
    public class PushRecord
    {
        public int Id { get; set; }
        public int Movie_Id { get; set; }
        public int Relationship_Id { get; set; }
        public DateTime Create_Time { get; set; }
        public string? Other { get; set; }
    }
}
