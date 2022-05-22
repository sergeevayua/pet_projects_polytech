namespace Broker.Subscriber;

public class Subsciber_1 : ISubscriber
{
    private readonly string _login;
    public string Login => $"Subscriber_1 {_login}";

    public Subsciber_1(string login)
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