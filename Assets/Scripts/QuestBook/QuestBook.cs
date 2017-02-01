using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBook : MonoBehaviour {

    List<QuestBook> _questBook;

    private string _questName;
    private string _questDescription;
    private bool _questIsFnished;
    private Dictionary<string, int> _questStep;

    private void Start()
    {
        _questBook = new List<QuestBook>();
        _questStep = new Dictionary<string, int>();
        SetQuestTest();
    }

    public QuestBook(string QuestName, string QuestDescription, bool QuestIsFinished, Dictionary<string, int> QuestStep)
    {
        _questName = QuestName;
        _questDescription = QuestDescription;
        _questIsFnished = QuestIsFinished;
        _questStep = QuestStep;
    }

    private void SetQuestTest()
    {
        Dictionary<string, int> test = new Dictionary<string, int>();
        test.Add("FirstChicken Recup", 0);
        test.Add("SecondChickenRecup", 0);
        test.Add("ThirdChickenRecup", 0);
        test.Add("4CRecup", 0);
        test.Add("5CRecup", 0);

        _questBook.Add(new QuestBook("Le Marteau du Forgeron", "Retrouvez le Marteau du Forgeron perdu dans la ville", false, test));
        _questBook.Add(new QuestBook("Panique chez les poulets", "Récupérez les poulets mécaniques de Julie", false, test));
        _questBook.Add(new QuestBook("La fuite du temps", "Réunissez les 6 morceaux de l'horloge", false, test));
        _questBook.Add(new QuestBook("Tutoriel", "Découvrez l'univers et les fonctionnalités du jeu", true, test));
        _questBook.Add(new QuestBook("Premier Pas", "Lancer le jeu avec succès", true, test));

    }

    public List<QuestBook> GetQuestBook
    {
        get { return _questBook; }
    }

    public string GetQuestName
    {
        get { return _questName; }
    }

    public string GetQuestDescription
    {
        get { return _questDescription; }
    }

    public bool GetQuestIsFinished
    {
        get { return _questIsFnished; }
        set { _questIsFnished = value; }
    }

    public Dictionary<string, int> GetQuestStep
    {
        get { return _questStep; }
    }

}
