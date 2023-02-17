using com.Neogoma.Stardust.API.Persistence;
using com.Neogoma.Stardust.Datamodel;
using com.Neogoma.Stardust.Metadata;
using Siccity.GLTFUtility;
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

        protected override GameObject LoadGLBFile(string filepath)
        {
            ImportSettings settings = new ImportSettings();
            settings.useLegacyClips = true;
            AnimationClip[] animations;
            GameObject loadedObject = Importer.LoadFromFile(filepath, settings, out animations, Format.AUTO);

            if (animations.Length > 0)
            {
                Animation anim = loadedObject.AddComponent<Animation>();
                animations[0].legacy = true;
                anim.AddClip(animations[0], animations[0].name);
                anim.clip = anim.GetClip(animations[0].name);
                anim.wrapMode = WrapMode.Loop;
                anim.Play();
            }


            return loadedObject;
        }

        ///<inheritdoc/>
        protected override void ObjectLoadedSucessfully(GameObject obj,PersistentObject persistentObject)
        {
            progressBg.SetActive(false);
            InitObject(persistentObject);
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
        /// Called when we finish loading an object successfully.
        /// Checks if the bundle holder prefab contains, in it's child objects the gameObject with
        /// the Letter Controller component we are looking for and Loads text passing a reference to the correct object.
        /// </summary>
        /// <param name="persistenObject"> The Loaded Object</param>
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
