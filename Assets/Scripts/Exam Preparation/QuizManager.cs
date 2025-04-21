using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public Text questionText;
    public Toggle[] optionToggles;
    public Text[] optionLabels;
    public Button nextButton;

    private int currentQuestionIndex = 0;
    private int score = 0;

    public List<Question> questions = new List<Question>();
    
    public GameObject resultPanel;
    public Text scoreText;
    public GameObject questionPanel;
    
    private List<int> selectedAnswers = new List<int>();
    
    public GameObject reviewPanel;
    public Transform reviewContentParent;
    public GameObject reviewEntryPrefab;
    
    public GameObject leftMatchPrefab;
    public GameObject rightMatchPrefab;
    public Transform leftColumn;
    public Transform rightColumn;

    private void Start()
    {
        LoadSampleQuestions(); // temporary
        DisplayQuestion();
    }

    void LoadSampleQuestions()
    {
        questions.Add(new Question {
            questionText = "Which muscle is primarily responsible for flexing the elbow?",
            options = new List<string> { "Triceps brachii", "Biceps brachii", "Deltoid", "Brachioradialis" },
            correctOptionIndex = 1
        });

        questions.Add(new Question {
            questionText = "Which muscle helps in shoulder abduction?",
            options = new List<string> { "Trapezius", "Latissimus dorsi", "Deltoid", "Pectoralis major" },
            correctOptionIndex = 2
        });
    }

    void DisplayQuestion()
    {
        var q = questions[currentQuestionIndex];
        questionText.text = $"Q{currentQuestionIndex + 1}: {q.questionText}";

        for (int i = 0; i < optionToggles.Length; i++)
        {
            optionToggles[i].isOn = false;
            optionLabels[i].text = q.options[i];
        }
    }

    public void OnNextClicked()
    {
        int selected = -1;
        for (int i = 0; i < optionToggles.Length; i++)
        {
            if (optionToggles[i].isOn)
            {
                selected = i;
                break;
            }
        }

        if (selected == questions[currentQuestionIndex].correctOptionIndex)
            score++;

        if (selected != -1)
            selectedAnswers.Add(selected);
        else
            selectedAnswers.Add(-1); // in case nothing was selected

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            DisplayQuestion();
        }
        else
        {
            ShowResults();
        }
    }
    
    void ShowResults()
    {
        questionPanel.SetActive(false);
        resultPanel.SetActive(true);
        scoreText.text = $"You scored {score} out of {questions.Count}";
    }
    
    public void ShowReview()
    {
        resultPanel.SetActive(false);
        reviewPanel.SetActive(true);

        for (int i = 0; i < questions.Count; i++)
        {
            GameObject entry = Instantiate(reviewEntryPrefab, reviewContentParent);
            Text[] texts = entry.GetComponentsInChildren<Text>();

            string qText = questions[i].questionText;
            string correctAnswer = questions[i].options[questions[i].correctOptionIndex];
            string selectedAnswer = selectedAnswers[i] != -1 ? questions[i].options[selectedAnswers[i]] : "No answer";

            texts[0].text = $"Q{i + 1}: {qText}";
            texts[1].text = $"Your Answer: {selectedAnswer}";
            texts[2].text = $"Correct Answer: {correctAnswer}";
        }
    }
    
    void DisplayMatchingQuestion(Question q)
    {
        ClearMatchingUI();

        questionText.text = $"Q{currentQuestionIndex + 1}: {q.questionText}";

        for (int i = 0; i < q.leftItems.Count; i++)
        {
            GameObject left = Instantiate(leftMatchPrefab, leftColumn);
            left.GetComponentInChildren<Text>().text = q.leftItems[i];

            GameObject right = Instantiate(rightMatchPrefab, rightColumn);
            Dropdown dropdown = right.GetComponentInChildren<Dropdown>();
            dropdown.ClearOptions();
            dropdown.AddOptions(q.rightItems);
            dropdown.value = 0;
        }
    }

    void ClearMatchingUI()
    {
        foreach (Transform child in leftColumn) Destroy(child.gameObject);
        foreach (Transform child in rightColumn) Destroy(child.gameObject);
    }
}
