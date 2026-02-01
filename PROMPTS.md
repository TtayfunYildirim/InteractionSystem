

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | 11 |
| Kullanılan araçlar | ChatGPT / Gemini|
| En çok yardım alınan konular | [Problem çözümü] [Zaman yönetimi] |
| Tahmini LLM ile kazanılan süre | 9 - 10 saat |

---

## Prompt 1: [Zaman yönetimi]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 09:34

**Prompt:**
```
I have to do a Unity project in 12 hours. This project is like a very basic MVP that focuses on world interactions like pulling levers or opening doors. I need to manage my time carefully. How should I approach to use my time efficiently?
```

**Alınan Cevap (Özet):**
```
Don't start by coding a door. Start by coding the contract for how things interact. This ensures that whether you add a lever, a button, or a chest later, the player controller doesn't need to change.

Create an IInteractable Interface: Include a simple method like void Interact();.

Raycast Interaction: Set up your player to fire a Raycast from the camera. If the hit object has an IInteractable component, trigger it.

The "Feedback" Script: Create a simple script that changes an object's color when looked at. This proves your detection logic works before you even have animations.

At the 8-hour mark, stop adding new types of interactions.

The "Golden Path" Test: Ensure a player can walk through the whole "level," pull the lever, and see the door open without console errors.

UI Feedback: Add a simple Crosshair and a "Press E to Interact" text prompt that appears when the Raycast hits an interactable object.
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım (değişiklik yapmadan)
- [+] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> Çok kısıtlı bir zamanım olduğu için en az hatayı yapabilmek için zaman yönetimi hakkında bilgi aldım. Oldukça yardımcı oldu çünkü bu tip bir durumda yanlış konuya odaklanmak veya sıfırdan başlanacağı için nereden başlanacağını bilememek oldukça büyük zaman kaybı yaratabilirdi.

**Yapılan Değişiklikler (adapte ettiyseniz):**
> Verdiği teknikleri kullandım fakat direkt olarak dediği şekilde gitmektense bana uygun olan şekilde başladım. Karakteri hazırlayıp sonrasında test modelleri ve etkileşimlere geçtim çünkü bu şekilde test edebilmem daha kolay oldu.

---

## Prompt 2: [Oyunun boyutu]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 09:40

**Prompt:**
```
(Bana yollanan dosyaları yolladım) Regarding to these files; is there any mention of creating the game in 3D?
```

**Alınan Cevap (Özet):**
```
Evet, dosyalar incelendiğinde projenin kesinlikle 3D olması gerektiğini gösteren çok net teknik gereksinimler ve standartlar bulunmaktadır. "Oyun 3D olmalıdır" şeklinde doğrudan bir cümle yazmasa da, senden uymanı istedikleri kurallar 2D bir projede uygulanamaz.

İşte bunun kanıtları:

1. Prefab ve Yönlendirme Kuralları (+Z Ekseni) Prefab_Asset_Kurallari.md dosyasında, nesnelerin yönüyle ilgili şu kural yer alır:

"İleri yön (forward direction) her zaman +Z ekseni olmalıdır (Unity standardı)".

2D oyunlarda (Sprite tabanlı) genellikle X ve Y eksenleri kullanılır. Z eksenini "ileri" olarak tanımlamak ve pivot noktalarını "Bottom Center" (taban merkezi) olarak ayarlamak, 3D modeller ve dünya düzeni için geçerli bir standarttır.

2. Collider Tipleri (Fizik) Aynı dosyada "Collider Tercih Sırası" başlığı altında istenen bileşenler tamamen 3D fizik motoruna aittir:

"Box Collider, Capsule Collider, Sphere Collider, Mesh Collider".

