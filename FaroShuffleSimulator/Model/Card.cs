public class Card
{
    public int Key { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public override string ToString() => $"{Key}: {Name}";
}