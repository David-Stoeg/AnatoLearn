using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Toggle[] optionToggles;
    public Text[] optionLabels;
    public Button nextButton;

    private int currentQuestionIndex = 0;
    private int score = 0;

    public List<Question> questions = new List<Question>();
    private List<int> selectedAnswers = new List<int>();

    public GameObject questionPanel;
    public GameObject resultPanel;
    public Button reviewButton;
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
    
    private float totalTimeSeconds;    // how long we started with
    private float quizStartTime;       // Time.time when quiz started

    [Header("Timer UI")]
    public TMP_Text timer;

    private float timeRemaining;
    private Coroutine timerCoroutine;
    
    [Header("Info Panel (Time Up)")]
    public GameObject infoPanel;
    public TMP_Text infoTitleText;
    public TMP_Text infoTimeText;
    public Button startButton;
    
    public Button finishQuizButton;
    
    [Header("Time Up Panel")]
    public GameObject timeUpPanel;          // Reference to the Time Up Panel
    public TMP_Text timeUpMessageText;      // Reference to the message Text (for the "Deine Zeit ist abgelaufen!" message)
    public Button timeUpResultButton;       // Reference to the Result Button (to show results after time is up)
    
    [Header("Top Info")]
    public TMP_Text difficultyText;

    public TMP_Text matchingQuestionText;
    
    // Track correctness for each question
    private List<bool> questionResults = new List<bool>();

    public Image correctImage;  // Reference to the image for correct (green checkmark)
    public Image wrongImage;    // Reference to the image for wrong (red X)
    
    // Stores the raw string the user entered or selected for each question
    private List<string> userAnswers = new List<string>();
    
    [Header("Result Feedback")]
    public Image resultImage;            // the UI Image where medal/sad icon will appear
    public TMP_Text resultMessageText;   // the text object for the German message

    public Sprite goldMedalSprite;       // ≥ 90%
    public Sprite silverMedalSprite;     // ≥ 75%
    public Sprite bronzeMedalSprite;     // ≥ 50%
    public Sprite sadSprite;             // < 50%
    
    private List<int> incorrectQuestionIndices = new List<int>();
    
    [Header("Review Exit Confirmation")]
    public GameObject confirmExitReviewPanel;
    public Button confirmExitButton;
    public Button cancelExitButton;
    
    [SerializeField] private GameObject mainMenuConfirmPanel;
    
    private void Start()
    {
        // Hide all panels and buttons initially
        questionPanel.SetActive(false);
        resultPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);
        reviewPanel.SetActive(false);
        infoPanel.SetActive(false);
        timeUpPanel.SetActive(false);

        nextButton.gameObject.SetActive(false);
        finishQuizButton.gameObject.SetActive(false);
        
        confirmExitReviewPanel.SetActive(false);  // sicherstellen, dass es aus ist
        confirmExitButton.onClick.AddListener(ExitToMainMenu);
        cancelExitButton.onClick.AddListener(() => confirmExitReviewPanel.SetActive(false));
        
        finishQuizButton.onClick.AddListener(OnFinishQuizClicked);
        confirmExitButton.onClick.AddListener(ExitToMainMenu); // Confirm exit
        cancelExitButton.onClick.AddListener(CloseConfirmPanel); // Cancel exit
    }
    
    // right now only for debugging to stop the timer early
    private void Update()
    {
        // DEBUG shortcut: press "T" to instantly set timeRemaining to 1 second
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (timeRemaining > 1f)
            {
                timeRemaining = 1f;
                Debug.Log("DEBUG: Timer set to 1 second!");
            }
        }
    }

    void DisplayQuestion()
    {
        // always show the timer while in quiz
        timer.gameObject.SetActive(true);
        
        var q = questions[currentQuestionIndex];

        // Activate the Next button (only during quiz)
        nextButton.gameObject.SetActive(true);
        finishQuizButton.gameObject.SetActive(false);

        questionText.text = $"Q{currentQuestionIndex + 1}: {q.questionText}";

        if (q.type == QuestionType.Matching)
        {
            questionPanel.SetActive(false);
            fillBlankPanel.SetActive(false);
            matchingQuestionPanel.SetActive(true);
            DisplayMatchingQuestion(q);
        }
        else if (q.type == QuestionType.FillInTheBlank)
        {
            matchingQuestionPanel.SetActive(false);
            questionPanel.SetActive(false);
            fillBlankPanel.SetActive(true);

            fillBlankQuestionText.text = $"Q{currentQuestionIndex + 1}: {q.questionText}";
            fillBlankInput.text = "";
            nextButton.interactable = true;
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
        
        TMP_Text nextButtonText = nextButton.GetComponentInChildren<TMP_Text>();
        if (currentQuestionIndex == questions.Count - 1)
        {
            nextButtonText.text = "Abschließen"; // or "Finish"
        }
        else
        {
            nextButtonText.text = "Weiter"; // or "Next"
        }
    }

    public void OnNextClicked()
    {
        var q = questions[currentQuestionIndex];
        bool isCorrect = false;
        int recordIndex = -1;
        string rawAnswer = "";

        switch (q.type)
        {
            case QuestionType.Matching:
            {
                var matchResults = new List<string>();
                bool allCorrect = true;

                for (int i = 0; i < currentMatchingDropdowns.Count; i++)
                {
                    string leftItem = q.leftItems[i];
                    int selectedIndex = currentMatchingDropdowns[i].value;

                    // if user left dropdown at default (0), show "keine Antwort" in italics
                    string rightItem = (selectedIndex > 0 && selectedIndex < currentMatchingDropdowns[i].options.Count)
                        ? currentMatchingDropdowns[i].options[selectedIndex].text
                        : "<i>keine Antwort</i>";

                    matchResults.Add($"{leftItem} \u2192 {rightItem}");

                    if (selectedIndex != q.correctMatchIndices[i])
                        allCorrect = false;
                }

                rawAnswer = string.Join("\n", matchResults);
                isCorrect = allCorrect;
                break;
            }

            case QuestionType.FillInTheBlank:
            {
                rawAnswer = fillBlankInput.text.Trim();
                string correct = q.correctAnswer.Trim();  // ensure the correct answer is also trimmed

                isCorrect = string.Equals(rawAnswer, correct, System.StringComparison.OrdinalIgnoreCase);

                // DEBUG LOGGING
                if (!isCorrect)
                {
                    Debug.LogWarning($"Fill-in-the-Blank mismatch: User input = \"{rawAnswer}\", Correct = \"{correct}\"");
                }
                break;
            }

            default: // MultipleChoice
            {
                var selectedOptions = new List<string>();
                var correctOptions = new List<string>();
                // Loop through all the options and check for correct ones
                for (int i = 0; i < optionToggles.Length; i++)
                {
                    if (optionToggles[i].isOn)
                    {
                        selectedOptions.Add(q.options[i]);
                    }

                    // Collect all the correct answers
                    if (q.correctOptionIndices.Contains(i))
                    {
                        correctOptions.Add(q.options[i]);
                    }
                }

                rawAnswer = selectedOptions.Count > 0
                    ? string.Join(", ", selectedOptions)
                    : "";

                // For multiple correct answers, compare with all correct options
                isCorrect = correctOptions.Count == selectedOptions.Count && !correctOptions.Except(selectedOptions).Any();

                recordIndex = selectedOptions.Count > 0 ? 0 : -1; // Don't store anything if no answer is selected
                break;
            }
        }

        userAnswers.Add(rawAnswer);
        selectedAnswers.Add(recordIndex);
        questionResults.Add(isCorrect);

        if (isCorrect)
        {
            score++;
        }
        else if (!incorrectQuestionIndices.Contains(currentQuestionIndex))
        {
            incorrectQuestionIndices = new List<int>();

            for (int i = 0; i < questionResults.Count; i++)
            {
                if (!questionResults[i])
                {
                    incorrectQuestionIndices.Add(i);
                }
            }
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
            DisplayQuestion();
        else
            ShowResults();
    }

    void ShowResults()
    {
        // 1) hide all question UIs
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);
        timer.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        // 2) show result panel and finish button
        resultPanel.SetActive(true);
        finishQuizButton.gameObject.SetActive(true);

        // Check if there are any incorrect answers
        if (incorrectQuestionIndices.Count == 0)
        {
            reviewButton.gameObject.SetActive(false);  // Hide the review button if all answers are correct
        }
        else
        {
            reviewButton.gameObject.SetActive(true);   // Show the review button if there are incorrect answers
        }

        // 3) calculate percentage
        int total = questions.Count;
        float pct = total > 0 ? (100f * score / total) : 0f;

        /*
        // 4) pick message + sprite
        string message;
        Sprite icon;
        if (pct >= 90f)
        {
            message = $"Herzlichen Glückwunsch! Du hast {score} von {total} richtig – eine ausgezeichnete Leistung!";
            icon    = goldMedalSprite;
        }
        else if (pct >= 75f)
        {
            message = $"Sehr gut! Du hast {score} von {total} richtig – weiter so!";
            icon    = silverMedalSprite;
        }
        else if (pct >= 50f)
        {
            message = $"Gut gemacht! Du hast {score} von {total} richtig – da geht noch mehr!";
            icon    = bronzeMedalSprite;
        }
        else
        {
            message = $"Kopf hoch! Du hast {score} von {total} richtig – übe weiter, du schaffst das!";
            icon    = sadSprite;
        }
        */
        
        string message;
        message = $"{score}/{total}";

        // 5) display message + icon
        resultMessageText.text = message;
        //resultImage.sprite     = icon;

        // 6) (optional) still show time used below or elsewhere
        float timeUsed = Time.time - quizStartTime;
        int m = Mathf.FloorToInt(timeUsed / 60f);
        int s = Mathf.FloorToInt(timeUsed % 60f);
        scoreText.text = $"Zeit benötigt: {m:00}:{s:00}";
    }

    public void ShowReview()
    {
        resultPanel.SetActive(false);
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);
        timer.gameObject.SetActive(false);
        timeUpPanel.SetActive(false);

        reviewPanel.SetActive(true);
        finishQuizButton.gameObject.SetActive(true);

        if (incorrectQuestionIndices.Count == 0)
        {
            reviewQuestionText.text = "Alles richtig beantwortet! Keine Fragen zur Überprüfung.";
            reviewUserAnswerText.text = "";
            reviewCorrectAnswerText.text = "";
            reviewProgressText.text = "";
            reviewPrevButton.interactable = false;
            reviewNextButton.interactable = false;
            return;
        }

        currentReviewIndex = 0;
        DisplayReviewQuestion(incorrectQuestionIndices[currentReviewIndex]);
    }

    void DisplayReviewQuestion(int questionIndex)
    {
        var q = questions[questionIndex];
        reviewQuestionText.text = $"Q{questionIndex + 1}: {q.questionText}";
        reviewProgressText.text = $"Frage {currentReviewIndex + 1} von {incorrectQuestionIndices.Count}";

        string userAnswer = userAnswers.Count > questionIndex ? userAnswers[questionIndex] : "";
        if (string.IsNullOrEmpty(userAnswer))
            userAnswer = "<i>keine Antwort</i>";

        string correctAnswer = "";
        if (q.type == QuestionType.MultipleChoice)
        {
            var correctOptions = q.correctOptionIndices.Select(i => q.options[i]).ToList();
            correctAnswer = string.Join(", ", correctOptions);
        }
        else if (q.type == QuestionType.Matching)
        {
            for (int i = 0; i < q.leftItems.Count; i++)
            {
                correctAnswer += $"{q.leftItems[i]} \u2192 {q.rightItems[q.correctMatchIndices[i]]}\n";
            }
        }
        else if (q.type == QuestionType.FillInTheBlank)
        {
            correctAnswer = q.correctAnswer;
        }

        reviewUserAnswerText.text = $"Deine Antwort:\n{userAnswer}";
        reviewCorrectAnswerText.text = $"Richtige Antwort:\n{correctAnswer}";

        reviewPrevButton.interactable = (currentReviewIndex > 0);
        reviewNextButton.interactable = (currentReviewIndex < incorrectQuestionIndices.Count - 1);
    }

    public void OnNextReview()
    {
        if (currentReviewIndex < incorrectQuestionIndices.Count - 1)
        {
            currentReviewIndex++;
            DisplayReviewQuestion(incorrectQuestionIndices[currentReviewIndex]);
        }
        else
        {
            // Letzte Frage erreicht – statt deaktivieren, zeige Bestätigungsdialog
            confirmExitReviewPanel.SetActive(true);
        }
    }

    public void OnPrevReview()
    {
        if (currentReviewIndex > 0)
        {
            currentReviewIndex--;
            DisplayReviewQuestion(incorrectQuestionIndices[currentReviewIndex]);
        }
    }

    void DisplayMatchingQuestion(Question q)
    {
        currentMatchingDropdowns.Clear();
        ClearMatchingUI();

        // SET THE MATCHING QUESTION TEXT
        matchingQuestionText.text = $"Q{currentQuestionIndex + 1}: {q.questionText}";

        var placeholder = new List<string> { "" };  
        placeholder.AddRange(q.rightItems);

        for (int i = 0; i < q.leftItems.Count; i++)
        {
            var leftGO = Instantiate(leftMatchPrefab, leftColumn);
            leftGO.GetComponentInChildren<TMP_Text>().text = q.leftItems[i];

            var rightGO = Instantiate(rightMatchPrefab, rightColumn);
            var dd = rightGO.GetComponentInChildren<TMP_Dropdown>();
            dd.ClearOptions();
            dd.AddOptions(placeholder);
            dd.value = 0;
            dd.RefreshShownValue();

            currentMatchingDropdowns.Add(dd);
        }

        nextButton.interactable = true;
    }
    
    void ClearMatchingUI()
    {
        foreach (Transform child in leftColumn) Destroy(child.gameObject);
        foreach (Transform child in rightColumn) Destroy(child.gameObject);
    }
    
    public void StartQuiz(List<Question> questionsList, float timeSeconds, string difficultyName)
    {
        questions = questionsList;
        totalTimeSeconds = timeSeconds;
        timeRemaining = timeSeconds;
        score = 0;
        currentQuestionIndex = 0;
        selectedAnswers.Clear();

        quizStartTime = Time.time;

        // Show the timer and difficulty text
        timer.gameObject.SetActive(true);
        difficultyText.gameObject.SetActive(true);
        difficultyText.text = $"Schwierigkeit: {difficultyName}";

        if (timerCoroutine != null) StopCoroutine(timerCoroutine);
        if (timeSeconds > 0)
            timerCoroutine = StartCoroutine(TimerRoutine());

        DisplayQuestion();
    }

    IEnumerator TimerRoutine()
    {
        while (timeRemaining > 0)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timer.text = $"Timer: {minutes:00}:{seconds:00}";  // Updated format
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }

        // When time's up, handle what happens next
        ShowTimeUpPopup();
    }

    void ShowTimeUpPopup()
    {
        // Hide any active quiz panels
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);
        reviewPanel.SetActive(false);
        resultPanel.SetActive(false);

        // Hide timer text and next button
        timer.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        // Set up the time up panel
        timeUpMessageText.text = "Deine Zeit ist abgelaufen!";
        timeUpResultButton.onClick.RemoveAllListeners();
        timeUpResultButton.onClick.AddListener(ShowResults);

        // Show the correct time up panel
        timeUpPanel.SetActive(true);
    }
    
    public void OnFinishQuizClicked()
    {
        if (incorrectQuestionIndices.Count == 0)
        {
            // All correct — go straight to main menu
            ExitToMainMenu();
        }
        else
        {
            // Some incorrect — show confirmation panel
            confirmExitReviewPanel.SetActive(true);
        }
    }
    
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void CloseConfirmPanel()
    {
        confirmExitReviewPanel.SetActive(false);  // Close the confirmation panel without doing anything
    }
    
    // Call this when the player clicks "Back to Main Menu" (to show the confirmation)
    public void ShowMainMenuConfirmPanel()
    {
        mainMenuConfirmPanel.SetActive(true);
    }

    // Call this when the player cancels (just hide the panel again)
    public void CancelBackToMainMenu()
    {
        mainMenuConfirmPanel.SetActive(false);
    }
}
