using Microsoft.EntityFrameworkCore;
using PaymentSystem.DataLayer.EF;
using PaymentSystem.Helpers;

public partial class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddDbContext<PaymentSystemContext>(options =>
				options.UseInMemoryDatabase("TestDB2")
			);

		builder.Services.RegisterServices();
		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		builder.Services.AddControllers();
		builder.Services.AddLogging(config =>
		{
			config.ClearProviders();
			config.AddConsole();
			config.AddDebug();
		});
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(options =>
		{
			var basePath = AppContext.BaseDirectory;

			var xmlPath = Path.Combine(basePath, "PaymentSystem.xml");
			options.IncludeXmlComments(xmlPath);
		});

		var app = builder.Build();


		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.MapControllers();

		app.Run();
	}
}