using healthTracker.Authentication;
using healthTracker.Config;
using healthTracker.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HealthTrackerContext>(options =>
    options.UseSqlite(ConfigurationExtensions.GetConnectionString(builder.Configuration, "HealthTrackerConnection")));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IBodyFatRepo, BodyFatRepo>();
builder.Services.AddScoped<IWeightRepo, WeightRepo>();
builder.Services.AddScoped<IHeightRepo, HeightRepo>();
builder.Services.AddScoped<ISleepRepo, SleepRepo>();

builder.Services.AddOptions();
builder.Services.Configure<HealthTrackerOptions>(
    builder.Configuration.GetSection(HealthTrackerOptions.ConfigName));

builder.Services.AddAuthentication().AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("Email"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
