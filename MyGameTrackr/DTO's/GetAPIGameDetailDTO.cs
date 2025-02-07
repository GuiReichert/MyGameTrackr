using MyGameTrackr.Models.RAWG_API_Models;

namespace MyGameTrackr.DTO_s
{
    public class GetAPIGameDetailDTO
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Website { get; set; }
            public Parent_Platforms[] Parent_platforms { get; set; }
            public Store[] Stores { get; set; }
            public Developer[] Developers { get; set; }
            public Genre[] Genres { get; set; }
            public string Description_raw { get; set; }
        }

}
