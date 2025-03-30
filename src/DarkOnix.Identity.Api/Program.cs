using DarkOnix.Identity.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerConfiguration();
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddServicesConfiguration();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwaggerConfiguration();
app.UseIdentityConfiguration();
app.UseEndpointConfiguration();

await app.RunAsync();
