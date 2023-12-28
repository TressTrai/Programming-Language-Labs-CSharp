// Информация о багаже пассажира описывается массивом, где каждый элемент содержит название единицы багажа(чемодан, сумка, коробка и т.д.) и ее массу.

[Serializable]
struct Passenger // Структура значимый тип, класс - ссылочный тип
{
    private string name;
    private List<(string, int)> baggage;

    public string Name { get { return name; } }
    public List<(string, int)> Baggage { get { return baggage; } }

    public Passenger(string name, List<(string, int)> baggage)
    {
        this.name = name;
        this.baggage = baggage;
    }

    public override string ToString() // Красивый вывод
    {
        string result = $"Имя: {this.name}\nБагаж:";
        int i = 1;
        foreach ((string item, int weight) in this.baggage)
        {
            result += $"\n {i}. Предмет: {item}\n    Вес: {weight} кг";
            i++;
        }
        return result;
    }
}