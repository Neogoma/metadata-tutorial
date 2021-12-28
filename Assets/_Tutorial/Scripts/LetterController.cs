using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using com.Neogoma.Stardust.API.Relocation;
using com.Neogoma.Stardust.Datamodel;
using com.Neogoma.Stardust.API.Persistence;

public class LetterController : MonoBehaviour
{
    public TMP_Text letterText;
    public TMP_InputField letterEditor;
    public GameObject editorCanvas;
    
    private PersistentObject currentPersistentObject;

    public void OpenEditor()
    {
        editorCanvas.SetActive(true);
    }

    public void CloseEditor()
    {
        editorCanvas.SetActive(false);
    }
    public void SaveText()
    {
        letterText.text = letterEditor.text;

        if (currentPersistentObject != null)
        {
            currentPersistentObject.metadata = letterText.text;
            ObjectController.Instance.SaveModel(currentPersistentObject);
        }
    }

    public void LoadText(PersistentObject persistentObject)
    {
        currentPersistentObject = persistentObject;
        if (persistentObject.metadata != null)
        {
             letterText.text = currentPersistentObject.metadata;
        }
        else //if meta is null
        {
            letterText.text = "Write something here...";
        }
    }

}

