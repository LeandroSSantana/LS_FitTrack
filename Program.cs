var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<IExercicioRepository, ExercicioRepository>();
builder.Services.AddTransient<ITreinoRepository, TreinoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
     name: "exercicio",
     pattern: "exercicio/{action}/{id?}",
     defaults: new { controller = "Exercicio" });


app.MapControllerRoute(
    name: "treino",
    pattern: "treino/{action}/{treinoId?}",
    defaults: new { controller = "Treino", Action = "Create" });
app.Run();

