//Создать приложение «Словари».
//Основная задача проекта: хранить словари на разных языках и разрешать пользователю находить перевод нужного слова или фразы.
//Интерфейс приложения должен предоставлять такие возможности:
//■ Создавать словарь. При создании нужно указать тип словаря.
//Например, англо-русский или русско-английский.
//■ Добавлять слово и его перевод в уже существующий словарь. Так как у слова может быть несколько переводов, необходимо поддерживать возможность создания
//нескольких вариантов перевода.
//■ Заменять слово или его перевод в словаре.
//■ Удалять слово или перевод. Если удаляется слово, все его переводы удаляются
//вместе с ним. Нельзя удалить перевод слова, если это последний вариант перевода.
//■ Искать перевод слова.
//■ Словари должны храниться в файлах.
//■ Слово и варианты его переводов можно экспортировать в отдельный файл результата.
//■ При старте программы необходимо показывать меню для работы с программой.
//Если выбор пункта меню открывает подменю, то тогда в нем требуется предусмотреть возможность возврата в предыдущее меню.

using System;
using System.Collections.Generic;
using System.IO;
using EnglishRussian;
using RussianEnglish;
using RussianFrench;
using FrenchRussian;

class Program
{
    static Dictionary<string, Dictionary<string, List<string>>> dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Главное меню ===");
            Console.WriteLine("1. Создать англо-русский словарь");
            Console.WriteLine("2. Создать русско-английский словарь");
            Console.WriteLine("3. Создать русско-французкий словарь");
            Console.WriteLine("4. Создать французко-русский словарь");
            Console.WriteLine("0. Выйти");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EnglishRussianDictionary englishRussianDictionary = new EnglishRussianDictionary();
                    bool exit1 = false;
                    while (!exit1)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Англо-русский словарь ===");
                        Console.WriteLine("1. Добавить слово и перевод");
                        Console.WriteLine("2. Заменить слово или перевод");
                        Console.WriteLine("3. Удалить слово или перевод");
                        Console.WriteLine("4. Найти перевод слова");
                        Console.WriteLine("5. Экспорт слов и переводов");
                        Console.WriteLine("0. Выйти");
                        Console.Write("Выберите действие: ");
                        string choice1 = Console.ReadLine();

                        switch (choice1)
                        {
                            case "1":
                                englishRussianDictionary.AddWordTranslation();
                                break;
                            case "2":
                                englishRussianDictionary.ReplaceWordTranslation();
                                break;
                            case "3":
                                englishRussianDictionary.DeleteWordTranslation();
                                break;
                            case "4":
                                englishRussianDictionary.SearchTranslation();
                                break;
                            case "5":
                                englishRussianDictionary.ExportWords();
                                break;
                            case "0":
                                exit1 = true;
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                                break;
                        }
                    }
                    break;
                case "2":
                    RussianEnglishDictionary russianEnglishDictionary = new RussianEnglishDictionary();
                    bool exit2 = false;
                    while (!exit2)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Русско-английский словарь ===");
                        Console.WriteLine("1. Добавить слово и перевод");
                        Console.WriteLine("2. Заменить слово или перевод");
                        Console.WriteLine("3. Удалить слово или перевод");
                        Console.WriteLine("4. Найти перевод слова");
                        Console.WriteLine("5. Экспорт слов и переводов");
                        Console.WriteLine("0. Выйти");
                        Console.Write("Выберите действие: ");
                        string choice2 = Console.ReadLine();

                        switch (choice2)
                        {
                            case "1":
                                russianEnglishDictionary.AddWordTranslation();
                                break;
                            case "2":
                                russianEnglishDictionary.ReplaceWordTranslation();
                                break;
                            case "3":
                                russianEnglishDictionary.DeleteWordTranslation();
                                break;
                            case "4":
                                russianEnglishDictionary.SearchTranslation();
                                break;
                            case "5":
                                russianEnglishDictionary.ExportWords();
                                break;
                            case "0":
                                exit2 = true;
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                                break;
                        }
                    }
                    break;
                case "3":
                    RussianFrenchDictionary RussianFrenchDictionary = new RussianFrenchDictionary();
                    bool exit3 = false;
                    while (!exit3)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Русскко - французкий словарь ===");
                        Console.WriteLine("1. Добавить слово и перевод");
                        Console.WriteLine("2. Заменить слово или перевод");
                        Console.WriteLine("3. Удалить слово или перевод");
                        Console.WriteLine("4. Найти перевод слова");
                        Console.WriteLine("5. Экспорт слов и переводов");
                        Console.WriteLine("0. Выйти");
                        Console.Write("Выберите действие: ");
                        string choice3 = Console.ReadLine();

                        switch (choice3)
                        {
                            case "1":
                                RussianFrenchDictionary.AddWordTranslation();
                                break;
                            case "2":
                                RussianFrenchDictionary.ReplaceWordTranslation();
                                break;
                            case "3":
                                RussianFrenchDictionary.DeleteWordTranslation();
                                break;
                            case "4":
                                RussianFrenchDictionary.SearchTranslation();
                                break;
                            case "5":
                                RussianFrenchDictionary.ExportWords();
                                break;
                            case "0":
                                exit3 = true;
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                                break;
                        }
                    }
                    break;
                case "4":

                    FrenchRussianDictionary FrenchRussianDictionary = new FrenchRussianDictionary();
                    bool exit4 = false;
                    while (!exit4)
                    {
                        Console.Clear();
                        Console.WriteLine("===  Французко-русский словарь ===");
                        Console.WriteLine("1. Добавить слово и перевод");
                        Console.WriteLine("2. Заменить слово или перевод");
                        Console.WriteLine("3. Удалить слово или перевод");
                        Console.WriteLine("4. Найти перевод слова");
                        Console.WriteLine("5. Экспорт слов и переводов");
                        Console.WriteLine("0. Выйти");
                        Console.Write("Выберите действие: ");
                        string choice4 = Console.ReadLine();

                        switch (choice4)
                        {
                            case "1":
                                FrenchRussianDictionary.AddWordTranslation();
                                break;
                            case "2":
                                FrenchRussianDictionary.ReplaceWordTranslation();
                                break;
                            case "3":
                                FrenchRussianDictionary.DeleteWordTranslation();
                                break;
                            case "4":
                                FrenchRussianDictionary.SearchTranslation();
                                break;
                            case "5":
                                FrenchRussianDictionary.ExportWords();
                                break;
                            case "0":
                                exit4 = true;
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                                break;
                        }
                    }
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}

