using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace LabaWork4_1
{
    public static class Tasks
    {
    // Задача 1: Замена первого вхождения списка L1 на L2 в списке L (List)
    public static void ReplaceFirstOccurrence()
    {
        Console.WriteLine("=== Задача 1: Замена первого вхождения списка ===");

        // Ввод основного списка L
        Console.WriteLine("Введите элементы основного списка L (через пробел, целые числа):");
        string inputL = Console.ReadLine();
        string[] inputLItems = inputL.Split(' ');
        List<int> L = new List<int>();
        foreach (string item in inputLItems)
        {
            int num = int.Parse(item);
            L.Add(num);
        }

        // Ввод списка L1 для поиска
        Console.WriteLine("Введите элементы списка L1 для поиска (через пробел, целые числа):");
        string inputL1 = Console.ReadLine();
        string[] inputL1Items = inputL1.Split(' ');
        List<int> L1 = new List<int>();
        foreach (string item in inputL1Items)
        {
            int num = int.Parse(item);
            L1.Add(num);
        }

        // Ввод списка L2 для замены
        Console.WriteLine("Введите элементы списка L2 для замены (через пробел, целые числа):");
        string inputL2 = Console.ReadLine();
        string[] inputL2Items = inputL2.Split(' ');
        List<int> L2 = new List<int>();
        foreach (string item in inputL2Items)
        {
            int num = int.Parse(item);
            L2.Add(num);
        }

        Console.WriteLine("Исходный список L: " + FormatList(L));
        Console.WriteLine("Список для поиска L1: " + FormatList(L1));
        Console.WriteLine("Список для замены L2: " + FormatList(L2));

        // Поиск и замена
        bool found = false;
        int position = -1;

        for (int i = 0; i <= L.Count - L1.Count; i++)
        {
            bool match = true;
            for (int j = 0; j < L1.Count; j++)
            {
                if (L[i + j] != L1[j])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                found = true;
                position = i;
                break;
            }
        }

        if (found)
        {
            // Удаляем L1
            L.RemoveRange(position, L1.Count);
            // Вставляем L2
            L.InsertRange(position, L2);
            Console.WriteLine("Замена выполнена успешно на позиции " + position);
            Console.WriteLine("Результат: " + FormatList(L));
        }
        else
        {
            Console.WriteLine("Список L1 не найден в списке L");
            Console.WriteLine("Результат без изменений: " + FormatList(L));
        }
    }

    // Задача 2: Сортировка LinkedList
    public static void SortLinkedList()
    {
        Console.WriteLine("=== Задача 2: Сортировка связного списка ===");

        Console.WriteLine("Введите элементы связного списка (через пробел, целые числа):");
        string input = Console.ReadLine();
        string[] inputItems = input.Split(' ');

        LinkedList<int> list = new LinkedList<int>();
        foreach (string item in inputItems)
        {
            int num = int.Parse(item);
            list.AddLast(num);
        }

        Console.WriteLine("Исходный список: " + FormatLinkedList(list));

        // Сортировка пузырьком для LinkedList
        bool swapped;
        int passCount = 0;

        do
        {
            swapped = false;
            LinkedListNode<int> node = list.First;

            while (node != null && node.Next != null)
            {
                if (node.Value > node.Next.Value)
                {
                    // Меняем значения местами
                    int temp = node.Value;
                    node.Value = node.Next.Value;
                    node.Next.Value = temp;
                    swapped = true;
                }
                node = node.Next;
            }

            passCount++;
            Console.WriteLine("После прохода " + passCount + ": " + FormatLinkedList(list));

        } while (swapped);

        Console.WriteLine("Отсортированный список: " + FormatLinkedList(list));
    }

    // Задача 3: Анализ игр студентов (HashSet)
    public static void AnalyzeGames()
    {
        Console.WriteLine("=== Задача 3: Анализ компьютерных игр ===");

        // Перечень всех игр
        HashSet<string> allGames = new HashSet<string>();
        allGames.Add("For");
        allGames.Add("Hon");
        allGames.Add("Xuu");
        allGames.Add("Hitl");
        allGames.Add("Adol");
        allGames.Add("2488");
        allGames.Add("69");

        // Словарь: студент -> игры, в которые он играет
        Dictionary<string, HashSet<string>> studentGames = new Dictionary<string, HashSet<string>>();

        Console.WriteLine("Доступные игры: " + FormatHashSet(allGames));
        Console.WriteLine("");

        // Ввод данных о студентах
        bool addMoreStudents = true;
        while (addMoreStudents)
        {
            Console.Write("Введите фамилию студента (или 'exit' для завершения ввода): ");
            string studentName = Console.ReadLine();

            if (studentName.ToLower() == "exit")
            {
                addMoreStudents = false;
                continue;
            }

            if (studentGames.ContainsKey(studentName))
            {
                Console.WriteLine("Студент с такой фамилией уже существует!");
                continue;
            }

            // Создаем множество игр для нового студента
            HashSet<string> studentGameSet = new HashSet<string>();
            bool addMoreGames = true;

            Console.WriteLine("Добавление игр для студента: " + studentName);

            while (addMoreGames)
            {
                Console.WriteLine("Доступные игры: " + FormatHashSet(allGames));
                Console.Write("Введите название игры (или 'exit' для завершения): ");
                string gameName = Console.ReadLine();

                if (gameName.ToLower() == "exit")
                {
                    addMoreGames = false;
                    continue;
                }

                if (allGames.Contains(gameName))
                {
                    if (studentGameSet.Contains(gameName))
                    {
                        Console.WriteLine("Студент уже играет в эту игру!");
                    }
                    else 
                    {
                        studentGameSet.Add(gameName);
                        Console.WriteLine("Игра '" + gameName + "' добавлена студенту " + studentName);
                    }
                }
                else
                {
                    Console.WriteLine("Игры '" + gameName + "' нет в перечне доступных игр!");
                }
            }

            studentGames[studentName] = studentGameSet;
            Console.WriteLine("Студент " + studentName + " добавлен. Игры: " + FormatHashSet(studentGameSet));
            Console.WriteLine("");
        }

        // Проверяем, есть ли студенты для анализа
        if (studentGames.Count == 0)
        {
            Console.WriteLine("Нет данных о студентах для анализа!");
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("=== ВВЕДЕННЫЕ ДАННЫЕ ===");
        Console.WriteLine("Все игры в перечне: " + FormatHashSet(allGames));
        Console.WriteLine("");
        Console.WriteLine("Игры студентов:");
        foreach (KeyValuePair<string, HashSet<string>> student in studentGames)
        {
            Console.WriteLine(student.Key + ": " + FormatHashSet(student.Value));
        }

        // Анализ данных
        Console.WriteLine("");
        Console.WriteLine("=== РЕЗУЛЬТАТЫ АНАЛИЗА ===");

        // Игры, в которые играют все студенты
        HashSet<string> commonGames = new HashSet<string>(allGames);
        foreach (HashSet<string> games in studentGames.Values)
        {
            commonGames.IntersectWith(games);
        }

        // Игры, в которые играют некоторые студенты
        HashSet<string> somePlay = new HashSet<string>();
        foreach (HashSet<string> games in studentGames.Values)
        {
            somePlay.UnionWith(games);
        }

        // Игры, в которые не играет ни один студент
        HashSet<string> noOnePlays = new HashSet<string>(allGames);
        noOnePlays.ExceptWith(somePlay);

        if (commonGames.Count > 0)
        {
            Console.WriteLine("Игры, в которые играют ВСЕ студенты: " + FormatHashSet(commonGames));
        }
        else
        {
            Console.WriteLine("Игры, в которые играют ВСЕ студенты: нет общих игр");
        }

        Console.WriteLine("Игры, в которые играют НЕКОТОРЫЕ студенты: " + FormatHashSet(somePlay));

        if (noOnePlays.Count > 0)
        {
            Console.WriteLine("Игры, в которые НЕ ИГРАЕТ НИ ОДИН студент: " + FormatHashSet(noOnePlays));
        }
        else
        {
            Console.WriteLine("Игры, в которые НЕ ИГРАЕТ НИ ОДИН студент: нет таких игр");
        }

        // Детальная информация по играм
        Console.WriteLine("");
        Console.WriteLine("=== ДЕТАЛЬНАЯ ИНФОРМАЦИЯ ===");
        foreach (string game in allGames)
        {
            List<string> players = new List<string>();
            foreach (KeyValuePair<string, HashSet<string>> student in studentGames)
            {
                if (student.Value.Contains(game))
                {
                    players.Add(student.Key);
                }
            }

            if (players.Count > 0)
            {
                Console.WriteLine("В игру '" + game + "' играют: " + string.Join(", ", players));
            }
            else
            {
                Console.WriteLine("В игру '" + game + "' никто не играет");
            }
        }

        // Дополнительная статистика
        Console.WriteLine("");
        Console.WriteLine("=== СТАТИСТИКА ===");
        Console.WriteLine("Всего студентов: " + studentGames.Count);
        Console.WriteLine("Всего игр в перечне: " + allGames.Count);
        Console.WriteLine("Игр с хотя бы одним игроком: " + somePlay.Count);
        Console.WriteLine("Игр без игроков: " + noOnePlays.Count);
    }

    // Задача 4: Глухие согласные из файла (HashSet)
    public static void FindVoicelessConsonants()
    {
        Console.WriteLine("=== Задача 4: Поиск глухих согласных ===");

        string filename = "text.txt";
        CreateTextFile(filename);

        Console.WriteLine("Чтение текста из файла " + filename);
        string text = File.ReadAllText(filename).ToLower();

        Console.WriteLine("Текст из файла: " + text);

        // Множество глухих согласных
        HashSet<char> voicelessConsonants = new HashSet<char>();
        voicelessConsonants.Add('п');
        voicelessConsonants.Add('ф');
        voicelessConsonants.Add('к');
        voicelessConsonants.Add('т');
        voicelessConsonants.Add('ш');
        voicelessConsonants.Add('с');
        voicelessConsonants.Add('х');
        voicelessConsonants.Add('ц');
        voicelessConsonants.Add('ч');
        voicelessConsonants.Add('щ');

        // Разбиваем текст на слова
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("");
        Console.WriteLine("Слова в тексте:");
        foreach (string word in words)
        {
            Console.WriteLine("- " + word);
        }

        Console.WriteLine("");
        Console.WriteLine("Все глухие согласные в русском языке: " + FormatHashSetChars(voicelessConsonants));

        // Глухие согласные, которые отсутствуют хотя бы в одном слове
        HashSet<char> result = new HashSet<char>();

        foreach (char consonant in voicelessConsonants)
        {
            bool missingInSomeWord = false;
            foreach (string word in words)
            {
                if (!word.Contains(consonant))
                {
                    missingInSomeWord = true;
                    break;
                }
            }
            if (missingInSomeWord)
            {
                result.Add(consonant);
            }
        }

        // Сортируем результат
        List<char> sortedResult = new List<char>(result);
        sortedResult.Sort();

        Console.WriteLine("");
        if (sortedResult.Count > 0)
        {
            Console.WriteLine("Глухие согласные, которые НЕ ВХОДЯТ хотя бы в одно слово: " + string.Join(" ", sortedResult));
        }
        else
        {
            Console.WriteLine("Нет глухих согласных, которые отсутствовали бы хотя бы в одном слове");
        }

        // Дополнительно: покажем для каждой согласной, в каких словах она есть
        Console.WriteLine("");
        Console.WriteLine("=== ПРИСУТСТВИЕ СОГЛАСНЫХ В СЛОВАХ ===");
        foreach (char consonant in voicelessConsonants)
        {
            List<string> wordsWithConsonant = new List<string>();
            foreach (string word in words)
            {
                if (word.Contains(consonant))
                {
                    wordsWithConsonant.Add(word);
                }
            }

            if (wordsWithConsonant.Count > 0)
            {
                Console.WriteLine("Согласная '" + consonant + "' есть в словах: " + string.Join(", ", wordsWithConsonant));
            }
            else
            {
                Console.WriteLine("Согласная '" + consonant + "' отсутствует во всех словах");
            }
        }
    }

    // Задача 5: Олимпиада (Dictionary)
    public static void ProcessOlympiadResults()
    {
        Console.WriteLine("=== Задача 5: Результаты олимпиады ===");

        string filename = "olympiad.txt";
        CreateOlympiadFile(filename);

        Console.WriteLine("Чтение данных из файла " + filename);
        string[] lines = File.ReadAllLines(filename);

        // Пропускаем первую строку с количеством участников
        Dictionary<string, int> participants = new Dictionary<string, int>();

        Console.WriteLine("");
        Console.WriteLine("Результаты участников:");
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(' ');
            if (parts.Length >= 5)
            {
                string lastName = parts[0];
                string firstName = parts[1];
                string fullName = lastName + " " + firstName;

                int score1 = int.Parse(parts[2]);
                int score2 = int.Parse(parts[3]);
                int score3 = int.Parse(parts[4]);
                int total = score1 + score2 + score3;

                participants[fullName] = total;
                Console.WriteLine(fullName + ": " + score1 + " + " + score2 + " + " + score3 + " = " + total);
            }
        }

        // Находим максимальный балл
        int maxScore = 0;
        foreach (int score in participants.Values)
        {
            if (score > maxScore)
            {
                maxScore = score;
            }
        }

        // Собираем всех победителей
        List<string> winners = new List<string>();
        foreach (KeyValuePair<string, int> participant in participants)
        {
            if (participant.Value == maxScore)
            {
                winners.Add(participant.Key);
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Максимальный балл: " + maxScore);
        Console.WriteLine("Победители:");
        foreach (string winner in winners)
        {
            Console.WriteLine("- " + winner);
        }

        // Дополнительно: отсортируем всех участников по баллам
        Console.WriteLine("");
        Console.WriteLine("=== ВСЕ УЧАСТНИКИ ОТСОРТИРОВАННЫЕ ПО БАЛЛАМ ===");
        List<KeyValuePair<string, int>> sortedParticipants = new List<KeyValuePair<string, int>>(participants);
        sortedParticipants.Sort((a, b) => b.Value.CompareTo(a.Value));

        foreach (KeyValuePair<string, int> participant in sortedParticipants)
        {
            Console.WriteLine(participant.Key + ": " + participant.Value + " баллов");
        }
    }

    // Вспомогательные методы для форматирования выводов
    private static string FormatList(List<int> list)
    {
        return "[" + string.Join(", ", list) + "]";
    }

    private static string FormatLinkedList(LinkedList<int> list)
    {
        return "[" + string.Join(", ", list) + "]";
    }

    private static string FormatHashSet(HashSet<string> set)
    {
        return string.Join(", ", set);
    }

    private static string FormatHashSetChars(HashSet<char> set)
    {
        return string.Join(" ", set);
    }

    // Создание тестового файла для задачи 4
    private static void CreateTextFile(string filename)
    {
        if (!File.Exists(filename))
        {
            string[] testText = {
                "Пример текста на русском языке для проверки",
                "Здесь есть разные слова с согласными буквами",
                "Некоторые буквы могут отсутствовать в отдельных словах"
            };
            File.WriteAllLines(filename, testText);
            Console.WriteLine("Создан тестовый файл " + filename);
        }
    }

    // Создание тестового файла для задачи 5
    private static void CreateOlympiadFile(string filename)
    {
        if (!File.Exists(filename))
        {
            string[] testData = {
                "6",
                "Петрова Ольга 25 18 16",
                "Калиниченко Иван 14 19 15",
                "Сидоров Алексей 25 25 25",
                "Иванова Мария 24 23 25",
                "Кузнецов Дмитрий 25 25 25",
                "Смирнова Анна 20 22 23"
            };
            File.WriteAllLines(filename, testData);
            Console.WriteLine("Создан тестовый файл " + filename);
        }
    }
}
}