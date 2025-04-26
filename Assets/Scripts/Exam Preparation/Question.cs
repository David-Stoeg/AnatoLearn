using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MatchingPair
{
    public string left;
    public string right;
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
    public int correctOptionIndex;

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
}
