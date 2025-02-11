using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyGameTrackr.Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr.Database
{
    public class MyGameTrackr_Context : DbContext
    {
        public MyGameTrackr_Context(DbContextOptions<MyGameTrackr_Context> db) : base(db)
        {
            
        }

        public DbSet<User_Model> Users { get; set; }
        public DbSet<UserLibrary_Model> UserLibraries { get; set; }
        public DbSet<Game_Model> Games { get; set; }
        public DbSet<GameReview_Model> GameReviews { get; set; }





    }
}
