using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Repository;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

        var builder = WebApplication.CreateBuilder(args);

      
        builder.Services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        
        builder.Services.AddScoped<BookRepository>();
        builder.Services.AddScoped<AuthorRepository>();
        builder.Services.AddScoped<GenreRepository>();


        builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy => policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
        });

        var app = builder.Build();

       
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    
