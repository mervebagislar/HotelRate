# 🏨 HotelRate - Otel Değerlendirme Platformu

ASP.NET Core MVC ile geliştirilmiş dinamik otel anket ve değerlendirme web uygulaması. Kullanıcılar otelleri değerlendirebilir, sistem ise bu değerlendirmeleri analiz ederek detaylı istatistikler sunar.

![HotelRate Banner](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/bannerIcon.png)



## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Teknolojiler](#-teknolojiler)
- [Kurulum](#-kurulum)
- [Kullanım](#-kullanım)
- [Proje Yapısı](#-proje-yapısı)
- [Veritabanı](#-veritabanı)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Katkıda Bulunma](#-katkıda-bulunma)

## ✨ Özellikler

### 🎯 Temel Özellikler
- **Dinamik Otel Listesi**: Veritabanından çekilen otellerin listelenmesi
- **Anket Sistemi**: Her otel için özelleştirilmiş anket soruları
- **Kullanıcı Yönetimi**: Session tabanlı kullanıcı takibi
- **Resim Galerisi**: Swiper.js ile otel resimlerinin gösterilmesi

### 📊 İstatistik Sistemi
- **Dinamik İstatistikler**: Tüm veriler veritabanından çekilir (static değer yok)
- **Otel Bazlı Analiz**: Her otel için ayrı istatistikler
- **Soru Bazlı Detaylar**: Her soru için ortalama puan ve cevap dağılımı
- **Görselleştirme**: Chart.js ile interaktif grafikler
- **Cevap Dağılımı**: 1-5 puan arası detaylı dağılım analizi

### 🎨 UI/UX Özellikleri
- **Dark Mode Uyumlu**: Modern ve göz yormayan tema
- **Responsive Tasarım**: Tüm cihazlarda uyumlu çalışır
- **Accordion Yapısı**: Detaylı bilgiler için açılır/kapanır bölümler
- **Eşit Resim Boyutları**: Tüm otel resimleri aynı boyutta gösterilir
- **Hata Yönetimi**: Resim yükleme hatalarında otomatik fallback

## 🛠 Teknolojiler

### Backend
- **ASP.NET Core 8.0** - Web framework
- **Entity Framework Core 8.0.11** - ORM
- **SQL Server** - Veritabanı
- **C#** - Programlama dili

### Frontend
- **Razor Pages / MVC** - View engine
- **Bootstrap 5** - CSS framework
- **Chart.js 4.4.0** - Grafik kütüphanesi
- **Swiper.js 8.4.7** - Slider kütüphanesi
- **AOS (Animate On Scroll)** - Animasyon kütüphanesi
- **GLightbox** - Lightbox kütüphanesi

### Mimari
- **Clean Code Principles** - Temiz kod prensipleri
- **ViewModel/DTO Pattern** - Veri transfer nesneleri
- **Service Layer** - İş mantığı katmanı
- **Dependency Injection** - Bağımlılık enjeksiyonu

## 🚀 Kurulum

### Gereksinimler
- .NET 8.0 SDK veya üzeri
- SQL Server 2019 veya üzeri
- Visual Studio 2022 veya VS Code (opsiyonel)

### Adım 1: Projeyi Klonlayın
```bash
git clone https://github.com/mervebagislar/HotelRate.git
cd HotelRate
```

### Adım 2: Veritabanı Yapılandırması
1. SQL Server'ı başlatın
2. `appsettings.json` dosyasındaki connection string'i düzenleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=HotelRateDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Adım 3: Migration'ları Uygulayın
```bash
dotnet ef database update
```

### Adım 4: Projeyi Çalıştırın
```bash
dotnet run
```

Proje `http://localhost:5154` adresinde çalışacaktır.

## 📖 Kullanım

### Kullanıcı Akışı

1. **Giriş Sayfası**: Kullanıcı bilgilerini girerek sisteme giriş yapar
2. **Anasayfa**: Otel listesini görüntüler ve bir otel seçer
3. **Otel Detay**: Seçilen otelin resimlerini ve anket sorularını görüntüler
4. **Anket Doldurma**: Her soru için 1-5 arası puan verir
5. **İstatistikler**: Tüm otellerin istatistiklerini görüntüler

### İstatistik Sayfası Özellikleri

- **Genel Bakış**: Her otel için genel ortalama puan ve toplam cevap sayısı
- **Detaylı İstatistikler**: "Detaylı İstatistikleri Göster" butonu ile açılır
- **Soru Bazlı Analiz**: Her soru için ayrıntılı istatistikler (accordion yapısı)
- **Görselleştirme**: Chart.js ile cevap dağılım grafikleri

## 📁 Proje Yapısı

```
HotelRate/
├── Controllers/          # MVC Controllers
│   ├── AnasayfaController.cs
│   ├── IstatistikController.cs
│   ├── OtelAnketController.cs
│   └── ...
├── Models/              # Entity Models
│   ├── Cevap.cs
│   ├── Otel.cs
│   ├── Soru.cs
│   ├── HotelDbContext.cs
│   └── ViewModels/      # ViewModel ve DTO sınıfları
│       ├── OtelIstatistikViewModel.cs
│       ├── SoruIstatistikDTO.cs
│       └── CevapDagilimDTO.cs
├── Services/            # İş mantığı servisleri
│   └── IstatistikService.cs
├── Views/              # Razor Views
│   ├── Anasayfa/
│   ├── Istatistik/
│   ├── OtelAnket/
│   └── Shared/
├── wwwroot/            # Static dosyalar
│   ├── css/
│   ├── js/
│   ├── img/
│   └── vendor/
├── Migrations/         # EF Core Migrations
└── Program.cs          # Uygulama giriş noktası
```

## 🗄 Veritabanı

### Tablolar

#### Kullanicilar
- `Id` (PK)
- `Ad`, `Soyad`, `Email`
- `Cinsiyet`, `DogumTarihi`

#### Oteller
- `OtelId` (PK)
- `OtelAdi`
- `resim`

#### Sorular
- `SoruId` (PK)
- `Konu`
- `SoruMetni`

#### Cevaplar
- `CevapId` (PK)
- `Cevabi` (string - 1-5 arası puan)
- `KullanicilarId` (FK)
- `OtelId` (FK)
- `SoruId` (FK)

#### OtelResim
- `OtelResimId` (PK)
- `OtelId` (FK)
- `OtelResimYolu`

### İlişkiler
- Bir kullanıcı birden fazla cevap verebilir
- Bir otel birden fazla cevap alabilir
- Bir soru birden fazla cevaba sahip olabilir
- Bir otel birden fazla resme sahip olabilir

## 📸 Ekran Görüntüleri

### Giriş Sayfası
![Giriş Sayfası](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/login.png)

*Kullanıcı giriş ekranı*

### Anasayfa
![Anasayfa]([img/screenshots/](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/mainpage.png)
*Otel listesi ve resim galerisi*

![Anasayfa Detay](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/mainpage2.png)
*Otel kartları ve navigasyon*

### Anket Sayfaları
![Anket 1](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/anket1.png)
*Otel detay sayfası - Swiper.js ile resim galerisi*

![Anket 2](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/anket2.png)
*Anket soruları ve değerlendirme formu*

![Anket 3](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/anket3.png)
*Anket tamamlama ekranı*

![Anket Kontrol](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/anketcheck.png)
*Anket cevaplarının kontrolü*

### İstatistik Sayfası
![İstatistikler](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/istatistik.png)
*Genel istatistik görünümü*

![İstatistik Detay 1](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/istatistikdetay.png)
*Detaylı istatistikler ve grafikler*

![İstatistik Detay 2](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/istatistikdetay2.png)
*Chart.js ile cevap dağılım grafikleri*

### İletişim Sayfası
![İletişim](https://raw.githubusercontent.com/mervebagislar/HotelRate/main/HotelRate/wwwroot/img/screenshots/contact.png)
*İletişim formu ve bilgileri*

## 🎯 Özellik Detayları

### Dinamik İstatistik Sistemi

Sistem, veritabanındaki tüm cevapları analiz ederek:

- **Ortalama Puan Hesaplama**: Her otel ve soru için ortalama puan
- **Cevap Dağılımı**: 1-5 puan arası detaylı dağılım
- **Toplam Cevap Sayısı**: Her otel için toplam değerlendirme sayısı
- **Görselleştirme**: Chart.js ile interaktif bar grafikleri

### Clean Code Prensipleri

- ✅ **Service Layer**: İş mantığı servis katmanında
- ✅ **ViewModel/DTO**: View ve Controller'lar temiz
- ✅ **Dependency Injection**: Loose coupling
- ✅ **Tek Sorumluluk**: Her sınıf tek bir sorumluluğa sahip
- ✅ **DRY**: Kod tekrarı yok

## 🔧 Yapılandırma

### Connection String
`appsettings.json` dosyasında veritabanı bağlantı bilgilerini düzenleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=HotelRateDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Session Yapılandırması
Session yönetimi `Program.cs` içinde yapılandırılmıştır:
```csharp
builder.Services.AddSession();
app.UseSession();
```


## 👥 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## 📝 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## 👨‍💻 Geliştirici

**Ekip Adı**
- Proje Sahipleri: Merve Bağışlar, Beyza Atay
- Proje: HotelRate
- Versiyon: 2.0
- Framework: ASP.NET Core 8.0

## 📞 İletişim
Projenin videolu halini görmek için sitemi ziyaret edebilirsiniz: https://mervebagislar.com
Sorularınız için issue açabilir veya iletişim sayfasını kullanabilirsiniz.

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!
