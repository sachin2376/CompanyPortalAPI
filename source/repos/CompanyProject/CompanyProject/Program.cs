using CompanyProject.DataModels;
using CompanyProject.Repository;
using CompanyProject.Repository.Interfaces;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<CompanyDbContext>();
builder.Services.AddCors(
    (options) => options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "PUT", "POST", "DELETE");
    })
);
builder.Services.AddFluentValidation(fm => fm.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddTransient<ICompanyRepo, CompanyRepo>();
builder.Services.AddTransient<IClientRepo, ClientRepo>();
builder.Services.AddTransient<IProjectRepo, ProjectRepo>();
builder.Services.AddTransient<IEmpRepo, EmpRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