Eğer 2D isteniyor olsaydı, BoxCollider2D, CircleCollider2D gibi "2D" eki olan bileşenler belirtilirdi. Özellikle Capsule Collider ve Mesh Collider, 3D dünyada karakter ve karmaşık nesneler için kullanılır.
```

**Nasıl Kullandım:**
- [+] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Oyunun hangi boyutta olacağına tam karar veremediğim için emin olmak adına bu soruyu sordum. Bununla beraber 2 Boyutlu oyunlarda daha deneyimli olduğum için aslında "Hayır 3d zorunlu değil." çıktısı bekledim fakat umduğum gibi olmadı.

---

## Prompt 3: [İsimlendirme Atlası]

**Araç:** [ChatGPT]
**Tarih/Saat:** 2026-01-30 10:02

**Prompt:**
```
(Bana yollanan dosyaları yolladım) Regarding to these files; Can you make a dashboard for all the naming conventions?
```

**Alınan Cevap (Özet):**
```
İsimlendirme metodlarını excel üzerinde oluşturduğu için cevabını buraya yazamıyorum fakat kısaca bana okunabilir ve bir kenarda devamlı bakabileceğim bir tablo hazırladı.
```

**Nasıl Kullandım:**
- [+] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Projeye başladıktan sonra daha da fazla zaman kaybetmek istemedim. İsimlendirme kurallarını okumaya başladım fakat dosya boyutunun uzunluğundan ötürü yüksek ihtimalle bu kuralları unuturum diye düşündüm sonrasında ise LLM'den böyle bir tablo oluşturmasını istedim.

---

## Prompt 4: [Input Method hatası]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 11:43

**Prompt:**
```
I got this error: (nvalidOperationException: You are trying to read Input using the UnityEngine.Input class, but you have switched active Input handling to Input System package in Player Settings.) What could be the reason? I got this error when I updated the Player Movement.
```

**Alınan Cevap (Özet):**
```
Bu hata, Unity projesinin Yeni Input Sistemi (New Input System) kullanacak şekilde ayarlanmış olmasından, ancak yazdığımız kodun Eski Input Sistemi (Legacy Input Manager -> Input.GetAxis) kullanmasından kaynaklanıyor.

Unity'de şu an iki sistem var ve Godot'taki gibi "tek bir standart" yok. Mülakatta zaman kazanmak ve yazdığımız kodu değiştirmemek için en hızlı çözüm, Unity'ye "Her iki sistemi de kullan" demektir.

Şu adımları takip ederek hatayı hemen çözebilirsin:

Çözüm Adımları
Unity üst menüsünden Edit > Project Settings... yolunu izle.

Açılan pencerede soldan Player sekmesine tıkla.

Sağ tarafta Other Settings başlığını bul ve genişlet.

Biraz aşağı inip Configuration bölümünü bul.

Active Input Handling ayarını bul. Şu an muhtemelen "Input System Package (New)" seçilidir.

Bunu Both (veya sadece Input Manager (Old)) olarak değiştir.

Unity, "Restart gerekli" diyecek. Apply diyerek Unity'nin yeniden başlamasına izin ver.

Unity tekrar açıldığında hata gidecek ve karakterin hareket etmeye başlayacaktır.
```

**Nasıl Kullandım:**
- [+] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Input konusunda bir hata aldım fakat sorunu hemen göremedim. Dolayısıyla daha fazla oyalanmak yerine LLM'den destek aldım ve oldukça işime yaradı sorunu giderdim.

---

## Prompt 5: [Free Asset Kullanımı]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 14:20

**Prompt:**
```
In the files I sent you is there any mention about using free assets?
```

**Alınan Cevap (Özet):**
```
Gönderdiğin dosyalarda "Free asset kullanmak serbesttir" veya "yasaktır" şeklinde doğrudan bir ifade bulunmuyor. Ancak, CASE_Unity_Interaction_System.md dosyasında dikkat etmen gereken kritik bir kural var:

Plagiarism (İntihal) = Eleme

Bu kural şu anlama gelir:

Kod ve Sistem (YASAK): Asset Store'dan veya GitHub'dan hazır bir "Interaction System" veya "Player Controller" indirip kullanamazsın. Bu, "başka projeden birebir kopya" sayılır ve doğrudan elenme sebebidir.

Görsel ve Ses (SERBEST OLMALI): Sen bir "Developer" (Geliştirici) pozisyonu için mülakattasın, "3D Artist" değil. Bu nedenle kapı modeli, anahtar modeli, ses efektleri veya texture gibi sanat varlıklarını (Art Assets) ücretsiz paketlerden kullanman teknik olarak bir sorun yaratmaz.

Ancak Şartlar Var: Ludu Arts standartlarına uymak zorundasın. İndirdiğin bir kapı modelini (FreeDoor.fbx) olduğu gibi projene atamazsın.

İsimlendirme: Dosyayı SM_Door_01 olarak yeniden adlandırmalısın.

Klasörleme: Asset Store klasörünü olduğu gibi bırakmamalı, sadece ihtiyacın olan dosyayı Assets/[ProjectName]/Objects/Architecture/ gibi doğru yere taşımalısın.

