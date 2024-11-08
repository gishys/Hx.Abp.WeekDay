using Hx.Abp.WeekDay;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
// Add services to the container.
await builder.AddApplicationAsync<HxAbpWeekDayApiModule>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//app.MapControllers();

await app.InitializeApplicationAsync();
await app.RunAsync();
