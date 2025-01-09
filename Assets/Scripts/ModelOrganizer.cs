using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOrganizer : MonoBehaviour
{
    [HideInInspector]
    public static List<GameObject> models;
    [HideInInspector]
    public static int listPtr;

    private ButtonScripts buttonScripts;

    void Start()
    {
        models = new List<GameObject>();
        int i = 0;
        foreach (Transform child in transform)
        {
            models.Add(child.gameObject);
            if (i != 0)
            {
                models[i].SetActive(false);
            }
            i++;
        }
        listPtr = 0;

        // Get reference to ButtonScripts component
        buttonScripts = FindObjectOfType<ButtonScripts>();
        if (buttonScripts != null && models.Count > 0)
        {
            buttonScripts.SetCurrentModel(models[listPtr]);
        }
    }

    /*
    public void BackOneModel()
    {
        models[listPtr].SetActive(false);
        listPtr = (listPtr - 1 + models.Count) % models.Count;
        models[listPtr].SetActive(true);

        // Update the current model in ButtonScripts
        if (buttonScripts != null)
        {
            buttonScripts.SetCurrentModel(models[listPtr]);
        }
    }

    public void ForwardOneModel()
    {
        models[listPtr].SetActive(false);
        listPtr = (listPtr + 1) % models.Count;
        models[listPtr].SetActive(true);

        // Update the current model in ButtonScripts
        if (buttonScripts != null)
        {
            buttonScripts.SetCurrentModel(models[listPtr]);
        }
    }
    */
}
