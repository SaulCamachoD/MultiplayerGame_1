using UnityEngine;
using System.Collections. Generic;

public class Bulletpool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Si no hay objetos disponibles, crea uno nuevo (opcional)
        GameObject newObj = Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }
}
