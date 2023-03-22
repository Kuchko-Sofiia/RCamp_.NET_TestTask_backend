using ReenbitCamp_TestTask_backend.Extensions;
using ReenbitCamp_TestTask_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureApplication();

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerServices();
builder.Services.AddCustomServices();

// Build the app.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
