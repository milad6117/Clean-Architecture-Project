using Microsoft.EntityFrameworkCore;
using Trial.Data.Context;
using Trial.Data.Repositories;
using Trial.Framework.Infrastructure.Extension;
using Trial.Service.Catalog.customerService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationServices(builder.Configuration);
var app = builder.Build();
app.ConfigureRequestPipeline();
app.Run();
