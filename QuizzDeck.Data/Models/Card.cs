namespace QuizzDeck.Data.Models;

public class Card
{
    public string Question { get; set; }
    public string[] Answers { get; set; }
    public char CorrectAnswer { get; set; }
}