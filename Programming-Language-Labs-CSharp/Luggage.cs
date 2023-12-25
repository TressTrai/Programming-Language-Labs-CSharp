// Информация о багаже пассажира описывается массивом, где каждый элемент содержит название единицы багажа(чемодан, сумка, коробка и т.д.) и ее массу.

[Serializable]
struct Passenger
{
    private string name;
    private List<(string, int)> luggage;

    public string Name { get { return name; } }
    public List<(string, int)> Luggage { get { return luggage; } }

    public Passenger(string name, List<(string, int)> luggage)
    {
        this.name = name;
        this.luggage = luggage;
    }

    public override string ToString()
    {
        string result = $"Имя: {this.name}\nБагаж:";
        foreach ((string item, int weight) in this.luggage)
        {
            result += $"\n- Предмет: {item}, Масса: {weight}";
        }
        return result;
    }
}