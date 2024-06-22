using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour
{
    private bool isSpawned = false; //用于判断是否已经生成了大头
    private bool couldSpawn = true; //用于判断是否可以放下大头
    private GameObject fruit; //用于存储生成的大头
    public GameObject specialFruit; //用于存储特殊大头
    private float time; //用于计时
    private int thisTag; //用于存储生成的大头的tag
    private string path; //用于存储音效路径


    // Update is called once per frame
    void Update()
    {   
        //如果生成的大头已经存在，则不再生成大头
        if(time < 0.5f)
        {
            time += Time.deltaTime;
        }
        else
        {
            //如果没有生成大头，则生成大头
            if(!isSpawned)
            {
                SpawnFruit();
            }

            if(Input.GetMouseButton(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() ||
                    EventSystem.current.currentSelectedGameObject != null)
                {
                    couldSpawn = false;
                    return;
                }
                couldSpawn = true;
                //获取鼠标点击的位置
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //将大头的y坐标设置为与生成器的y坐标相同    
                fruit.transform.position = new Vector3(mousePosition.x, transform.position.y, 0);
            }

            if(Input.GetMouseButtonUp(0) && couldSpawn)
            {
                //simulated属性用于控制刚体是否受到物理引擎的影响
                fruit.GetComponent<Rigidbody2D>().simulated = true;
                //将大头对象置空
                fruit = null;
                //改变isSpawned的值，使得下一次可以生成大头
                isSpawned = !isSpawned;
                //重置time
                time = 0;
            }
        }
    }

    private void SpawnFruit()
    {
        GameObject theFruit;
        //设置一个百分之三的概率生成一个特殊大头
        if(Random.Range(0, 100) < 3)
        {
            //获取一个随机特殊大头
            theFruit = specialFruit;
            if(theFruit != null)
            {
                //生成特殊大头
                fruit = Instantiate(theFruit, transform.position, Quaternion.identity);
                //设置生成音效
                thisTag = int.Parse(fruit.tag);
                SoundManager.instance.PlaySpawnSE(thisTag.ToString() + "_2");
                Debug.Log("PlayFX:" + path);
                isSpawned = !isSpawned;
            }
            return;
        }
        else
        {
            //获取一个随机大头
            theFruit = FruitList.Instance.GetRandomFruit();
            if(theFruit != null)
            {
                //生成大头
                fruit = Instantiate(theFruit, transform.position, Quaternion.identity);
                
                //设置生成音效
                thisTag = int.Parse(fruit.tag);
                SoundManager.instance.PlaySpawnSE(thisTag.ToString());
                Debug.Log("PlayFX:" + path);

                isSpawned = !isSpawned;
            }
        }
    }
}
