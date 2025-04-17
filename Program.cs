﻿using Aesthetica.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Bind email settings
builder.Services.Configure<EmailSettings>(
builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddScoped<UserService>();   // User Services
builder.Services.AddScoped<EmailService>();  // Email Services

// Add session services
builder.Services.AddDistributedMemoryCache(); // ✅ Required for session storage
builder.Services.AddSession(); // ✅ Enable session services

builder.Services.AddControllersWithViews(); // Keep your existing services


builder.Services.Configure<RazorpayOptions>(builder.Configuration.GetSection("Razorpay"));


// Add services to the container.
builder.Services.AddControllersWithViews();

// Register AppDbContext with MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21)))); // UseMySql instead of UseMySQL


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

//app.UseAuthorization();

// Enable session middleware
app.UseSession(); // ✅ Add this before `app.UseAuthorization()`

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
