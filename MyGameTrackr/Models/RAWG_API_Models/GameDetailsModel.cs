namespace MyGameTrackr.Models.RAWG_API_Models
{

    public class GameDetailsModel
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string name_original { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public Platform[] platforms { get; set; }
        public Store[] stores { get; set; }
        public Developer[] developers { get; set; }
        public Genre[] genres { get; set; }
        public Tag[] tags { get; set; }
        public string description_raw { get; set; }
    }


    public class Platform
    {
        public string name { get; set; }
    }
    public class Store
    {
        public string name { get; set; }
    }

    public class Developer
    {
        public string name { get; set; }
    }

    public class Genre
    {
        public string name { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
    }



}
