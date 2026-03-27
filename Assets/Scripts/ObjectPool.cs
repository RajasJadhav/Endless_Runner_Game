using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Dictionary<GameObject, Queue<GameObject>> prefabPools = new Dictionary<GameObject, Queue<GameObject>>;

    private void CreatePool(GameObject prefab , int poolSize)
    {
        Queue<GameObject> newPool = new Queue<GameObject>();

        for(int i=0; i<poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            newPool.Enqueue(obj);
        }
    }
}
