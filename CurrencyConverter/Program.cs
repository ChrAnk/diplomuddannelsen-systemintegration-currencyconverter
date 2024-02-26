using CurrencyConverter.BusinessLogic;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSoapCore();
builder.Services.AddScoped<ICurrencyConverter, SoapService>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ICurrencyConverter>(
        path: "/Service.asmx",
        encoder: new SoapEncoderOptions(),
        serializer: SoapSerializer.XmlSerializer,
        caseInsensitivePath: true
    );
});

app.Run();
