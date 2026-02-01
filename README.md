# Interaction System - [Ömer Turan]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.2.9f1 |
| Render Pipeline | Built-in |
| Case Süresi | 9 saat |
| Tamamlanma Oranı | %60 |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/TtayfunYildirim/InteractionSystem.git
```

2. Unity Hub'da projeyi açın
3. `Assets/InteractionSystem/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |

### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın, "Press E to Open" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:**
   - Switch'e yaklaşın ve aktive edin
   - Bağlı nesnenin (kapı/ışık vb.) tetiklendiğini görün

4. **Chest Test:**
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsın ve içindeki item alınsın

---

## Mimari Kararlar

### Interaction System Yapısı

```
Sistem, Interface-based Decoupling (Arayüz Tabanlı Ayrıştırma) prensibi üzerine kurulmuştur. Oyuncu (InteractionDetector) neyle etkileşime girdiğini bilmez sadece karşısındaki nesnenin IInteractable arayüzünü uygulayıp uygulamadığını kontrol eder.

Akış: Raycast -> Detect IInteractable -> UI Feedback -> Input (E) -> Execute Logic
```

**Neden bu yapıyı seçtim:**
> Sürdürülebilirlik ve Genişletilebilirlik: Sisteme yeni bir etkileşim türü (örneğin bir "NPC" veya "Işık") eklemek istediğimde, Player veya Detector sınıflarında tek bir satır kod değiştirmem gerekmez. Sadece IInteractable arayüzünü uygulayan yeni bir script oluşturmam yeterlidir. Bu, kodun kırılganlığını azaltır.

**Alternatifler:**
> Tag Kontrolü: İlk başta if (hit.tag == "Door") gibi basit kontrollerle tüm mantığı Player içinde toplamayı düşündüm. Neden Seçmedim: Projenin hem yapısı bozulurdu hem de okunabilirlik kesinlikle azalırdı.

**Trade-off'lar:**
> Avantaj: Tam modülerlik. Kapı scripti bozulsa bile Sandık scripti çalışmaya devam edecektir tabii ki ana problem IInterables'da değil ise durum öyleyse yine sorunun çözümü kolay olur çünkü hangi scripte bakmamız gerektiğini biliriz. Dezavantaj: Küçük projeler için başlangıç kurulumu biraz daha fazla zaman alır ve dosya sayısı artar. Dolayısıyla başlangıç oldukça yavaş ilerler.

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [Player Inventory - InvetoryUI] | [Envanter verisi değiştiğinde UI'ın otomatik güncellenmesi için ] |
| [State] | [Door states] | [Oyuncuya immersion verebilmek için değiştirilebilir ögeler öncelikli] |
---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [ ] | |
| s_ prefix (private static) | [x] / [ ] | |
| k_ prefix (private const) | [x] / [ ] | |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [ ] | M_Door_Wood |
| T_ prefix (Texture) | [x] / [ ] | |
| SO isimlendirme | [x] / [ ] | |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [ ] | |
| Pivot bottom-center | [x] / [ ] | |
| Collider tercihi | [x] / [ ] | Box > Capsule > Mesh |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> En çok zorlandığım alan alışması oldu. Açıkçası okunabilirlik konusunda kesinlike harika bir yöntem. Fakat bir alışma süreci olduğu da gerçek.

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [x] / [ ] Switch/Lever
  - [x] / [ ] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [x] / [ ] Hold progress bar
  - [] / [x] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [] / [x] UI listesi

### Bonus (Nice to Have)

- [x] Animation entegrasyonu
- [ ] Sound effects
- [x] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [x] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Cannot interact] - [Zaman yetişmezliği]
2. [Save system] - [Oyun tam olarak bir mekana sahip olmadığı için bu konuda ne yapacağımı bilemedim.]

### Bilinen Bug'lar
1. [Text overlay] - [Bir interactable üzerine gelin. Başka bir textin ilk başta gözüküp hemen kaybolacağını göreceksiniz.]

### İyileştirme Önerileri
1. [Öneri] - [Düzgün ve güzel gözüken bir alan oluşturulabilirdi.]
2. [Öneri] - [Eksik texture ve meshler var eklenebilirdi.]
3. [Öneri] - [Işıklandırma eklenebilirdi.]

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:


## Dosya Yapısı

```
Assets/
├── [ProjectName]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── ...
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   └── ...
│   │   │   ├── Player/
│   │   │   │   └── ...
│   │   │   └── UI/
│   │   │       └── ...
│   │   └── Editor/
│   ├── ScriptableObjects/
│   ├── Prefabs/
│   ├── Materials/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Ömer Turan] |
| E-posta | [omer.turan1002@gmail.com] |
| LinkedIn | [linkedin.com/in/ömer-turan-694136224] |
| GitHub | [github.com/TtayfunYildirim] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
