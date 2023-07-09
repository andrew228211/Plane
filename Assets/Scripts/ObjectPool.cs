using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public Enemy prefab;
        public int size;
    }
    #region singleton
    public static ObjectPool instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<Enemy>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<Enemy>>();
        foreach (Pool pool in pools)
        {
            Queue<Enemy> objectPool = new Queue<Enemy>();
            for (int i = 0; i < pool.size; i++)
            {
                Enemy obj = Instantiate(pool.prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public Enemy SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Dont have" + tag + " key");
            return null;
        }
        Enemy objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;

    }
}
