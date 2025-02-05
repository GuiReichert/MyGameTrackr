using System.Text.Json.Serialization;

namespace MyGameTrackr.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GameState
    {
        Wishlist, Purchased, Dropped , Played,
    }
}
