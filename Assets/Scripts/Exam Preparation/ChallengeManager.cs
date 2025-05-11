using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class ChallengeManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject chooseDifficultyPanel;
    public GameObject infoPanel;

    [Header("Info Panel UI")]
    public TMP_Text infoTitleText;
    public TMP_Text infoTimeText;
    public Button startButton;

    // Reference to your QuizManager
    public QuizManager quizManager;

    private List<Question> allQuestions;
    private List<Question> sessionQuestions;
    private float sessionTimeMinutes;
    
    private string sessionDifficultyName;

    void Start()
    {
        var ta = Resources.Load<TextAsset>("questions");
        var db = JsonUtility.FromJson<QuestionDatabase>(ta.text);
        allQuestions = db.questions.Select(d => Question.FromData(d)).ToList();

        // Only work with chooseDifficultyPanel and infoPanel
        chooseDifficultyPanel.SetActive(true);  // show difficulty options
        infoPanel.SetActive(false);              // hide info panel at start
    }

    // Called by Klausurvorbereitung button
    public void OnExamPrepMode()
    {
        chooseDifficultyPanel.SetActive(true);
    }

    // Difficulty buttons
    public void OnEasy()
    {
        sessionDifficultyName = "Einfach";
        SetupSession(10);
    }

    public void OnMedium()
    {
        sessionDifficultyName = "Mittel";
        SetupSession(20);
    }

    public void OnHard()
    {
        sessionDifficultyName = "Schwer";
        SetupSession(40);
    }

    void SetupSession(int count)
    {
        // shuffle and take 'count'
        sessionQuestions = allQuestions
            .OrderBy(_ => Random.value)
            .Take(count)
            .ToList();

        sessionTimeMinutes = count; // 1 minute per question
        chooseDifficultyPanel.SetActive(false);

        // show info
        infoTitleText.text = "Los geht’s!";
        infoTimeText.text = $"Beantworte {sessionQuestions.Count} Fragen in {sessionTimeMinutes} Minuten.";
        infoPanel.SetActive(true);
    }

    // Called by InfoPanel.Start button
    public void OnStartSession()
    {
        infoPanel.SetActive(false);
        quizManager.StartQuiz(sessionQuestions, sessionTimeMinutes * 60f, sessionDifficultyName);
    }
}
