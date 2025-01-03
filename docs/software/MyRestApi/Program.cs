
using Microsoft.EntityFrameworkCore;
using MyRestApi.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// ������ �������� ����� �� ���������� �����������
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 23))
    )
);
var app = builder.Build();

// ������������ Swagger � �������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





// ���� ������������
app.MapControllers();

app.Run();