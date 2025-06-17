public class CardManager
{
    private List<Card> originalCards;
    public List<Card> CurrentCards { get;  set; }

    public CardManager()
    {
        InitializeCards();
    }

    private void InitializeCards()
    {
        string[] suits = { "clubs", "diamonds", "hearts", "spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        int key = 1;

        originalCards = (from suit in suits
                         from rank in ranks
                         select new Card
                         {
                             Key = key++,
                             Name = $"{rank} of {suit}",
                             ImagePath = $"/Images/{rank}_of_{suit}.png"
                         }).ToList();

        CurrentCards = new List<Card>(originalCards);
    }

    public void Shuffle()
    {
        var rnd = new Random();
        CurrentCards = CurrentCards.OrderBy(c => rnd.Next()).ToList();
    }

    public void SortByName()
    {
        CurrentCards = CurrentCards.OrderBy(c => c.Name).ToList();
    }

    public void Reset()
    {
        CurrentCards = new List<Card>(originalCards);
    }

    public IEnumerable<Card> SearchByName(string name)
    {
        return CurrentCards.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}
