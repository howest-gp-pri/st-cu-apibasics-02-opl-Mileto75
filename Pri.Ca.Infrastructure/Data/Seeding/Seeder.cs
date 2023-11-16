using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.Ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var publishers = new Publisher[]
                {
                    new Publisher {Id = 1,Name = "Square Enix"},
                    new Publisher {Id = 2,Name = "EA"},
                };
            var games = new Game[]
            {
                new Game { Id = 1,Title="Final Fantasy", PublisherId=1, Description="Rpg classic"},
                new Game { Id = 2,Title="Fifa20",PublisherId=2,Description="Cool soccer game"},
            };
            var genres = new Genre[]
            {
                new Genre{Id = 1, Name = "Rpg" },
                new Genre{Id = 2, Name = "Sports" },
                new Genre{Id = 3, Name = "Fantasy" },
                new Genre{Id = 4, Name = "Adventure" },
            };
            //many to many
            var gamesGenres = new[]
            {
                new {GamesId = 1, GenresId = 1 },
                new {GamesId = 1, GenresId = 3 },
                new {GamesId = 1, GenresId = 4 },
                new {GamesId = 2, GenresId = 2 },
                new {GamesId = 2, GenresId = 3 },
            };
            //users seeden
            var admin = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@games.com",
                NormalizedUserName = "ADMIN@GAMES.COM",
                Email = "admin@games.com",
                NormalizedEmail = "ADMIN@GAMES.COM",
                SecurityStamp = new Guid().ToString(),
                ConcurrencyStamp = new Guid().ToString(),
                Firstname = "Bart",
                Lastname = "Soete",
            };
            var user = new ApplicationUser
            {
                Id = "2",
                UserName = "user@games.com",
                NormalizedUserName = "USER@GAMES.COM",
                Email = "user@games.com",
                NormalizedEmail = "USER@GAMES.COM",
                SecurityStamp = new Guid().ToString(),
                ConcurrencyStamp = new Guid().ToString(),
                Firstname = "Mileto",
                Lastname = "Di Marco",
            };
            //hash passwords
            IPasswordHasher<ApplicationUser> _hasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = _hasher.HashPassword(admin, "Test123");
            user.PasswordHash = _hasher.HashPassword(user, "Test123");
            //Seed roles as claims
            var userClaims = new IdentityUserClaim<string>[]
            {
                new IdentityUserClaim<string>{Id = 1,UserId = admin.Id,ClaimType = ClaimTypes.Role,ClaimValue = "Admin"},
                new IdentityUserClaim<string>{Id = 2,UserId = user.Id,ClaimType = ClaimTypes.Role,ClaimValue = "User"},
                new IdentityUserClaim<string>{Id = 3,UserId = admin.Id,ClaimType = ClaimTypes.NameIdentifier,ClaimValue = admin.Id},
                new IdentityUserClaim<string>{Id = 4,UserId = user.Id,ClaimType = ClaimTypes.NameIdentifier,ClaimValue = user.Id},
            };
            //modelbuilder
            modelBuilder.Entity<Publisher>().HasData(publishers);
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity($"{nameof(Game)}{nameof(Genre)}").HasData(gamesGenres);
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser[] { admin, user });
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(userClaims);
        }
    }
}
