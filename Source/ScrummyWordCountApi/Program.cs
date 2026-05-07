using ScrummyWordCountApi.Config;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

if(builder.Environment.IsDevelopment())
    builder.Configuration.AddUserSecrets<Program>();

builder.ConfigureDatabase();

builder.AddCors();

builder.AddDependencies();

var app = builder.Build();

app.MapGet("/", () => "It's alive!");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseOpenApi();

app.UseHttpsRedirection();

app.Run();