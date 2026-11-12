using MusicRecords.Api;

var builder = WebApplication.CreateBuilder(args);
var frontendOrigin = builder.Configuration["FrontendOrigin"] ?? "http://localhost:5500";

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new MusicRecordRepository());
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.WithOrigins(frontendOrigin).WithMethods("GET"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.MapControllers();

app.Run();
