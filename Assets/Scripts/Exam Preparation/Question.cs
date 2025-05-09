using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MatchingPair
{
    public string left;
    public string right;
}

[Serializable]
public class QuestionData
{
    public string type;
    public string questionText;
    public List<string> options;
    public List<int> correctOptionIndices;  // Change this from int to List<int>
    public List<string> leftItems;
    public List<string> rightItems;
    public List<int> correctMatchIndices;
    public string correctAnswer;
}

[Serializable]
public class QuestionDatabase
{
    public List<QuestionData> questions;
}

public enum QuestionType
{
    MultipleChoice,
    Matching,
    FillInTheBlank
}

[System.Serializable]
public class Question
{
    public QuestionType type;
    public string questionText;

    // Multiple choice
    public List<string> options;
    public List<int> correctOptionIndices;  // Change this from int to List<int>

    // Matching
    public List<string> leftItems;
    public List<string> rightItems; // shuffled
    public List<int> correctMatchIndices; // left[i] matches right[correctMatchIndices[i]]

    // Fill in the blank (if you plan to use it)
    public string correctAnswer;

    // Helper properties
    public bool IsMultipleChoice => type == QuestionType.MultipleChoice;
    public bool IsMatching => type == QuestionType.Matching;
    public bool IsFillInTheBlank => type == QuestionType.FillInTheBlank;
    
    public static Question FromData(QuestionData d)
    {
        var q = new Question {
            questionText = d.questionText,
            type = Enum.Parse<QuestionType>(d.type),
            options = d.options,
            correctOptionIndices = d.correctOptionIndices,  // Use List<int> for multiple correct answers
            leftItems = d.leftItems,
            rightItems = d.rightItems,
            correctMatchIndices = d.correctMatchIndices,
            correctAnswer = d.correctAnswer
        };
        return q;
    }
}
