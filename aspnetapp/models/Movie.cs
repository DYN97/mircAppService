namespace aspnetapp.models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Url { get; set; }
        public int Type { get; set; }
        public string? License_Plate { get; set; }
        public string? Auto_Brand { get; set; }
        public int Relationship_Id { get; set; }
        public int Like_Count { get; set; }
        public int Share_Count { get; set; }
        public string? Cover_Image { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
        public int Status { get; set; }
        public int Annex_Id { get; set; }
        public int Tag { get; set; }
        public int Play_Times { get; set; }
    }
}