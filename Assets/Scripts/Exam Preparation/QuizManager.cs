using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public Text questionText;
    public Toggle[] optionToggles;
    public Text[] optionLabels;
    public Button nextButton;

    private int currentQuestionIndex = 0;
    private int score = 0;

    public List<Question> questions = new List<Question>();
    private List<int> selectedAnswers = new List<int>();

    public GameObject questionPanel;
    public GameObject resultPanel;
    public Text scoreText;

    public GameObject matchingQuestionPanel;
    public GameObject leftMatchPrefab;
    public GameObject rightMatchPrefab;
    public Transform leftColumn;
    public Transform rightColumn;
    private List<TMP_Dropdown> currentMatchingDropdowns = new List<TMP_Dropdown>();

    // New review system
    public GameObject reviewPanel;
    public TMP_Text reviewQuestionText;
    public TMP_Text reviewUserAnswerText;
    public TMP_Text reviewCorrectAnswerText;
    public TMP_Text reviewProgressText;
    public Button reviewPrevButton;
    public Button reviewNextButton;

    private int currentReviewIndex = 0;
    
    [Header("Fill-in-the-Blank UI")]
    public GameObject fillBlankPanel;              // assign your new panel
    public TMP_Text fillBlankQuestionText;         // the text object inside it
    public TMP_InputField fillBlankInput;          // the input field
    
    private void Start()
    {
        LoadSampleQuestions();
        DisplayQuestion();
    }

    void LoadSampleQuestions()
    {
        questions.Add(new Question
        {
            questionText = "Which muscle is primarily responsible for flexing the elbow?",
            options = new List<string> { "Triceps brachii", "Biceps brachii", "Deltoid", "Brachioradialis" },
            correctOptionIndex = 1,
            type = QuestionType.MultipleChoice
        });

        questions.Add(new Question
        {
            questionText = "Which muscle helps in shoulder abduction?",
            options = new List<string> { "Trapezius", "Latissimus dorsi", "Deltoid", "Pectoralis major" },
            correctOptionIndex = 2,
            type = QuestionType.MultipleChoice
        });

        questions.Add(new Question
        {
            questionText = "Match the muscle to its function",
            leftItems = new List<string> { "Biceps brachii", "Deltoid", "Triceps brachii" },
            rightItems = new List<string> { "Shoulder abduction", "Elbow flexion", "Elbow extension" },
            correctMatchIndices = new List<int> { 1, 0, 2 },
            type = QuestionType.Matching
        });

        questions.Add(new Question
        {
            questionText = "Fill in the blank: The muscle responsible for shoulder abduction is the ____.",
            correctAnswer = "Deltoid",  // <-- Add correct answer
            type = QuestionType.FillInTheBlank  // <-- Set type
        });
    }

    void DisplayQuestion()
    {
        var q = questions[currentQuestionIndex];
        questionText.text = $"Q{currentQuestionIndex + 1}: {q.questionText}";

        if (q.type == QuestionType.Matching)
        {
            questionPanel.SetActive(false);
            fillBlankPanel.SetActive(false);           // hide fill-blank
            matchingQuestionPanel.SetActive(true);
            DisplayMatchingQuestion(q);
        }
        else if (q.type == QuestionType.FillInTheBlank)
        {
            matchingQuestionPanel.SetActive(false);
            questionPanel.SetActive(false);
            fillBlankPanel.SetActive(true);

            fillBlankQuestionText.text = $"Q{currentQuestionIndex + 1}: {q.questionText}";
            fillBlankInput.text = "";                  // clear previous input
            nextButton.interactable = true;            // can skip or submit at any time
        }
        else // MultipleChoice
        {
            matchingQuestionPanel.SetActive(false);
            fillBlankPanel.SetActive(false);
            questionPanel.SetActive(true);

            for (int i = 0; i < optionToggles.Length; i++)
            {
                optionToggles[i].isOn = false;
                optionLabels[i].text = q.options[i];
            }
        }
    }

    public void OnNextClicked()
    {
        var q = questions[currentQuestionIndex];

        if (q.type == QuestionType.Matching)
        {
            bool allCorrect = true;
            for (int i = 0; i < currentMatchingDropdowns.Count; i++)
            {
                int selected = currentMatchingDropdowns[i].value;
                int correct = q.correctMatchIndices[i];

                if (selected != correct)
                    allCorrect = false;
            }

            if (allCorrect)
                score++;
        }
        else if (q.type == QuestionType.FillInTheBlank)
        {
            // Check the user's input against the correct answer
            string userAnswer = fillBlankInput.text.Trim(); // Assuming you have an input field for this
            if (userAnswer.Equals(q.correctAnswer, System.StringComparison.OrdinalIgnoreCase))
            {
                score++;
            }
        }
        else
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

            if (selected == q.correctOptionIndex)
                score++;

            selectedAnswers.Add(selected != -1 ? selected : -1);
        }

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
        // Hide any question UI panels
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);    // ← hide the fill-in-the-blank panel
        // Show results
        resultPanel.SetActive(true);
        scoreText.text = $"You scored {score} out of {questions.Count}";
    }

    public void ShowReview()
    {
        // Hide any question or results UI
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);    // ← hide the fill-in-the-blank panel
        resultPanel.SetActive(false);
        // Show review
        reviewPanel.SetActive(true);
        currentReviewIndex = 0;
        DisplayReviewQuestion(currentReviewIndex);
    }

    void DisplayReviewQuestion(int index)
    {
        var q = questions[index];
        reviewQuestionText.text    = $"Q{index+1}: {q.questionText}";
        reviewProgressText.text    = $"Question {index+1} of {questions.Count}";

        // reset
        reviewUserAnswerText.text  = "";
        reviewCorrectAnswerText.text = "";

        if (q.type == QuestionType.FillInTheBlank)
        {
            string user = fillBlankInput.text.Trim();
            if (string.IsNullOrEmpty(user))
                user = "<i>No answer</i>";
            reviewUserAnswerText.text   = $"Your Answer: {user}";
            reviewCorrectAnswerText.text = $"Correct Answer: {q.correctAnswer}";
        }
        else if (q.type == QuestionType.MultipleChoice)
        {
            int sel = selectedAnswers[index];
            string user = (sel >= 0 && sel < q.options.Count)
                ? q.options[sel]
                : "<i>No answer</i>";
            reviewUserAnswerText.text   = $"Your Answer: {user}";
            reviewCorrectAnswerText.text = $"Correct Answer: {q.options[q.correctOptionIndex]}";
        }
        else if (q.type == QuestionType.Matching)
        {
            reviewUserAnswerText.text = "Matching Review:";
            string matchReview = "";
            for (int j = 0; j < q.leftItems.Count; j++)
            {
                string left = q.leftItems[j];
                string correct = q.rightItems[q.correctMatchIndices[j]];
                matchReview += $"{left} → {correct}\n";
            }
            reviewCorrectAnswerText.text = matchReview;
        }

        reviewPrevButton.interactable = index > 0;
        reviewNextButton.interactable = index < questions.Count - 1;
    }
    
    public void OnNextReview()
    {
        if (currentReviewIndex < questions.Count - 1)
        {
            currentReviewIndex++;
            DisplayReviewQuestion(currentReviewIndex);
        }
    }

    public void OnPrevReview()
    {
        if (currentReviewIndex > 0)
        {
            currentReviewIndex--;
            DisplayReviewQuestion(currentReviewIndex);
        }
    }

    void DisplayMatchingQuestion(Question q)
    {
        currentMatchingDropdowns.Clear();
        ClearMatchingUI();

        // Build a list where index 0 is “<choose>”
        var placeholder = new List<string> { "" };  
        placeholder.AddRange(q.rightItems);

        for (int i = 0; i < q.leftItems.Count; i++)
        {
            // Left label
            var leftGO = Instantiate(leftMatchPrefab, leftColumn);
            leftGO.GetComponentInChildren<TMP_Text>().text = q.leftItems[i];

            // Right dropdown
            var rightGO = Instantiate(rightMatchPrefab, rightColumn);
            var dd = rightGO.GetComponentInChildren<TMP_Dropdown>();
            dd.ClearOptions();
            dd.AddOptions(placeholder);
            dd.value = 0;           // 0 = the blank placeholder
            dd.RefreshShownValue();

            currentMatchingDropdowns.Add(dd);
        }

        nextButton.interactable = true; // they can skip if they want
    }

    void ClearMatchingUI()
    {
        foreach (Transform child in leftColumn) Destroy(child.gameObject);
        foreach (Transform child in rightColumn) Destroy(child.gameObject);
    }
}
