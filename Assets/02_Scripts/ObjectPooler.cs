using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject objectItem;
    [SerializeField] int poolSize = 10;

    List<GameObject> itemList = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            itemList.Add(Instantiate(objectItem));
            itemList[i].SetActive(false);
        }
    }
    public GameObject SpawnObject(Vector3 position, Quaternion rotation)
    {
        GameObject obj;

        if (itemList.Count > 0)
        {
            obj = itemList[0];
            itemList.RemoveAt(0);
        }
        else
        {
            obj = Instantiate(objectItem);
        }
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        
        return obj;
    }
   public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        itemList.Add(obj);
    }
}
