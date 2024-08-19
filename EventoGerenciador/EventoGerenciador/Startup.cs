using EventoGerenciador.CrossCutting.Assemblies;
using EventoGerenciador.CrossCutting.IoC;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using System.Text.Json.Serialization;

namespace EventoGerenciador.Api;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());
        services.AddDependencyResolver();

        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault);
        services.AddControllers();
        services.AddHealthChecks();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "gestao-evento-api", Description = "Api fazer a gestão de eventos", Version = "v1" });
        });


        services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
            options.EnableForHttps = true;
        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseHsts();

        app.UsePathBase("/gestao-evento-api");

        //if (Environment.GetEnvironmentVariable("AMBIENTE") != AMBIENTE_PRODUCAO)
        //{
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/gestao-evento-api/swagger/v1/swagger.json", "gestao-evento-api v1");
            });
       // }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseResponseCompression();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health");
        });

        var logger = app.ApplicationServices.GetService<ILogger<Program>>();
    }
}
