using ReactApp1.Server.Services; // Servislerinin olduðu klasör

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<MusteriServis>();
builder.Services.AddScoped<UrunServis>();
builder.Services.AddScoped<SiparisServis>();


// --- 2. CORS AYARLARI (React ile konuþma izni) ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactIzin", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5174") // React'ýn adresi
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- 3. ARA KATMANLAR (Middleware) ---

app.UseDefaultFiles();
app.UseStaticFiles();

// Geliþtirme modundaysak Swagger'ý aç
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactIzin"); // Ýzni devreye sok
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Þefleri (Controller) haritala
app.MapFallbackToFile("/index.html");

app.Run(); // Motoru çalýþtýr