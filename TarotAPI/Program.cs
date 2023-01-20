using Microsoft.EntityFrameworkCore;
using TarotAPI.Context;
using TarotAPI.Services.Contract;
using TarotAPI.Services.Implementation;
using TarotAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Interface Scoped
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGuildService, GuildService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options => options.AddPolicy(name: "TarotOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    })
);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("tarotOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();