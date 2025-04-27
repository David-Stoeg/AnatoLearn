using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Collections;

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
                isCorrect = rawAnswer.Equals(q.correctAnswer, System.StringComparison.OrdinalIgnoreCase);
                break;
            }

            default: // MultipleChoice
            {
                var selectedOptions = new List<string>();
                for (int i = 0; i < optionToggles.Length; i++)
                    if (optionToggles[i].isOn)
                        selectedOptions.Add(q.options[i]);

                rawAnswer = selectedOptions.Count > 0
                    ? string.Join(", ", selectedOptions)
                    : "";

                int firstSelected = -1;
                for (int i = 0; i < optionToggles.Length; i++)
                    if (optionToggles[i].isOn) { firstSelected = i; break; }

                isCorrect   = (firstSelected == q.correctOptionIndex);
                recordIndex = firstSelected;
                break;
            }
        }

        userAnswers.Add(rawAnswer);
        selectedAnswers.Add(recordIndex);
        questionResults.Add(isCorrect);

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
            DisplayQuestion();
        else
            ShowResults();
    }

    void ShowResults()
    {
        // hide quiz panels
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);

        // hide timer
        timer.gameObject.SetActive(false);

        // show results + finish button
        resultPanel.SetActive(true);
        nextButton.gameObject.SetActive(false);
        finishQuizButton.gameObject.SetActive(true);

        // score text
        scoreText.text = $"You scored {score} of {questions.Count}";

        // show time used:
        float timeUsed = Time.time - quizStartTime;
        int m = Mathf.FloorToInt(timeUsed / 60f);
        int s = Mathf.FloorToInt(timeUsed % 60f);
        // you can reuse scoreText or add a new TMP_Text called timeUsedText
        scoreText.text += $"\nTime: {m:00}:{s:00}";

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        
        // Hide the Time Up panel if it's showing
        timeUpPanel.SetActive(false);
    
        // Hide any question UI panels
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);    // ← hide the fill-in-the-blank panel
        // Show results
        resultPanel.SetActive(true);
        scoreText.text = $"You scored {score} out of {questions.Count}";
    
        if (timerCoroutine != null) StopCoroutine(timerCoroutine);
    }

    public void ShowReview()
    {
        // hide everything else
        resultPanel.SetActive(false);
        questionPanel.SetActive(false);
        matchingQuestionPanel.SetActive(false);
        fillBlankPanel.SetActive(false);

        // hide timer
        timer.gameObject.SetActive(false);

        // show review + finish button
        reviewPanel.SetActive(true);
        finishQuizButton.gameObject.SetActive(true);

        currentReviewIndex = 0;
        DisplayReviewQuestion(currentReviewIndex);
        
        reviewNextButton.interactable = currentReviewIndex < questions.Count - 1;
    }

    void DisplayReviewQuestion(int index)
    {
        var q = questions[index];
        reviewQuestionText.text = $"Q{index + 1}: {q.questionText}";
        reviewProgressText.text = $"Question {index + 1} of {questions.Count}";

        // grab what was stored (could be multiline for matching)
        string userAnswer = userAnswers.Count > index
            ? userAnswers[index]
            : "";

        // if truly empty, show italic "keine Antwort"
        if (string.IsNullOrEmpty(userAnswer))
            userAnswer = "<i>keine Antwort</i>";

        // build the correct-answer display
        string correctAnswer = "";
        if (q.type == QuestionType.MultipleChoice)
        {
            correctAnswer = q.options[q.correctOptionIndex];
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

        reviewUserAnswerText.text    = $"Your Answer:\n{userAnswer}";
        reviewCorrectAnswerText.text = $"Correct Answer:\n{correctAnswer}";

        reviewPrevButton.interactable = (index > 0);
        reviewNextButton.interactable = (index < questions.Count - 1);
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
            timer.text = $"Verbleibende Zeit: {minutes:00}:{seconds:00}";  // Updated format
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
    
        // Also hide timer text and next button
        timer.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        // Setup time-up panel
        infoTitleText.text = "Deine Zeit ist abgelaufen!";
        infoTimeText.text = "";
    
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(ShowResults);
    
        infoPanel.SetActive(true);
    }
    
    public void OnFinishQuizClicked()
    {
        // Here you can decide what happens, for example:
        // - reload the main menu
        // - quit the app
        // - reset the quiz
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // example
    }
}
