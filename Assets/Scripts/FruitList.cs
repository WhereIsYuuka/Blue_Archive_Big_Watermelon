using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitList : MonoBehaviour
{
    public List<GameObject> fruitList = new List<GameObject>();
    private static FruitList instance;  //单例模式

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static FruitList Instance
    {
        get { return instance; }
    }
    
    public GameObject GetRandomFruit()
    {
        if(fruitList.Count == 0)
        {
            return null;
        }

        return fruitList.Count >= 5 ? fruitList[Random.Range(0, 5)] : fruitList[Random.Range(0, fruitList.Count)];
    }
}
