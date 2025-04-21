using System;
using System.Collections.Generic;
using System.Linq;

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
    public string questionText;
    public List<string> options;
    public int correctOptionIndex;

    // Matching type
    public bool isMatchingQuestion = false;
    public List<string> leftItems;
    public List<string> rightItems; // shuffled
    public List<int> correctMatchIndices; // left[i] matches right[correctMatchIndices[i]]
}
