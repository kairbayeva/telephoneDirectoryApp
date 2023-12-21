using System;
namespace TelephoneDirectoryApp
{
    public class ContactManager
    {
        private List<Contact> contacts;

        public ContactManager()
        {
            // Инициализация коллекции при создании экземпляра менеджера контактов
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            Console.Write("Введите группу контакта (например, 'Семья', 'Друзья', 'Работа'): ");
            contact.Group = Console.ReadLine();
            // Генерация уникального ID для контакта
            contact.ID = contacts.Count + 1;
            contacts.Add(contact);
            Console.WriteLine("Контакт успешно добавлен.");
        }

        public Contact FindContact(string searchQuery)
        {
            // Поиск контакта по имени, фамилии, номеру телефона или электронной почте
            return contacts.FirstOrDefault(contact =>
                contact.FirstName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                contact.LastName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                contact.PhoneNumber.Contains(searchQuery) ||
                contact.Email.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveContact(int contactID)
        {
            // Удаление контакта по ID
            Contact contactToRemove = contacts.FirstOrDefault(contact => contact.ID == contactID);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Контакт успешно удален.");
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }

        public void EditContact(int contactID, Contact updatedContact)
        {
            // Редактирование контакта по ID
            Contact contactToEdit = contacts.FirstOrDefault(contact => contact.ID == contactID);
            if (contactToEdit != null)
            {
                contactToEdit.FirstName = updatedContact.FirstName;
                contactToEdit.LastName = updatedContact.LastName;
                contactToEdit.PhoneNumber = updatedContact.PhoneNumber;
                contactToEdit.Email = updatedContact.Email;
                Console.WriteLine("Контакт успешно отредактирован.");
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }
        public void PrintContactsByGroup(string group)
        {
            // Вывод контактов для указанной группы
            var groupedContacts = contacts.Where(contact => contact.Group.Equals(group, StringComparison.OrdinalIgnoreCase));

            if (groupedContacts.Any())
            {
                Console.WriteLine($"Контакты в группе '{group}':");
                foreach (var contact in groupedContacts)
                {
                    Console.WriteLine($"ID: {contact.ID}, Имя: {contact.FirstName}, Фамилия: {contact.LastName}, Телефон: {contact.PhoneNumber}, Email: {contact.Email}");
                }
            }
            else
            {
                Console.WriteLine($"Контакты в группе '{group}' не найдены.");
            }
        }

        public void PrintContacts()
        {
            // Вывод списка всех контактов
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.ID}, Имя: {contact.FirstName}, Фамилия: {contact.LastName}, Телефон: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }

        public void SaveContactsToFile(string filePath)
        {
            // Сохранение контактов в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.ID},{contact.FirstName},{contact.LastName},{contact.PhoneNumber},{contact.Email}");
                }
            }
            Console.WriteLine("Контакты успешно сохранены в файл.");
        }

        public void LoadContactsFromFile(string filePath)
        {
            // Загрузка контактов из файла
            contacts.Clear(); // Очистка текущего списка контактов
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] contactData = line.Split(',');
                        if (contactData.Length == 5)
                        {
                            Contact contact = new Contact
                            {
                                ID = int.Parse(contactData[0]),
                                FirstName = contactData[1],
                                LastName = contactData[2],
                                PhoneNumber = contactData[3],
                                Email = contactData[4]
                            };
                            contacts.Add(contact);
                        }
                    }
                }
                Console.WriteLine("Контакты успешно загружены из файла.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке контактов из файла: {ex.Message}");
            }
        }
    }
}

