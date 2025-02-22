using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyGameTrackr;
using MyGameTrackr.Database;
using MyGameTrackr.Services;

namespace MyGameTrackr___UnitTests.UnitTests.ControllerTests.LibraryController
{
    public class LibraryControllerUnitTests
    {
        public LibraryServices libraryServices;
        public IMapper mapper;
        public static DbContextOptions<MyGameTrackr_Context> dbContextOptions { get; }

        public static string connectionString = "Server = GUILHERME\\SQLEXPRESS; Database=MyGameTrackr; Trusted_Connection=true; TrustServerCertificate=true;";

        static LibraryControllerUnitTests()         // static constructor
        {
            dbContextOptions = new DbContextOptionsBuilder<MyGameTrackr_Context>().UseSqlServer(connectionString).Options;
        }

        public LibraryControllerUnitTests()         // constructor
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(new AutoMapperProfile());
            });


            var dbContext = new MyGameTrackr_Context(dbContextOptions);
            mapper = config.CreateMapper();
        }

    }
}
