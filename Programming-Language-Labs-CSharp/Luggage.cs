// Информация о багаже пассажира описывается массивом, где каждый элемент содержит название единицы багажа(чемодан, сумка, коробка и т.д.) и ее массу.

[Serializable]
public struct Luggage
{
    public string type;
    public double weight;

    // Свойства только для чтения, обеспечивающие доступ к полям структуры
    public string Type { get { return type; } }
    public double Wieght { get { return weight; } }

    // Конструктор для создания объекта Luggage
    public Luggage(string type, double weight)
    {
        this.type = type;
        this.weight = weight;
    }

    // Переопределение метода ToString для красивого вывода информации об багаже
    public override string ToString()
    {
        return "Багаж: '" + type + '\'' + ", Вес: " + weight.ToString();

    }
}

[Serializable]
public class Passenger
{
    private Luggage[] luggageList;

    public Luggage[] LuggageList {
        get
        {
            return luggageList;
        }
        set
        {
            luggageList = value;
        }

    }
}