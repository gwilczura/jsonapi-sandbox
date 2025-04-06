using JsonApiDotNetCore.Configuration;
using Wilczura.Common.JsonApi.Repositories;
using Wilczura.Common.Ports.Repositories;
using Wilczura.JsonApiTest.Adapters.ServiceBus.Publishers;
using Wilczura.JsonApiTest.Common;
using Wilczura.JsonApiTest.Data;
using Wilczura.JsonApiTest.Data.Repositories;
using Wilczura.JsonApiTest.Extensions;
using Wilczura.JsonApiTest.JsonApi.Definitions;
using Wilczura.JsonApiTest.JsonApi.Repositories;
using Wilczura.JsonApiTest.JsonApi.Services;
using Wilczura.JsonApiTest.Ports.Publishers;
using Wilczura.JsonApiTest.Ports.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);
// Add services to the container.
var logger = builder.GetStartupLogger();
builder.AddPostgres(string.Empty,"products", logger);

builder.Services.AddTransient(typeof(GregControllerDependencies<,>));
builder.Services.AddTransient(typeof(GregRepositoryDependencies));
builder.Services.AddTransient<IOutboxRepository, OutboxRepository>();
builder.Services.AddScoped<IDbContextProvider, DbContextProvider>();
builder.Services.AddScoped<IEntityChangedPublisher, EntityChangedPublisher>();
//builder.Services.AddTransient(typeof(GregController<,>));

builder.Services.AddJsonApi<TestDbContext>();
builder.Services.AddResourceService<PersonResourceService>();
builder.Services.AddResourceRepository<PersonResourceRepository>();
builder.Services.AddResourceDefinition<PersonResourceDefinition>();
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