Prefab: Modeli bir P_Door prefabı haline getirmeli ve kurallara (Position 0,0,0, Pivot doğru yerde vb.) uymalısın.
```

**Nasıl Kullandım:**
- [] Direkt kullandım
- [+] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Dosyaları incelememe rağmen asset kullanımı hakkında kesin bir yargı göremedim. Dolayısıyla gözden kaçırdığım bir durum olup olmadığını anlamak için bu promptu yazdım. Yine de emin olamayıp tekrardan Yollanan dosyayı inceledim ve sandık, kapı gibi asset kullanmadan görünüm vermesi zor olacak eşyalar yer aldığı için insiyatif kullanıp Free asset kullandım.

---

## Prompt 6: [Unity Terminal]

**Araç:** [ChatGPT]
**Tarih/Saat:** 2026-01-30 14:41

**Prompt:**
```
how do I open terminal inside unity?
```

**Alınan Cevap (Özet):**
```
Good question — Unity itself doesn’t have a built-in terminal, but there are 3 easy, practical ways to open a terminal for your Unity project.

I’ll list them from most convenient → simplest.

✅ Method 1: Open terminal in the project folder (BEST)
🔹 Windows

Open your Unity project folder in File Explorer

Shift + Right-Click inside the folder

Click “Open PowerShell window here”
(or “Open in Terminal” on Windows 11)

👉 That terminal is now inside your Unity project.

🔹 macOS

Open Finder

Right-click your Unity project folder

Services → New Terminal at Folder

🔹 Linux

Right-click inside the project folder

Open Terminal Here
```

**Nasıl Kullandım:**
- [] Direkt kullandım
- [] Adapte ettim
- [+] Reddettim

**Açıklama:**
> Bu soruyu Github Desktop üzerinde pushlama yaparken yaşadığım bir sorun için sordum ancak bahsettiği metod pek yardımcı olmadı dolayısıyla işlemi git bash ile yapmak zorunda kaldım. Sonrasında bu sorunu çözdüm ve sonraki pushlamaları Desktop üzerinden gerçekleştirdim.

---

## Prompt 7: [Kapı animasyonu]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 15:30

**Prompt:**
```
There is two parts of the door inside frame and the outside frame. Presumably we only want the inside to turn and it turns from the middle point how do we fix this?
```

**Alınan Cevap (Özet):**
```
Bu çok yaygın bir sorundur (özellikle oyun için hazırlanmamış mimari modellerde). Kapının dönme noktası (Pivot) geometrik merkezde olduğu için kapı pervane gibi ortadan döner.

Bunu çözmek için modeli 3D programa (Blender/Maya) geri götürmene gerek yok. Unity içinde "Parenting Trick" (Ebeveyn Hilesi) ile pivotu sanal olarak kaydıracağız.

İşte adım adım çözüm:

1. Hiyerarşiyi Hazırla (Menteşe Noktası Yaratma)
Hiyerarşide bir "sanal menteşe" (Empty GameObject) oluşturup, kapıyı onun içine atacağız. Böylece biz menteşeyi döndüreceğiz, kapı da ona bağlı olduğu için doğru yerden dönecek.

Prefabı Aç: P_Door prefabına çift tıkla.

Parçaları Ayır: "Outside Frame" (Kasa) ve "Inside Frame" (Kanat) muhtemelen ayrı objelerdir. Değilse ayıramazsın.

Menteşe Objesi Yarat:

P_Door (Root) içine sağ tık -> Create Empty.

Adını Hinge_Pivot yap.

Konumlandırma (En Önemli Adım):

Bu Hinge_Pivot objesini, kapının dönmesini istediğin tam köşeye (menteşe yerine) taşı.

İpucu: Klavyede V tuşuna basılı tutarak Vertex Snapping kullanabilirsin; böylece tam köşeye yapışır.

2. Kapıyı Menteşeye Bağla (Parenting)
Şimdi kapı kanadını bu yeni objenin çocuğu yapacağız.

