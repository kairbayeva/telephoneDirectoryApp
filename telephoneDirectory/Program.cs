class Program
{
    static void Main()
    {
        ContactManager contactManager = new ContactManager();
        string Path = "contacts.txt"; // Имя файла для сохранения/загрузки контактов

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить контакт");
            Console.WriteLine("2. Найти контакт");
            Console.WriteLine("3. Редактировать контакт");
            Console.WriteLine("4. Удалить контакт");
            Console.WriteLine("5. Вывести список контактов");
            Console.WriteLine("6. Сохранить контакты в файл");
            Console.WriteLine("7. Загрузить контакты из файла");
            Console.WriteLine("8. Выйти из программы");
            Console.WriteLine("9. Показать контакты по группе");


            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Добавление нового контакта
                        Console.Write("Введите имя: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Введите фамилию: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Введите номер телефона: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Введите адрес электронной почты: ");
                        string email = Console.ReadLine();

                        Contact newContact = new Contact
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumber = phoneNumber,
                            Email = email
                        };

                        contactManager.AddContact(newContact);
                        break;

                    case 2:
                        // Поиск контакта
                        Console.Write("Введите запрос для поиска: ");
                        string searchQuery = Console.ReadLine();
                        Contact foundContact = contactManager.FindContact(searchQuery);
                        if (foundContact != null)
                        {
                            Console.WriteLine($"Найден контакт: ID={foundContact.ID}, Имя={foundContact.FirstName}, Фамилия={foundContact.LastName}, Телефон={foundContact.PhoneNumber}, Email={foundContact.Email}");
                        }
                        else
                        {
                            Console.WriteLine("Контакт не найден.");
                        }
                        break;

                    case 3:
                        // Редактирование контакта
                        Console.Write("Введите ID контакта для редактирования: ");
                        if (int.TryParse(Console.ReadLine(), out int editContactID))
                        {
                            Console.Write("Введите новое имя: ");
                            string editedFirstName = Console.ReadLine();
                            Console.Write("Введите новую фамилию: ");
                            string editedLastName = Console.ReadLine();
                            Console.Write("Введите новый номер телефона: ");
                            string editedPhoneNumber = Console.ReadLine();
                            Console.Write("Введите новый адрес электронной почты: ");
                            string editedEmail = Console.ReadLine();

                            Contact editedContact = new Contact
                            {
                                FirstName = editedFirstName,
                                LastName = editedLastName,
                                PhoneNumber = editedPhoneNumber,
                                Email = editedEmail
                            };

                            contactManager.EditContact(editContactID, editedContact);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод ID.");
                        }
                        break;

                    case 4:
                        // Удаление контакта
                        Console.Write("Введите ID контакта для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int removeContactID))
                        {
                            contactManager.RemoveContact(removeContactID);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод ID.");
                        }
                        break;

                    case 5:
                        // Вывод списка контактов
                        contactManager.PrintContacts();
                        break;

                    case 6:
                        // Сохранение контактов в файл
                        contactManager.SaveContactsToFile(Path);
                        break;

                    case 7:
                        // Загрузка контактов из файла
                        contactManager.LoadContactsFromFile(Path);
                        break;

                    case 8:
                        // Выход из программы
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод. Повторите попытку.");
                        break;
                    case 9:
                        // Показать контакты по группе
                        Console.Write("Введите название группы: ");
                        string groupToShow = Console.ReadLine();
                        contactManager.PrintContactsByGroup(groupToShow);
                        break;


                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
            }
        }
    }
}