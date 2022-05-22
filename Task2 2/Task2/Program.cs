// See https://aka.ms/new-console-template for more information

using Broker.Publisher;
using Broker.Subscriber;

namespace Solution;

public class Program
{
    public static void Main(string[] args)
    {
        List<ISubscriber> currSubscribers = new List<ISubscriber>();
        IPublisher countdown = new CountDown();
        string output = "Меню приложения: \n" +
                        "1 - Добавить подписчика \"Подписчик_1\" \n" +
                        "2 - Добавить подписчика \"Подписчик_2\" \n" +
                        "3 - Удалить подписчика \n" +
                        "4 - Оповестить подписчика \n" +
                        "0 - Выйти из программы";
        char input;
        string login, subsList, message;
        ISubscriber currSub;
        double timeout;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(output);
            input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Ввести логин подписчика_1: ");
                    login = Console.ReadLine()!;
                    currSub = new Subscriber_2(login);
                    countdown.AddSubscriber(currSub);
                    currSubscribers.Add(currSub);
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Ввести логин подписчика_2: ");
                    login = Console.ReadLine()!;
                    currSub = new Subsciber_1(login);
                    countdown.AddSubscriber(currSub);
                    currSubscribers.Add(currSub);
                    break;
                case '3':
                    Console.Clear();
                    if (currSubscribers.Count == 0)
                    {
                        break;
                    }
                    subsList = string.Join("\n", currSubscribers.Select((sub, index) => $"{index + 1} - {sub}"));
                    Console.WriteLine("Выбрать номер:");
                    Console.WriteLine(subsList);
                    input = Console.ReadKey().KeyChar;
                    currSub = currSubscribers[input - '1'];
                    countdown.DeleteSubscriber(currSub);
                    currSubscribers.Remove(currSub);
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Введите сообщение для отправки");
                    message = Console.ReadLine()!;
                    Console.WriteLine("Введите через сколько отправить сообщение (in seconds)");
                    while (!double.TryParse(Console.ReadLine()!.Replace('.', ','), out timeout)) { }
                    countdown.NotifySubscribers(message, timeout);
                    Console.WriteLine("Чтобы продолжить нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                case '0':
                    return;
            }
        }
    }
}