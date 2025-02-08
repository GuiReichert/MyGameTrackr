using System.Text.Json.Serialization;

namespace MyGameTrackr.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GameState
    {
        Wishlist = 1, Purchased, Dropped , Played
    }
}
