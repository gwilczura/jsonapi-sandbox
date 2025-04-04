using JsonApiDotNetCore.Configuration;
using Wilczura.JsonApiTest.Common;
using Wilczura.JsonApiTest.Data;
using Wilczura.JsonApiTest.Extensions;
using Wilczura.JsonApiTest.Repositories;
using Wilczura.JsonApiTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = builder.GetStartupLogger();
builder.AddPostgres(string.Empty,"products", logger);

builder.Services.AddTransient(typeof(GregControllerDependencies<,>));
//builder.Services.AddTransient(typeof(GregController<,>));

builder.Services.AddJsonApi<TestDbContext>();
builder.Services.AddResourceService<PersonResourceService>();
builder.Services.AddResourceRepository<PersonResourceRepository>();
builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseJsonApi();
app.MapControllers();

app.Run();
