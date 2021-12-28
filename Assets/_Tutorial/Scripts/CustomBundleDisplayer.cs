using com.Neogoma.Stardust.API.Persistence;
using com.Neogoma.Stardust.Datamodel;
using UnityEngine;

namespace com.Neogoma.Stardust.Bundle
{
    /// <summary>
    /// Base extension of <see cref="AbstractBundleDisplayer"/>
    /// </summary>
    public class CustomBundleDisplayer : AbstractBundleDisplayer
    {
        /// <summary>
        /// Object used to display the loading progresses
        /// </summary>
        [Tooltip("GameObject to display when the object is loading")]
        public GameObject progressBg;

        ///<inheritdoc/>
        protected override void ObjectLoadedFailure()
        {
        }
        ///<inheritdoc/>
        protected override void ObjectLoadedSucessfully(GameObject obj)
        {
            progressBg.SetActive(false);
            Debug.Log(obj.name);
            InitObject(CurrentPersistenceModel);
        }
        ///<inheritdoc/>
        protected override void ObjectNotAvailable()
        {
            Debug.LogWarning("This bundle is not available on this platform");
        }

        ///<inheritdoc/>
        protected override void OnDownloadUpdate(float progressEvent)
        {

        }



        /// <summary>
        /// Initialize gameobject.
        /// </summary>
        public void InitObject(PersistentObject persistenObject)
        {
            if(GetComponentInChildren<LetterController>() != null)
            {
                LetterController letterControl = GetComponentInChildren<LetterController>();
                letterControl.LoadText(persistenObject);
            }
            else
            {
                Debug.Log("couldnt find required component");
            }
        }
    }
}
