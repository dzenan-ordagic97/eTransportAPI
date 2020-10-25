using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Helpers;
using eTransport.WebAPI.Services;
using eTransport.WebAPI.Services.Auth;
using eTransport.WebAPI.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace eTransport.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddCors();
            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
                c.CustomSchemaIds(x => x.FullName);
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/chat")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddHttpContextAccessor();
            services.AddDbContext<eTransportContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("local")));
            services.AddIdentity<User, IdentityRole<int>>()
               .AddEntityFrameworkStores<eTransportContext>()
               .AddDefaultTokenProviders();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApplicationUser, ApplicationUserService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICRUDService<Model.VehicleType,Model.VehicleType,Model.VehicleType, Model.VehicleType>,VehicleTypeService>();
            services.AddScoped<ICRUDService<Model.VehicleModel, Model.VehicleModel, Model.VehicleModel, Model.VehicleModel>, VehicleModelService>();
            services.AddScoped<ICRUDService<Model.VehicleDetails, Model.VehicleDetails, Model.VehicleDetails, Model.VehicleDetails>, VehicleDetailsService>();
            services.AddScoped<ICRUDService<Model.ExtraServices, Model.Requests.ExtraServicesSearchRequest, Model.Requests.ExtraServicesInsertRequest, Model.Requests.ExtraServicesInsertRequest>, ExtraServicesService>();
            services.AddScoped<ICRUDService<Model.Vehicle, Model.Requests.VehicleSearchRequest, Model.Requests.VehicleInsertRequest, Model.Requests.VehicleInsertRequest>, VehicleService>();
            services.AddScoped<ICRUDService<Model.Carrier, Model.Requests.CarrierSearchRequest, Model.Carrier, Model.Requests.CarrierInsertRequest>, CarrierService>();
            services.AddScoped<ICRUDService<Model.Country, Model.Country, Model.Requests.CountryInsertRequest, Model.Requests.CountryInsertRequest>, CountryService>();
            services.AddScoped<ICRUDService<Model.City, Model.Requests.CitySearchRequest, Model.Requests.CityInsertRequest, Model.Requests.CityInsertRequest>, CityService>();
            services.AddScoped<ICRUDService<Model.CargoReservation, Model.Requests.CargoReservationSearchRequest, Model.Requests.CargoReservationInsertRequest, Model.Requests.CargoReservationInsertRequest>, CargoReservationService>();
            services.AddScoped<ICRUDService<Model.Freight, Model.Requests.FreightSearchRequest, Model.Freight, Model.Requests.FreightInsertRequest>, FreightService>();
            services.AddScoped<ICRUDService<Model.CommentRating, Model.Requests.CommentRatingSearchRequest, Model.CommentRating, Model.CommentRating>, CommentRatingService>();
            services.AddScoped<ICRUDService<Model.Client, Model.Requests.ClientSearchRequest, Model.Client, Model.Requests.ClientInsertRequest>, ClientService>();
            services.AddScoped<ICRUDService<Model.Cargo, Model.Requests.CargoSearchRequest, Model.Requests.CargoInsertRequest, Model.Requests.CargoInsertRequest>, CargoService>();
            services.AddScoped<ICRUDService<Model.RatingCarrier, Model.RatingCarrier, Model.Requests.RatingCarrierInsertRequest, Model.RatingCarrier>, RatingCarrierService>();
            services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
            services.AddScoped<ICRUDService<Model.MessageHeader, Model.Requests.MessageHeaderSearchRequest, Model.Requests.MessageHeaderInsertRequest, Model.Requests.MessageHeaderInsertRequest>, MessageHeaderService>();
            services.AddScoped<ICRUDService<Model.Message, Model.Message, Model.Message, Model.Message>, MessageService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API eTransport");
            });

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapControllers();
            });
        }
    }
}
