using Gateway.Api.Extensions;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.ConfigureOcelot(builder); 
builder.Services.ConfigureJwt();
builder.Services.ConfigureApplicationInsights();

var app = builder.Build(); 
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
app.UseOcelot().Wait();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Logger.LogInformation("Starting Gateway Application");
app.Logger.LogInformation("ENVIRONMENT - " + builder.Environment.EnvironmentName);

app.Run();