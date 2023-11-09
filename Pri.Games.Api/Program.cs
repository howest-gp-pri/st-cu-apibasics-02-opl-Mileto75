using Pri.Ca.Core.Interfaces.Repositories;
using Pri.Ca.Core.Interfaces;
using Pri.Ca.Core.Services;
using Pri.Ca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Pri.Ca.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Pri.Ca.Core.Entities;

namespace Pri.Games.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("GamesDb"))
                );
            //register Identityservice
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    //only for development/testing purposes
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 4;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedAccount = false;
                }
                )
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IGameService, GameService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}