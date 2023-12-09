using Microsoft.Extensions.Hosting;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Kubernetes;
using Ocelot.Provider.Polly;
using OrderProcessing.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var routes = "";
#if DEBUG
    routes = "Routes.development";
#else
routes = "Routes";
#endif
;

//if (builder.Environment.IsDevelopment())
//{
//    routes = "Routes.development";
//}

builder.Configuration.AddOcelotWithSwaggerSupport(options =>
{
    options.Folder = routes;
});


builder.Services.AddOcelot(builder.Configuration).AddPolly();
builder.Services.AddSwaggerForOcelot(builder.Configuration);



builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.local.json", optional: true, reloadOnChange: true)
    //.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    //.AddOcelot("Routes", builder.Environment)
    .AddOcelot(routes, builder.Environment)
    .AddEnvironmentVariables();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerForOcelotUI(options =>
{
    //string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
    //options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "My API");
    //options.SwaggerEndpoint($"{swaggerJsonBasePath}/customer/swagger/v1/swagger.json", "OrderProcessing.Customer");
    //options.SwaggerEndpoint($"{swaggerJsonBasePath}/product/swagger/v1/swagger.json", "OrderProcessing.Product");
    //options.DownstreamSwaggerEndPointBasePath = "/swagger/docs";
    options.PathToSwaggerGenerator = "/swagger/docs";
    options.ReConfigureUpstreamSwaggerJson = AlterUpstream.AlterUpstreamSwaggerJson;

}).UseOcelot().Wait();

app.MapControllers();

app.Run();




