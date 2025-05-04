# TeamCalculator

**Calculator** - bu oddiy konsol loyiha bo'lib, foydalanuvchilarga matematik ifodalarni hisoblash, tarixni ko'rish, tozalash va saqlash imkonini beradi.

## Xususiyatlari:

- Matematik ifodalarni hisoblash uchun - `calculate` buyrug'i.
- Hisoblangan tarixni ko'rish - `history` buyrug'i.
- Hisoblangan tarixni tozalash - `clear` buyrug'i.
- Konsolni tozalash - `cls` buyrug'i.
- Dasturni to'xatish - `exit` buyrug'i.

## O'rnatish:

1. Loyihani klon qiling:
```bash
git clone https://github.com/muhammadhafiz18/Team.Calculator.git
cd src,
cd Team.Calculator
```

2. Loyihani ishga tushiring:
```bash
dotnet run
```

## Foydalanish:
Dastur ishga tushgandan keyin, quyidagi buyruqlarni kiritishingiz mumkun:

### Buyruqlar:

1. **`calculate`**
Matematik ifodani hisoblash uchun ishlatiladi.
Misol:
```
Calculator: 12 + 2
Natija: 12 + 2 = 14
```

2. **`history`**
Hisoblash tarixini ko'rish uchun ishlatiladi.
Misol:
```
[1]. 12 + 2 = 14 (AddedTime: 11:48:00)
```

3. **`clear`**
Hisoblash tarixini tozalash uchun ishlatiladi.
Siz `all` (hammasini ochirish), indeks raqamlari (ma'lum bir tarixni o'chirish) yoki `cancel` (orqaga) ni tanlashingiz mumkun.

4. **`cls`**
Konsolni tozalash uchun ishlatiladi.

5. **`exit`**
Dasturni to'xtatish uchun ishlatiladi.

## Tarixni saqlash:
Tarixni hisoblash `history.json` faylida saqlanadi. Dasturni to'xtatib qayta ishga tushurilganda, tarix avtamatik qayta yuklanadi.

## Loyihaning tuzilishi:

- **`Program.cs`** - Asosiy kirish nuqtasi.
- **`Interfaces`** - Interfeyslar saqlanadigan joy.
- **`Services`** - Barcha xizmatlarni amalga oshirilishi.
- **`Models`** - Ma'lumotlar modeli (`HistoryItem`).
- **`history.json`** - Hisoblangan tarixni saqlaydigan fayl.