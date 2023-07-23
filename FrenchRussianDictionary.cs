using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenchRussian
{
    class FrenchRussianDictionary
    {
        private Dictionary<string, List<string>> dictionary;

        public FrenchRussianDictionary()
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        public void AddWordTranslation()
        {
            Console.Clear();
            Console.WriteLine("=== Добавление слова и перевода ===");
            Console.Write("Введите слово на французком: ");
            string word = Console.ReadLine();

            Console.Write("Введите перевод слова на русский: ");
            string translation = Console.ReadLine();

            if (dictionary.ContainsKey(word))
            {
                dictionary[word].Add(translation);
            }
            else
            {
                dictionary.Add(word, new List<string> { translation });
            }

            Console.WriteLine("Слово и перевод успешно добавлены.");

            using (StreamWriter writer = new StreamWriter("Француско - русский словарь.txt", true))
            {
                writer.WriteLine("Слово: {0}", word);
                writer.WriteLine("Перевод: {0}", translation);
                writer.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void ReplaceWordTranslation()
        {
            Console.Clear();
            Console.WriteLine("=== Замена слова или перевода ===");
            Console.Write("Введите слово, которое нужно заменить: ");
            string word = Console.ReadLine();

            if (dictionary.ContainsKey(word))
            {
                Console.Write("Введите новое слово на французком: ");
                string newWord = Console.ReadLine();

                Console.Write("Введите новый перевод слова на русский: ");
                string newTranslation = Console.ReadLine();

                List<string> translations = dictionary[word];

                dictionary.Remove(word);

                dictionary.Add(newWord, translations);

                Console.WriteLine("Слово или перевод успешно заменены.");
                List<string> fileLines = File.ReadAllLines("француско - русский словарь.txt").ToList();
                fileLines.RemoveAll(line => line.StartsWith("Слово: " + word) || line.StartsWith("Перевод:"));
                fileLines.Add("Слово: " + newWord);
                fileLines.Add("Перевод: " + newTranslation);
                fileLines.Add("");
                File.WriteAllLines("француско - русский словарь.txt", fileLines);
            }
            else
            {
                Console.WriteLine("Слово не найдено.");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }



        public void DeleteWordTranslation()
        {
            Console.Clear();
            Console.WriteLine("=== Удаление слова или перевода ===");
            Console.Write("Введите слово, которое нужно удалить: ");
            string word = Console.ReadLine();

            if (dictionary.ContainsKey(word))
            {
                dictionary.Remove(word);
                Console.WriteLine("Слово и его переводы успешно удалены.");

                string[] fileLines = File.ReadAllLines("англо-русский словарь.txt");

                List<string> updatedFileLines = new List<string>();

                bool removeNextLine = false;

                foreach (string line in fileLines)
                {
                    if (removeNextLine)
                    {
                        removeNextLine = false;
                        continue;
                    }

                    if (line.StartsWith("Слово: " + word))
                    {
                        removeNextLine = true;
                        continue;
                    }

                    updatedFileLines.Add(line);
                }

                File.WriteAllLines("англо-русский словарь.txt", updatedFileLines);
            }
            else
            {
                Console.WriteLine("Слово не найдено.");
            }



            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void SearchTranslation()
        {
            Console.Clear();
            Console.WriteLine("=== Поиск перевода ===");
            Console.Write("Введите слово на английском для поиска перевода: ");
            string word = Console.ReadLine();

            if (dictionary.ContainsKey(word))
            {
                List<string> translations = dictionary[word];

                Console.WriteLine("Перевод(ы) слова '{0}':", word);
                foreach (string translation in translations)
                {
                    Console.WriteLine("- {0}", translation);
                }
            }
            else
            {
                Console.WriteLine("Слово не найдено.");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void ExportWords()
        {
            Console.Clear();
            Console.WriteLine("=== Экспорт слов и переводов ===");
            Console.Write("Введите имя файла для экспорта: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                Console.WriteLine("Файл с таким именем уже существует. Перезаписать? (y/n)");
                string overwriteChoice = Console.ReadLine();

                if (overwriteChoice.ToLower() != "y")
                {
                    Console.WriteLine("Экспорт отменен.");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    return;
                }
            }

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, List<string>> entry in dictionary)
                {
                    string word = entry.Key;
                    List<string> translations = entry.Value;

                    writer.WriteLine("Слово: {0}", word);
                    writer.WriteLine("Переводы:");
                    foreach (string translation in translations)
                    {
                        writer.WriteLine(" {0}", translation);
                    }
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Экспорт завершен. Файл сохранен: {0}", fileName);

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