Hierarchy'de "Inside Frame" (Dönecek olan kapı parçası) objesini sürükle ve Hinge_Pivot objesinin üzerine bırak.
```

**Nasıl Kullandım:**
- [] Direkt kullandım
- [+] Adapte ettim
- [] Reddettim

**Açıklama:**
> Prefab objelerin pivot noktasıyla oynama yapamadığım için bunu o değişikliği yapmadan nasıl yapabileceğimi öğrenmek için bu soruyu sordum. İşime yaradı fakat yönlendirme görsel eksiğinden ötürü birebir takip etmesi sıkıntı oluşturdu dolayısıyla bunu bir tutorialdan öğrenmem gerekti.

---

## Prompt 8: [Oyuncu - Kapı collision]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 15:52

**Prompt:**
```
I did add a box collider for the door to stop the player if its closed but I want only the inside frame to have a contact or the collision for stopping the player to stop when the door is opened. How can I achieve that? Is there a way to close collision for the player?
```

**Alınan Cevap (Özet):**
```
Burada yaşadığın durum, kapı modelinin (görselin) dönmesi ama "fiziksel duvarın" (Collider) olduğu yerde kalmasından kaynaklanıyor olabilir. Veya kapının "Player" (Oyuncu) ile çarpışmasını istemiyorsun ama raycast ile tıklanmasını istiyorsun.

İstediğin şeyi (Kapı kapalıyken oyuncuyu durdursun, açılınca yol versin ve sadece iç kanatta collision olsun) başarmak için yapman gerekenler şunlardır:

1. Collider'ı Hareketli Parçaya Taşı (En Önemli Adım)
Eğer kapı açıldığında oyuncunun geçebilmesini istiyorsan, BoxCollider bileşeni, dönme işlemini yapan objenin üzerinde (veya çocuğunda) olmalıdır.

2. "Player" İçin Collision'ı Kapatmak (Layer Collision Matrix)
Sorunun ikinci kısmı: "Is there a way to close collision for the player?"

Eğer kapının tıklanabilir olmasını (Raycast) ama oyuncunun içinden geçebilmesini (Hayalet gibi) istiyorsan, Unity'nin Fizik Matrisini kullanmalısın.

Layer Ata:

Kapı objene (Collider olan parçaya) Interactable layer'ını ata.

Oyuncu objene (P_Player) Player layer'ını ata (Yoksa sağ üstten Layer -> Add Layer diyerek oluştur).

Fizik Ayarları:

Üst menüden Edit > Project Settings > Physics yolunu izle.

En altta bir matris (tablo) göreceksin.

Player satırı ile Interactable sütununun kesiştiği kutucuktaki tiki kaldır.

**Nasıl Kullandım:**
- [] Direkt kullandım
- [+] Adapte ettim
- [] Reddettim

**Açıklama:**
> Amacım kapının collisionını kapatıp açık olduğu zaman oyuncunun içinden geçmesine izin vermekti. Aslında bu gelen promptun tek işe yarayan kısmı bana layerları değiştirme hatırlatması yapmış olması oldu çünkü bu sistemden vazgeçtim yerine tüm kapı collisionı yerine sadece iç kapı collisionı koydum.

---

## Prompt 9: [Texture hatası]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 17:20

**Prompt:**
```
I have a problem with importing assets. When I import selected files of an asset the materials seems to be become all pink. Why?
```

**Alınan Cevap (Özet):**
```
Unity'de malzemelerin Pembe (Magenta) görünmesinin tek bir anlamı vardır: Shader Hatası. Unity, atanan Shader'ı bulamadığında veya çalıştıramadığında dikkat çekmek için bu rengi kullanır. Godot'ta bir shader hata verirse nesne görünmez olur veya garip davranır, Unity'de ise "Bana bak, bozuğum!" diye bağırır.

Bu sorunun en olası iki sebebi ve çözümü şunlardır:

1. Sebep: Render Pipeline Uyuşmazlığı (En Yüksek İhtimal)
Eğer projeni URP (Universal Render Pipeline) olarak açtıysan ama indirdiğin asset Built-in (Standart) render sistemi için hazırlanmışsa, materyaller pembe görünür.

Çözüm (Otomatik Dönüştürme):

Project penceresinde pembe görünen materyalleri (veya klasörü) seç.

Üst menüden: Window > Rendering > Render Pipeline Converter yolunu izle.

(Eski versiyonlarda: Edit > Rendering > Materials > Convert Selected Built-in Materials to URP).

Açılan pencerede Material Upgrade seçeneğini bul.

Initialize Converters ve ardından Convert Assets butonuna bas.

**Nasıl Kullandım:**
- [+] Direkt kullandım
- [] Adapte ettim
- [] Reddettim

**Açıklama:**
> Bu gerçekten işime yaradı çünkü render pipeline uyuşmazlığı ilk defa yaşadığım bir sorundu.

---

## Prompt 10: [UI Update]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 18:45

**Prompt:**
```
I have a problem with the UI updates. In the game when I try to change a state of an interactable object while it does changes the text appearing after I look at the object again it does not do that change immediately. What could be the problem?
```

**Alınan Cevap (Özet):**
```
It sounds like you’re hitting a classic synchronization issue in game development. Usually, this happens when the data state changes, but the UI layer isn't told to refresh until the next "interaction event" (like re-focusing the object).

