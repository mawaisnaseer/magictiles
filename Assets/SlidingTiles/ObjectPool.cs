using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [System.Serializable]
    public class PoolItem
    {
        public GameObject prefab;
        public int poolSize;
    }

    public List<PoolItem> poolItems;
    private Dictionary<GameObject, Queue<GameObject>> objectPoolDictionary;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InitializeObjectPool();
    }

    private void InitializeObjectPool()
    {
        objectPoolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

        foreach (PoolItem poolItem in poolItems)
        {
            Queue<GameObject> objectPoolQueue = new Queue<GameObject>();

            for (int i = 0; i < poolItem.poolSize; i++)
            {
                GameObject obj = Instantiate(poolItem.prefab);
                obj.SetActive(false);
                objectPoolQueue.Enqueue(obj);
            }

            objectPoolDictionary.Add(poolItem.prefab, objectPoolQueue);
        }
    }

    public GameObject SpawnFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!objectPoolDictionary.ContainsKey(prefab))
        {
            Debug.LogWarning("Prefab not found in Object Pool!");
            return null;
        }

        Queue<GameObject> objectPoolQueue = objectPoolDictionary[prefab];

        if (objectPoolQueue.Count == 0)
        {
            Debug.LogWarning("Pool exhausted for prefab: " + prefab.name);
            return null;
        }

        GameObject obj = objectPoolQueue.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        return obj;
    }

    public void RecycleToPool(GameObject obj)
    {
        obj.SetActive(false);
        if (objectPoolDictionary.ContainsKey(obj))
        {
            objectPoolDictionary[obj].Enqueue(obj);
        }
        else
        {
            Debug.LogWarning("Object not found in Object Pool!");
        }
    }
}
