## Team Calculate
- Calculate yani hisoblash uchum qurilma.
- U o'z ichida 4 ta ega bo'ladi.

# COMMANDS
1: calculate - berilgan comandani kiritsak bizga kalkulatorni ochib beradi.
2: history - bu comanda kalkulatorni history sini yani tarixini ko'rsatib beradi.
3: clear - bu kalkulatorni hotirasini ID yoki barchasini All comandasi bilan o'chirishga yordam beradi.
4: exit - bu shunchaki project dan chiqib ketish uchun ishlatilinadi.

Calculate nimalarga qodir ekaniligini bilib oldik, endi shu a'malarni
qanday bajarishini ko'rib chiqamiz. Uning ichida Services, Models va Interfaces kabi
papkalar mavjud.

# Services:
    1. CalculateService - calculate comandasiga jovobgar bo'lib hisoblash a'malarini bajaradi.
#      Code:
-          var dataTable = new DataTable();
-          double result = Convert.ToDouble(dataTable.Compute(expression, null));
#      Chuntirish:
        Berilgan kod biz bergan misolarni yechish uchun ishlatiladi, birinchi DataTable obyektni chaqirib oldik va result degan o'zgaruvchi ochib ynin ichida misolni hisobladik

#       Code:
-           if(history.Count != 0)
            {
                id = history.Last().Id + 1;
            }

            var historyItem = new HistoryItem
            {
                Id = id,
                Expression = expression,
                Result = result,
                CreatedAt = DateTime.Now
            };
#       Chuntirish:
        1 - birinchi bo'lib if yordamida List boshmi yoki uning ichida qiymat borligini tekshirib olishi uchun islatiladi, agar uni ichida qiymat bor bo'lsa Last() yordamida end oxirgi qiymatni olib unga +1 qoshib olamiz.
        2 - historyItem degan obyekt ochib olamiz va unga id, expression - misolni o'zi, result - misolni natijasi, createdAt - bajarilgan a'malimizni vohtini saqlaydi.

    2. DisplayService - bu servis yordamida ekranga ekranga chiqazish metodlari mavjud.
#       Code:
-           for (int i = 0; i < historyItems.Count; i++)
                Console.WriteLine($"({historyItems[i].Id}). {historyItems[i]} | {historyItems[i].CreatedAt:HH:mm:ss}");
#       Chuntirish:
        For yordamida historyItems ichida qiymat bor yoki yoqligini tekshirib olomiz. yani i dan historyItem ni qiymati katta bo'lsa ichidagi a'malni bajarish uchun kirib erkanga aynan i index dagi ma'lumotlar chiqib keladi.

    3. HistoryService - xotiraga bog'liq barcha metodlar shuning ichida bajarilgan.
#       ClearHistory:
            ClearHistory - bu clear comandasiga javobgar.
#           Code:
-           if (history.Count == 0)
                Console.WriteLine("nothing to clear");
            else
            {
                while (true)
                {
                    displayService.PrintHistory(history);

                    string input = displayService.ReadInput("'all' for full clearing / cancel / id for deleting single element");

                    if (input == "all")
                    {
                        history.Clear();
                        SaveHistory("history.json", history);

                        Console.WriteLine("History has cleared");
                        break;
                    }

                    else if (input == "cancel")
                    {
                        Console.Clear();
                        return;
                    }

                    else if(int.TryParse(input, out int id))
                    {
                        for(int i = 0; i < history.Count; i++)
                        {
                            if(history[i].Id == id)
                            {
                                Console.WriteLine($"{history[i]} has removed");
                                history.RemoveAt(i);
                                SaveHistory("history.json", history);
                            }
                        }
                    }
                }
            }
