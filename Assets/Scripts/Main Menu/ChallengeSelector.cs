using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeSelector : MonoBehaviour
{
    public void OnSelectExamPreparation()
    {
        SceneManager.LoadScene("ExamPreparation"); // already there ✅
    }

    public void OnSelectQuiz()
    {
        SceneManager.LoadScene("Quiz"); // ✅ loads the Quiz scene
    }
}
