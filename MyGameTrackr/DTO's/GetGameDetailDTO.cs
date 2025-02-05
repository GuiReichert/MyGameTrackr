using MyGameTrackr.Models.RAWG_API_Models;

namespace MyGameTrackr.DTO_s
{
    public class GetGameDetailDTO
    {
            public int id { get; set; }
            public string name { get; set; }
            public string website { get; set; }
            public Parent_Platforms[] parent_platforms { get; set; }
            public Store[] stores { get; set; }
            public Developer[] developers { get; set; }
            public Genre[] genres { get; set; }
            public string description_raw { get; set; }
        }

}
