using Microsoft.EntityFrameworkCore;
using Personal_Store.Persistence.Contexts;
using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Application.Services.Users.Queries.GetUsers;
using Personal_Store.Application.Services.Users.Queries.GetRoles;
using Personal_Store.Application.Services.Users.Commands.RegisterUser;
using Personal_Store.Application.Services.Users.Commands.RemoveUser;
using Personal_Store.Application.Services.Users.Commands.UserStatusChange;
using Personal_Store.Application.Services.Users.Commands.UpdateUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();

const string connectionString = @"Data Source=DESKTOP-S73DE26\MSSQLSERVER2022; Initial Catalog=PersonalStoreDb; Integrated Security=True;";
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.Run();
