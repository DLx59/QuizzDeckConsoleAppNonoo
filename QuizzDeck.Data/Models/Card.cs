namespace QuizzDeck.Data.Models;

public class Card
{
    public string Question { get; init; } = "";
    public List<string> Answers { get; init; } = new List<string>();
    public int CorrectAnswer { get; init; }

    public Card()
    {
        if ((CorrectAnswer - 1) >= Answers.Count)
            throw new ArgumentException("L'index de la réponse correcte dépasse la longueur du tableau des réponses.");
    }
}