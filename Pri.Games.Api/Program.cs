using Pri.Ca.Core.Interfaces.Repositories;
using Pri.Ca.Core.Interfaces;
using Pri.Ca.Core.Services;
using Pri.Ca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Pri.Ca.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Pri.Ca.Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

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
            //Add Authentication
            builder.Services.AddAuthentication(options
               =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = builder.Configuration["JWTConfiguration:Audience"],
                ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"],
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SigninKey"])),
            });
            builder.Services.AddAuthorization(options =>
            {
                //define policies
                //user policy
                options.AddPolicy("User", policy
                    => policy.RequireAssertion(context =>
                    {
                        //must be user or admin
                        //check if claims are present
                        //if == 0 => no token provided
                        if(context.User.Claims.Count() == 0)
                        {
                            return false;
                        }
                        var role = context
                        .User
                        .Claims
                        .FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role));
                        if (role.Value.Equals("User") || role.Value.Equals("Admin"))
                            return true;
                        return false;
                    }));
                //admin policy
                options.AddPolicy("Admin", policy
                    => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("NotUser", policy => policy.RequireAssertion(
                    context => 
                    {
                        //perform specific checks
                        var role = context
                        .User
                        .Claims
                        .FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role));
                        if(role.Value.Equals("User"))
                        {
                            return false;
                        }
                        return true;
                    }
                    ));
            });
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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}