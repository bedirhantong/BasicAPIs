var builder = WebApplication.CreateBuilder(args);

// Service(Container) 'a diyoruz ki biz Controller kullanacağız
builder.Services.AddControllers();
// Servisin Endpointleri keşfetmesini sağladık 
builder.Services.AddEndpointsApiExplorer();
/*
 Swagger başlattık ama boş bir proje olduğu için kabul etmedi, o yüzden sağdan projeye sağ tıkladık
        - Manage NuGet packages dedik.
        - browse sekmesinden swagger yazıp sonu UI,Gen ile biten 2 tanesini ekledik.
        - Sağdan Dependencies\Packages kısmından swagger'a bağımlı olduğumuzu 
        anlayabilirsin.
 */
builder.Services.AddSwaggerGen();
var app = builder.Build();

// uygulamadan swaggeri arayüzü ile kullanmasını istedik
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
