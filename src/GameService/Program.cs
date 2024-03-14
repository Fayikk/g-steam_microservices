    using GameService.Data;
    using GameService.Model;
    using GameService.Services.CategoryServices;
    using GameService.Services.GameServices;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddDbContext<GameDbContext>(opt => {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    builder.Services.AddScoped<ICategoryService,CategoryService>();
    builder.Services.AddScoped<IGame_Service,Game_Service>();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddMassTransit(x=>{

        x.AddEntityFrameworkOutbox<GameDbContext>(o=>{
            o.QueryDelay = TimeSpan.FromSeconds(10);
        
            o.UsePostgres();

            o.UseBusOutbox();
        
        });

        // x.AddConsumersFromNamespaceContaining<AuctionCreatedFaultConsumer>();
        x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("game",false));

        x.UsingRabbitMq((context,cfg) => {
            cfg.ConfigureEndpoints(context);
        });
    });




    builder.Services.AddScoped(typeof(BaseResponseModel));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();


    try
    {
        DbInitializer.InitDb(app);
    }
    catch (System.Exception ex)
    {
        Console.WriteLine(ex);
        throw;
    }

    app.Run();
