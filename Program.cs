using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using News___WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("NewsDb");//anahtarı yakala
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();//uç noktaları keşfet
// Swagger için gerekli servisleri ekliyoruz.
// AddSwaggerGen(), API endpoint'lerimizi analiz ederek
// Swagger/OpenAPI dokümanı oluşturur.
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        // Swagger sayfasında API'nin adı olarak görünür.
        Title = "Haberler API",

        // API dokümanının versiyonunu belirtir.
        // Buradaki "v1", API'mizin 1. versiyonu anlamına gelir.
        Version = "v1",

        // Swagger sayfasında API hakkında açıklama gösterir.
        Description = "Haberler için Swagger Belgesi"
    }
));

// OpenAPI desteğini uygulamaya ekler.
// OpenAPI, API'nin endpoint'lerini, modellerini,
// istek ve cevaplarını standart bir formatta tanımlamak için kullanılır.
builder.Services.AddOpenApi();
builder.Services.AddDbContext<NewsDbContext>(options=>options.UseSqlServer(connectionString));//yakalanan anahtarı sqlserverı kullanmak için options üzerinden kullan
builder.Services.AddScoped<INewsRepository,NewsRepository>();//ınewrepo istendiği zaman newsrepository nesnesinin referans alınmasını sağla
var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var dbContex = scope.ServiceProvider.GetRequiredService<NewsDbContext>();
    dbContex.Database.Migrate();

}
// HTTP request pipeline (istek işlem hattı) burada yapılandırılıyor.

// Uygulamanın Development ortamında olup olmadığını kontrol eder.
// Yani aşağıdaki Swagger ayarları sadece geliştirme ortamında çalışır.
if (app.Environment.IsDevelopment())
{
    // Swagger'ın oluşturduğu OpenAPI/JSON dokümanını
    // uygulama üzerinden erişilebilir hale getirir.
    app.UseSwagger();

    // Swagger UI'ı aktif eder.
    // Tarayıcıdan API endpoint'lerini görmemizi ve
    // doğrudan test etmemizi sağlar.
    app.UseSwaggerUI(options =>
    {
        // Swagger UI'ın hangi Swagger JSON dosyasını kullanacağını belirtir.
        //
        // "swagger/v1/swagger.json"
        //     -> Swagger dokümanının adresi
        //
        // "Haberler API v1"
        //     -> Swagger UI'da bu dokümana verilecek görünen isim
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Haberler API v1"
        );
    });

    // OpenAPI dokümanını endpoint olarak yayınlar.
    // Böylece OpenAPI dokümanına uygulama üzerinden erişilebilir.
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
