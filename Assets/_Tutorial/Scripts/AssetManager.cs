using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.Neogoma.Stardust.API.Relocation;
using Neogoma.Stardust.Demo.Navigator;
using com.Neogoma.Stardust.Datamodel;
using com.Neogoma.Stardust.API.Persistence;
using com.Neogoma.Stardust.Bundle;
public class AssetManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Session session;
    private static AssetManager _instance;
    public static AssetManager Instance { get { return _instance; } }

    private PersistentObject[] requestedMapObjects;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void MapDownloaded(Session arg0, GameObject arg1)
    {
        this.session = arg0;
    }

    public void GetMap(PersistentObject[] objects)
    {
        requestedMapObjects = objects;
    }
}
