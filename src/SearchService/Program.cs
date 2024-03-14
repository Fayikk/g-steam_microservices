using MassTransit;
using SearchService.Consumers;
using SearchService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(x=>{
    x.AddConsumersFromNamespaceContaining<GameCreatedConsumer>();
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("search",false));
    x.UsingRabbitMq((context,cfg) => {
        cfg.ReceiveEndpoint("search-game-created",e => {
            e.UseMessageRetry(r=>r.Interval(5,5));
            e.ConfigureConsumer<GameCreatedConsumer>(context);
        });
        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Lifetime.ApplicationStarted.Register(async () =>
{

try
{
    await DbInitializer.InitDb(app);
}
catch (System.Exception exception)
{
    Console.WriteLine(exception);
}
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
