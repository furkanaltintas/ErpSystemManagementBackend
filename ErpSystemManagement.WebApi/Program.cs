using ErpSystemManagement.Application;
using ErpSystemManagement.Persistence;
using ErpSystemManagement.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddPresentationServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddOpenApi();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
