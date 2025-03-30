using DarkOnix.Identidade.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerConfiguration();
builder.Services.AddIdentityConfiguration(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwaggerConfiguration();
app.UseIdentityConfiguration();
app.UseEndpointConfiguration();

await app.RunAsync();
