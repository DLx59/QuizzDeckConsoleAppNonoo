using QuizzDeck.Data.Models;

namespace QuizzDeck;

public static class Program
{
    public static void Main(string[] args)
    {
        StartQuizz();
    }

    private static void StartQuizz()
    {
        var deck = CreateDeck();
        while (deck.Count > 0)
        {
            var currentCard = deck.Pop();
            DisplayQuestion(currentCard);
            var userAnswer = GetValidAnswer(currentCard.Answers.Count);

            Console.WriteLine(userAnswer == currentCard.CorrectAnswer
                ? "Correct!\n"
                : $"Faux! La réponse était {GetAnswer(currentCard.CorrectAnswer)}\n");
        }

        Console.WriteLine("Fin du quizz.");
    }

    private static Stack<Card> CreateDeck()
    {
        var deck = new Stack<Card>();
        deck.Push(new Card
        {
            Question = "Quel célèbre égyptologue a découvert le tombeau de Toutânkhamon ?",
            Answers = new List<string> { "a) Jacques Cartier", "b) Howard Carter", "c) Marco Polo", "d) Napoléon Bonaparte", "e) Dupont Foo" },
            CorrectAnswer = 'b'
        });
        deck.Push(new Card
        {
            Question = "Quelle est la plus grande chaîne de montagnes du monde ?",
            Answers = new List<string> { "a) Les Andes", "b) Les Alpes", "c) Les Rocheuses", "d) L'Himalaya" },
            CorrectAnswer = 'd'
        });
        deck.Push(new Card
        {
            Question = "Quel écrivain français a écrit \"Les Misérables\" ?",
            Answers = new List<string> { "a) Victor Hugo", "b) Gustave Flaubert", "c) Marcel Proust", "d) Albert Camus" },
            CorrectAnswer = 'a'
        });
        return deck;
    }

    private static char GetValidAnswer(int numAnswers)
    {
        var validAnswers = Enumerable.Range(0, numAnswers).ToDictionary(i => ((char)('a' + i)).ToString(), i => (char)('a' + i));

        while (true)
        {
            Console.Write($"Votre réponse ({string.Join(", ", validAnswers.Keys)}) : ");
            var input = Console.ReadLine()?.ToLower();

            if (validAnswers.TryGetValue(input!, out var userAnswer))
            {
                return userAnswer;
            }

            Console.WriteLine("Réponse invalide. Essayez à nouveau.");
        }
    }

    private static string GetAnswer(char answer)
    {
        return $"\"{answer}\"";
    }

    private static void DisplayQuestion(Card card)
    {
        Console.WriteLine(card.Question);
        foreach (var answer in card.Answers)
        {
            Console.WriteLine(answer);
        }
    }
}