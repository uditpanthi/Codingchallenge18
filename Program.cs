using Codingchallenge.Interfaces;
using Codingchallenge.Repositories;
using Codingchallenge.Services;
using Microsoft.EntityFrameworkCore;
using PracticeTest.Context;
using System.Text.Json.Serialization;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers().AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        opts.JsonSerializerOptions.WriteIndented = true;
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    builder.Services.AddCors(options =>
    {
        options.AddPolicy("ReactPolicy", opts =>
        {
            opts.WithOrigins("http://localhost:3000", "null").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
        });
    });


    builder.Services.AddDbContext<ChallengeContext>(opts =>
    {
        opts.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString"));
    });
    #region Repository
    builder.Services.AddScoped<BooksRepository>();


    #endregion

    #region Services
    builder.Services.AddScoped<IBooksService, BooksService>();


    var app = builder.Build();
    #endregion



    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors("ReactPolicy");
    app.UseAuthentication();
    app.UseAuthorization();


    app.MapControllers();

    app.Run();