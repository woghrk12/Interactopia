using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PreparePool : MonoBehaviour
{
    public List<GameObject> Prefabs;
    private void Awake()
    {
        DefaultPool pool = PhotonNetwork.PrefabPool as DefaultPool;

        if (pool != null && this.Prefabs!=null) 
        {
            foreach(GameObject prefab in this.Prefabs)
            {
                pool.ResourceCache.Add(prefab.name, prefab);
            }
        }
    }
}
