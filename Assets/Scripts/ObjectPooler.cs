using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool_class
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion



    public List<Pool_class> pools_List;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        NewQueue();
    }

    void NewQueue()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool_class pool in pools_List)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectpool);
        }
    }


    public GameObject SpawnFromPool(string tag,Vector2 position, Quaternion rotation)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null; 
        }

        GameObject objectToSpawn= poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        StartCoroutine(Requeue(2f, tag, objectToSpawn));
        return objectToSpawn;
    }

    IEnumerator Requeue(float time, string tag, GameObject objectpool)
    {
        yield return new WaitForSeconds(time);
        poolDictionary[tag].Enqueue(objectpool);
        objectpool.SetActive(false);
    }



}
