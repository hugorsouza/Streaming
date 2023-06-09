using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework.Configuration.DatabaseInitializer
{
    class DbInitializer : IDbInitializer
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public DbInitializer()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            #region CategorySeed

            var categories = new List<Category>
            {
                new () { Id = 1, Name = "Test Category" },
                new () {Id = 2, Name = "Action & Adventure"},
                new () {Id = 3, Name = "Comedy"},
                new () {Id = 4, Name = "Crime & Gangster"},
                new () {Id = 5, Name = "Drama"},
                new () {Id = 6, Name = "Epics/Historical/Perod"},
                new () {Id = 7, Name = "Horror"},
                new () {Id = 8, Name = "Musicals/Dance"},
                new () {Id = 9, Name = "Police"},
                new () {Id = 10, Name = "Western"}

            };
            modelBuilder.Entity<Category>().HasData(categories);
            #endregion

            #region MoviesSeed

            var Movies = new List<Movies>
            {
                new () { Id = 1, CategoryId = 1, Actor = "Test Actor", Director = "Director Test", Movie = "Movies Test", RunningTime = 195},
                new () { Id = 2, CategoryId = 2, Actor = "Chadwick Bosemam", Director = "Ryan Coogle", Movie = "Black Panther", RunningTime = 134},
                new () { Id = 3, CategoryId = 3, Actor = "Brother Wayans", Director = "Keenan Ivory Wayans", Movie = "White Chicks", RunningTime = 109},
                new () { Id = 4, CategoryId = 4, Actor = "50 Cent", Director = "Jim Sheridan", Movie = "Get Rich or Die Tryin", RunningTime = 117},
                new () { Id = 5, CategoryId = 5, Actor = "Leandro Firmino", Director = "Fernando Meirelles", Movie = "Cidade de Deus", RunningTime = 130},
                new () { Id = 6, CategoryId = 6, Actor = "Milton Gonçalves", Director = "Héctor Babenco", Movie = "Carandiru", RunningTime = 145},
                new () { Id = 7, CategoryId = 7, Actor = "Octavia Spencer", Director = "Tate Taylor", Movie = "Ma", RunningTime = 100},
                new () { Id = 8, CategoryId = 8, Actor = "Babu Santana", Director = "Mauro Lima", Movie = "Tim Maia", RunningTime = 185},
                new () { Id = 9, CategoryId = 9, Actor = "Wagner Moura", Director = "José Padilha", Movie = "Tropa de Elite", RunningTime = 115},
                new () { Id = 10, CategoryId = 10, Actor = "Jamie Foxx", Director = "Quentin Tarantino", Movie = "Django Unchained", RunningTime = 165}
            };
            modelBuilder.Entity<Movies>().HasData(Movies);
            #endregion

            #region SeriesSeed

            var Series = new List<Series>
            {
                new () { Id = 2, CategoryId = 2, Actor = "Logan Browning", Director = "Hartley Gorenstein", Serie = "The Boys", Seasons = 3, Streamings = "Prime Video"},
                new () { Id = 3, CategoryId = 3, Actor = "John C. Reilly", Director = "Max Borenstein", Serie = "Winning Time: The Rise of the Lakers Dynasty", Seasons = 1, Streamings = "HBO Max"},
                new () { Id = 4, CategoryId = 4, Actor = "Al Pacino", Director = "Francis Ford Coppola", Serie = "The Godfather", Seasons = 3, Streamings = "Prime Video"},
                new () { Id = 5, CategoryId = 5, Actor = "Seu Jorge", Director = "Pedro Morelli", Serie = "Irmandade", Seasons = 2, Streamings = "NetFlix"},
                new () { Id = 6, CategoryId = 6, Actor = "Merle Dandridge", Director = "Craig Wright", Serie = "GreenLeaf", Seasons = 5, Streamings = "NetFlix"},
                new () { Id = 7, CategoryId = 7, Actor = "Emma Booth", Director = "Not Available", Serie = "The Gloaming", Seasons = 1, Streamings = "HBO Max"},
                new () { Id = 8, CategoryId = 8, Actor = "Justice Smith", Director = "Baz Luhrmann", Serie = "The Get Down", Seasons = 2, Streamings = "NetFlix"},
                new () { Id = 9, CategoryId = 9, Actor = "Raphael Logam", Director = "Alexandre Fraga", Serie = "Impuros", Seasons = 2, Streamings = "Star +"},
                new () { Id = 10, CategoryId = 10, Actor = "Antonio Te Moioha", Director = "Not Available", Serie = "Spartacus", Seasons = 4, Streamings = "StarzPlay"}
            };
            modelBuilder.Entity<Series>().HasData(Series);
            #endregion

            #region UserSeed

            var users = new List<User>
            {
                new () { Id = 1, UserName = "admin", Email = "admin@test.com",  PasswordHash = _passwordHasher.HashPassword(null,"1234")},
                new () { Id = 2, UserName = "user", Email = "user@test.com",  PasswordHash = _passwordHasher.HashPassword(null,"1234")},
                new () { Id = 3, UserName = "employee", Email = "employee@test.com",  PasswordHash = _passwordHasher.HashPassword(null,"1234")}
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region RoleSeed

            var roles = new List<Role>
            {
                new () { Id = 1, Name = "admin" },
                new () { Id = 2, Name = "user" },
                new () { Id = 3, Name = "employee" }
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region UserRoleSeed

            var userRoles = new List<UserRole>
            {
                new () { UserId = 1, RoleId = 1 },
                new () { UserId = 1, RoleId = 2 },
                new () { UserId = 2, RoleId = 2 },
                new () { UserId = 3, RoleId = 3 }
            };
            modelBuilder.Entity<UserRole>().HasData(userRoles);
            #endregion
        }
    }
}
