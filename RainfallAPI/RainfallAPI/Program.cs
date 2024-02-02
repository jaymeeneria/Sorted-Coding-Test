using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Version = "1.0",
            Title = "Rainfall Api",
            Description = "An API which provides rainfall reading data",
            Contact = new OpenApiContact
            {
                Name = "Sorted",
                Url = new Uri("https://www.sorted.com")
            },

        });


    options.AddServer(new OpenApiServer
    {
        Url = "http://localhost:3000",
        Description = "Rainfall Api"
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

app.UseAuthorization();
//app.MapControllerRoute(
//    name: "get-rainfall",
//    pattern: "{controller=Rainfall}/{action=id}/{stationId}?}/readings");
app.MapControllers();

app.Run();
