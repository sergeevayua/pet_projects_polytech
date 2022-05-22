namespace Broker.Subscriber;

public class Subscriber_2 : ISubscriber
{
    
    private readonly string _login;
    public string Login => $"Subscriber_2 {_login}";

    public Subscriber_2(string login)
    {
        _login = login;
    }

    public override string ToString()
    {
        return Login;
    }

    public void Update(string message)
    {
        Console.WriteLine(Login + $" received message \"{message}\"");
    }
}