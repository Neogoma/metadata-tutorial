using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using com.Neogoma.Stardust.API.Relocation;
using com.Neogoma.Stardust.Datamodel;
using com.Neogoma.Stardust.API.Persistence;

namespace com.Neogoma.Stardust.Metadata
{
    public class LetterController : MonoBehaviour
    {
        /// <summary>
        /// Reference to visible text on the letter object.
        /// </summary>
        public TMP_Text letterText;
        /// <summary>
        /// Reference to the input field text
        /// </summary>
        public TMP_InputField letterEditor;
        /// <summary>
        /// Reference to the letter editor gameObject that has the input field and save button.
        /// </summary>
        public GameObject editorCanvas;

        private PersistentObject currentPersistentObject;

        /// <summary>
        /// Opens the letter editor with input field and save button.
        /// Called on the edit button.
        /// </summary>
        public void OpenEditor()
        {
            editorCanvas.SetActive(true);
        }

        /// <summary>
        /// Closes the letter editor
        /// Called the close button
        /// </summary>
        public void CloseEditor()
        {
            editorCanvas.SetActive(false);
        }

        /// <summary>
        /// Responsible for replacing the letter visible text with the text input in the letter editor
        /// Saves the letter text to the model metadata.
        /// </summary>
        public void SaveText()
        {
            letterText.text = letterEditor.text;

            if (currentPersistentObject != null)
            {
                currentPersistentObject.metadata = letterText.text;
                ObjectController.Instance.SaveModel(currentPersistentObject);
            }
        }

        /// <summary>
        ///  Responsible for loading the letter text with the string in the object metadata.
        /// </summary>
        /// <param name="persistentObject"> The Object we want to store the metadata in.</param>
        public void LoadText(PersistentObject persistentObject)
        {
            currentPersistentObject = persistentObject;
            if (persistentObject.metadata != null)
            {
                letterText.text = currentPersistentObject.metadata;
            }
            else //if metadata is null
            {
                letterText.text = "Write something here...";
            }
        }

    }
}