#           Chuntirish:
            1 - Agar if ni ichida history ni qiymati 0 ga teng bo'lsa "ekranga nothing to clear" chiqib metoddan chiqib ketadi.
            2. Else ga kiradigan bo'lsa birinchi bo'lib while(true) chiqib keladi. Bu biz agar qanday dur a'mal bajarmoqchi bo'lganimizda metoddan chiqib ketmaslikimizni taminlaydi.
            3 - Foydalanuvchi qaysi ma'lumotni clear qilmoqchiligini tanlashi uchun DisplayService ni chaqirib olamiz.
            4 - "input" ichida nima qilmoqchiligi sorab olamiz.
            5 - agar input teng bo'lsa "All", history.Clear yordamida terixini butunlay o'chirib tashlaymiz.
            6 - "cancel" so'zi kiritilsa return yordamida metoddan chiqib ketadi.
            7 - "else if(int.TryParse(input, out int id))" - input ni int ga parse qilolsak uni id degan int ga saqlab olamiz, va id boyicha tarixini o'chirib olamiz.

#       ShowHistory:
            ShowHistory - history comandasiga javobgar bo'lib butun terixni ko'rsatib beradi.
#           Code:
-           var displayService = new DisplayService();

            if (history.Count == 0)
                Console.WriteLine("HIstory is empty");

            else
                displayService.PrintHistory(history);
#           Chuntirish:
            1 - Agar if ni ichida history ni qiymati 0 ga teng bo'lsa "History is empty" chiqib metoddan chiqib ketadi.
            2 - else, displayService yordamida butun tarihni ekranga chiqazib olamiz.

#       SaveHistory:
            SaveHistory - bu bizga kodni o'chirib yoqknimizdan keyn ham ma'lumotlarni Json ichida saqlash uchun yordam beradi.
#           Code:
-           var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string json = JsonSerializer.Serialize(history, options);

            File.WriteAllText(path, json);
#           Chuntirish:
            1 - "options" biz saqlamoqchi bo'lgan masalani inson tilida saqlab olish uchun kerak bo'ladi.
            2 - "json" ning ichida Serialize qilib olamiz.
            3 - "File.WriteAllText(path, json)" - path bu qaysi file ga salqlashimiz kerakligini etamiz, va json nimani saqlash kerakligi.

#       LoadHistory:
            LoadHistory - bu metod yordamida history.json fiylidan barcha ma'lumotlarni chaqirib o'lamiz.
#           Code:
-           if (!File.Exists(path))
            {
                Console.WriteLine("not found: " + path);
            }
            else
            {
                var json = File.ReadAllText(path);
                var loadedHistory = JsonSerializer.Deserialize<List<HistoryItem>>(json);

                if (loadedHistory != null)
                {
                    history.AddRange(loadedHistory);
                    Console.WriteLine("load history: " + history.Count);
                }

                else
                    Console.WriteLine($"History {history.Count} is empty");
            }
#           Chuntirish:
            1 - if yordamida faylni ichida qiymat bor yoki yoqligini tekshirib olamiz.
            2 - agar else ga kirsa "var json = File.ReadAllText(path);" json tilidan obyektga otqazib olamiz.
            3 - yani bir bor if yordamida loadedHistory ni qiymatini tekshirib olamiz.
            4 - "history.AddRange(loadedHistory);" history listiga AddRange yordamida ma'lumotlarni qoshib olamiz.

# Models / HistoryItem
    Bu class va o'z ichida kerakli property larni saqlaydi, masalan: id, expression, result, createAt.

# Interfaces
    Interfaces qisqacha qilib shartnoma dep aytsa bo'ladi. Masalan: IHistoryService degan interface ochib oldik va HistoryService bilan birlashtirdik, agar HistoryService dagi biror bir metod yoki boshqa bir narsa interface ga mos kelmasa xato berib kod ishlamaydi va shartnomaga a'mal qilinmagan bo'ladi.
#   Eslatnma:
    Interface qoshilgandan keyn metodlar static bo'lmaydi va ularni chaqirish uchun avala obyekt ochib keyn ularni obyektga tenglavoring.

    



