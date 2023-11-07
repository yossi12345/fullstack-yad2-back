using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using yad2_back.Data;
using yad2_back.Models;
using yad2_back.Repositories;

namespace yad2_back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Yad2Context>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnectionString")));
            builder.Services.AddIdentity<UserModel, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            }).
                AddEntityFrameworkStores<Yad2Context>().
                AddDefaultTokenProviders().
                AddPasswordValidator<UserPasswordValidator>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });
            builder.Services.Configure<IdentityOptions>(opt=>
            {
                opt.Password.RequireUppercase= false;
                opt.Password.RequireDigit= true;
                opt.Password.RequireLowercase= false;
                opt.Password.RequireUppercase= false;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;

            });
            builder.Services.AddControllers().AddNewtonsoftJson(opt => { //כדי שכשאתה מבקש לראות ספר עם סופר ולסופר יש ספר ולספר יש סופר ולסופר יש ספר שלא ייכנס ללולאה אינסופית
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            builder.Services.AddTransient<IAuthRepository, AuthRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}