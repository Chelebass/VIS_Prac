using System;
using System.Linq;
using System.Collections.Generic;

class HomeLibrary
{
    public HomeLibrary(string nameBook, string nameAuthor, int yourYear)
    {
        Book = nameBook;
        Author = nameAuthor;
        Year = yourYear;
    }

    public string Book;
    public string Author;
    public int Year;
}

class WorkWithHomeLibrary
{
    public List<HomeLibrary> allBooks = new List<HomeLibrary>();

    public void AddBook(HomeLibrary nameBook)
    {
        allBooks.Add(nameBook);
    }

    public void RemoveBook(HomeLibrary yourBookToRemove)
    {
        allBooks.Remove(yourBookToRemove);
    }

    public List<HomeLibrary> Searching(string thisBook)
    {
        return allBooks.Where(search => search.Book == thisBook).ToList();
    }
    public List<HomeLibrary> Searching(int thisYear)
    {
        return allBooks.Where(search => search.Year == thisYear).ToList();
    }

    public void SortByBookAuthor()
    {
        allBooks.Sort((a, b) => a.Author.CompareTo(b.Author));
    }

    public void SortByYear()
    {
        allBooks.Sort((a, b) => a.Year.CompareTo(b.Year));
    }
}

class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Сколько книг вам необходимо? ");
        WorkWithHomeLibrary library = new WorkWithHomeLibrary();
        int limit = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < limit; i++)
        {
            Console.Write("Название книги: ");
            string nameBook = Console.ReadLine();
            Console.Write("Автор книги: ");
            string nameAuthor = Console.ReadLine();
            Console.Write("Введите год издания: ");
            int yourYear = Convert.ToInt32(Console.ReadLine());
            library.AddBook(new HomeLibrary(nameBook, nameAuthor, yourYear));
            Console.WriteLine(" ");
        }

        while (true)
        {
            Console.Write("\n1 - Добавлениe\n" +
                            "2 - Удаление\n" +
                            "3 - Поиск\n" +
                            "4 - Сортровка \n" +
                            "0 - Завершение работы\n" +
                            "Ответ: ");

            int unswer = Convert.ToInt32(Console.ReadLine());
            switch (unswer)
            {
                case 1:
                    Console.Write("Название книги: ");
                    string nameBook = Console.ReadLine();
                    Console.Write("Автор книги: ");
                    string nameAuthor = Console.ReadLine();
                    Console.Write("Введите год издания: ");
                    int yourYear = Convert.ToInt32(Console.ReadLine());
                    library.AddBook(new HomeLibrary(nameBook, nameAuthor, yourYear));
                    Console.WriteLine("Книга добавлена ");
                    break;

                case 2:
                    Console.Write("Название книги: ");
                    string nameBookForDelete = Console.ReadLine();
                    Console.Write("Автор книги: ");
                    string nameAuthorForDelete = Console.ReadLine();
                    Console.Write("Введите год издания: ");
                    int yearForDelete = Convert.ToInt32(Console.ReadLine());

                    var libraryDeleting = library.Searching(nameBookForDelete)
                        .FirstOrDefault(deleting => deleting.Year == yearForDelete &&
                                                    deleting.Book == nameBookForDelete &&
                                                    deleting.Author == nameAuthorForDelete);
                    library.RemoveBook(libraryDeleting);
                    Console.WriteLine("Книга удалена");
                    break;

                case 3:
                    Console.Write("1 - Поиск по году \n2 - Поиск по названию\nОтвет: ");

                    int searchUnswer = Convert.ToInt32(Console.ReadLine());
                    switch (searchUnswer)
                    {
                        case 1:
                            Console.Write("Введите год издания книги для поиска: ");
                            int yearSearching = Convert.ToInt32(Console.ReadLine());

                            List<HomeLibrary> searchingByYear = library.Searching(yearSearching);

                            foreach (HomeLibrary res in searchingByYear)
                            {
                                Console.Write("данные книги: \n");
                                Console.Write($"Название: {res.Book}\n");
                                Console.Write($"Автор: {res.Author}\n");
                                Console.Write($"Год: {res.Year}\n");
                            }
                            break;

                        case 2:
                            Console.Write("Введите имя название книги для поиска: ");
                            string authorSearching = Console.ReadLine();

                            List<HomeLibrary> booksByName = library.Searching(authorSearching);

                            foreach (HomeLibrary res in booksByName)
                            {
                                Console.Write("данные книги: \n");
                                Console.Write($"Название: {res.Book}\n");
                                Console.Write($"Автор: {res.Author}\n");
                                Console.Write($"Год: {res.Year}\n");
                            }
                            break;
                    }
                    break;

                case 4:
                    Console.Write("1 - Сортровка по автору \n2 - Сортировка по году\nОтвет: ");

                    int sortUnswer = Convert.ToInt32(Console.ReadLine());
                    switch (sortUnswer)
                    {
                        case 1:
                            library.SortByBookAuthor();
                            Console.WriteLine("Книга отсортирована по автору");
                            break;

                        case 2:
                            library.SortByYear();
                            Console.WriteLine("Книга отсортирована по автору");
                            break;
                    }
                    break;

                case 0:
                    Console.Write("Работа завершена");
                    return;
            }
        }
    }
}
