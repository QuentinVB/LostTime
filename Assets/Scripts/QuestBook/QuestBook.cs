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

    public QuestBook(string QuestName, string QuestDescription, bool QuestIsFinished , Dictionary<string, int> QuestStep)
    {
        _questName = QuestName;
        _questDescription = QuestDescription;
        _questIsFnished = QuestIsFinished;
        _questStep = QuestStep;
    }

    private void SetQuestTest()
    {
        Dictionary<string, int> test = new Dictionary<string, int>();
        test.Add("FirstChickenRecup", 0);
        test.Add("SecondChickenRecup", 1);
        test.Add("ThirdChickenRecup", 2);
        test.Add("4CRecup", 3);
        test.Add("5CRecup", 4);


        _questBook.Add(new QuestBook("La Quete du marteau", "Récupérez le marteau du forgeron", false, test));
        _questBook.Add(new QuestBook("aaaaa", "bbbbbbb", false, test));
        _questBook.Add(new QuestBook("ccccccc", "dddddddd", false, test));
        _questBook.Add(new QuestBook("eeeeee", "fffffffff", false, test));
        _questBook.Add(new QuestBook("gggggg", "hhhhhhhhhh", false, test));
        _questBook.Add(new QuestBook("iiiiiiiiii", "jjjjjjjjjjj", false, test));

        _questBook.Add(new QuestBook("Les poulets mécaniques", "Les poulets mécaniques de Julie se sont enfuient. Retrouvez les et rapportez les à Julie", true, test));
        _questBook.Add(new QuestBook("yyyyyy ", "zzzzzzzzzzz", true, test));
        _questBook.Add(new QuestBook("oooooooo", "mmmmmmmmmm", true, test));
        _questBook.Add(new QuestBook("nnnnnnn", "qqqqqqqqqqq", true, test));
        _questBook.Add(new QuestBook("qsdqdqsdqsdqsd", "aazeazeaeaze", true, test));
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
