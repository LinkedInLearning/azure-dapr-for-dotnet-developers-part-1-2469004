using WisdomPetMedicine.Pet.Api.ApplicationServices;
using WisdomPetMedicine.Pet.Api.Extensions;
using WisdomPetMedicine.Pet.Api.Infrastructure;
using WisdomPetMedicine.Pet.Domain.Repositories;
using WisdomPetMedicine.Pet.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPetDb(builder.Configuration);
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<PetApplicationService>();
builder.Services.AddScoped<IBreedService, FakeBreedService>();
builder.Services.AddControllers()
                .AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.EnsurePetDbIsCreated();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();