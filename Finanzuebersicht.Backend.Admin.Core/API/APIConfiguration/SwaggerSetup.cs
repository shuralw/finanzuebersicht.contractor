using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.API.APIConfiguration
{
    public static class SwaggerSetup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SchülerOnline.Admin.Core - Swagger API Dokumentation",
                    Version = "v1"
                });

                swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer eyJhbGciOi...')",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });

                swaggerGenOptions.EnableAnnotations();

                swaggerGenOptions.OrderActionsBy(apiActionDesc => apiActionDesc.RelativePath);
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}