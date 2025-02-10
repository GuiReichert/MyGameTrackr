namespace MyGameTrackr.Models.RAWG_API_Models
{

    public class GameDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public Parent_Platforms[] parent_platforms { get; set; }
        public Store[] stores { get; set; }
        public Developer[] developers { get; set; }
        public Genre[] genres { get; set; }
        public string description_raw { get; set; }
    }

    public class Parent_Platforms
    {
        public Platform platform { get; set; }
    }

    public class Platform
    {
        public string name { get; set; }
    }
    public class Store
    {
        public Store1 store { get; set; }
    }

    public class Store1
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



}
