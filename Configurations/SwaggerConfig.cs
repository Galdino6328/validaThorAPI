﻿using System;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace validaThorAPI.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {

                 s.SwaggerDoc("v1", new OpenApiInfo { 
                     Version = "v1", Title = "ValidaThor API",
                     Description = "ValidaThor API Swagger surface",
                     Contact = new OpenApiContact 
                     { Name = "Thalyson Galdino", 
                     Email = "thalyson.galdino@gmail.com"}});

                // s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     Description = "Input the JWT like: Bearer {your token}",
                //     Name = "Authorization",
                //     Scheme = "Bearer",
                //     BearerFormat = "JWT",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.ApiKey
                // });

                // s.AddSecurityRequirement(new OpenApiSecurityRequirement
                // {
                //     {
                //         new OpenApiSecurityScheme
                //         {
                //             Reference = new OpenApiReference
                //             {
                //                 Type = ReferenceType.SecurityScheme,
                //                 Id = "Bearer"
                //             }
                //         },
                //         new string[] {}
                //     }
                // });

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}