Here are the three most likely culprits and how to fix them:

1. The "Pull" vs. "Push" Problem
Most UI lag happens because the code is waiting for a "Pull" (the player looking at the object) to check the state, rather than the state "Pushing" an update to the UI as soon as it changes.

The Fix: Implement an Observer Pattern or Events. Instead of updating the text only in OnHover() or OnLookAt(), your interaction script should trigger an OnStateChanged event that the UI listens to.

2. Stale Reference or Local Caching
If your UI script caches the object's description string when you first look at it, it might be displaying that cached version even if the underlying variable has changed.

The Check: Ensure your UI update function is reading directly from the source of truth at the moment of the change, not just when the raycast hits the object.

3. Execution Order (The Frame Gap)
If you change the state and then immediately call the UI update in the same frame, the UI might be reading the old value because the state variable hasn't finished its logic cycle yet.
```

**Nasıl Kullandım:**
- [] Direkt kullandım
- [] Adapte ettim
- [+] Reddettim

**Açıklama:**
> Bu yaşadığım problem için güzel bir öneriydi fakat tam olarak dediğini yapmam için kod üzerinde çok fazla değişiklik olması gerekiyordu. Kodu yollayıp üzerinde değişiklik yapıp yapmamasını istemek konusunda arada kaldım fakat en sonunda farklı bir yöntem olarak objenin durumu değiştiğinde text üzerinde zorunlu güncelleme yaparak bu sorunu çözdüm.

---

## Prompt 11: [Lever Geliştirme]

**Araç:** [ChatGPT]
**Tarih/Saat:** 2026-01-30 19:11

**Prompt:**
```
In my game I need to add a lever and a connection to that action. For example lets say if I pull the lever a door opens up. I have a code for door, interaction with a door. My code dictates there is a key required to open the door normally. What is the best way to approach this problem or how can I add this kind of function efficiently?
```

**Alınan Cevap (Özet):**
```
Great question — this is exactly the kind of problem where a clean architecture choice saves you from future pain.

You’re basically asking:

“How do I make different things trigger other things, without hard-coding everything?”

The best practice answer in Unity is:
👉 Decouple interaction from action
👉 Use interfaces + events (or UnityEvents)

I’ll walk you from concept → concrete example, keeping it efficient and scalable.

🧠 The Core Idea (very important)

Instead of:

Lever knowing about Door

Door knowing about Lever

Key logic tangled with interaction logic

We want:

Lever: “I was activated”

Door: “I can open when told”

Connection: made in Inspector, not code

This gives you:

Lever → Door

Button → Elevator

Pressure plate → Trap

WITHOUT rewriting logic
```

**Nasıl Kullandım:**
- [] Direkt kullandım
- [+] Adapte ettim
- [] Reddettim

**Açıklama:**
> Son saatlere yaklaşırken olabildiğince hızlı yardım almak istedim. Verdiği çıktının sonuna bir de direkt kod ekledi o kısmı otomatik olarak eledim fakat verdiği öneri oldukça işime yaradı.

---




## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. [Problem yaklaşımı]
2. [Beklenmedik sorunlarda ne yapılması gerektiği]

### LLM'in Yetersiz Kaldığı Alanlar
1. [Spesifik kod sorunlarında benim kodumu görmemesine rağmen kod yazması dolayısıyla yanlış öneriler vermesi]

### LLM Kullanımı Hakkında Düşüncelerim
> [Bu case boyunca LLM kullanarak neler öğrendiniz? 
> LLM'siz ne kadar sürede bitirebilirdiniz?
> Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz?]

1. LLM kullanarak sorunlarımı daha hızlı çözmeyi öğrendim. Açıkçası bu sorunlarla kendim baş etseydim projeyi zamanında bitiremeyebilirdim.
2. LLM'siz yüksek ihtimalle aynı projeyi 2 kat uzun sürede bitirirdim. Sorunlara gereğinden fazla odaklanıp inat edebiliyorum.
3. Gelecek zamanlarda yüksek ihtimalle prompt engineering bilgilerimi geliştirerek sorunlarımı daha iyi çözmeye odaklanabilirim.

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
