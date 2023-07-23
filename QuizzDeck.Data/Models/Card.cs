namespace QuizzDeck.Data.Models;

public class Card
{
    public string Question { get; init; } = "";
    public List<string> Answers { get; init; } = new List<string>();
    public char CorrectAnswer { get; init; }
}