using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollision : MonoBehaviour
{
    private List<GameObject> fruitList;
    private bool isCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        fruitList = FruitList.Instance.fruitList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == this.tag && !isCollided && other.gameObject.GetComponent<FruitCollision>().GetCollided() == false)
        {
            isCollided = !isCollided;
            //设置碰撞的大头已经碰撞
            other.gameObject.GetComponent<FruitCollision>().SetCollided();
            //获取碰撞的大头的位置
            Transform collidedFruitPosition = other.transform;
            string collidedFruitTag = other.transform.tag;
            Debug.Log(int.Parse(collidedFruitTag));
            Debug.Log(fruitList.Count);
            //判断碰撞的大头是否在超出fruitList的范围
            if(int.Parse(collidedFruitTag) < fruitList.Count)
            {
                //销毁碰撞的大头和当前大头
                Destroy(other.gameObject);
                Debug.Log(other.gameObject + "destroyed");
                Destroy(this.gameObject);   
                Debug.Log(this.gameObject + "destroyed");

                //加分
                ScoreController.Instance.AddScore(5 * (int.Parse(collidedFruitTag)));

                //生成一个新的大头
                GameObject newFruit = Instantiate(fruitList[int.Parse(collidedFruitTag)], collidedFruitPosition.position, Quaternion.identity);
                newFruit.transform.position = collidedFruitPosition.position + new Vector3(UnityEngine.Random.Range(-10, 10) * 0.1f, UnityEngine.Random.Range(-10, 10) * 0.1f, 0);//! 生成物体 使用随机防止同地点击无限堆高

                //设置新大头的刚体受到物理引擎的影响
                newFruit.GetComponent<Rigidbody2D>().simulated = true;

            }
        }
    }

    public void SetCollided()
    {
        this.isCollided = !isCollided;
    }

    public bool GetCollided()
    {
        return this.isCollided;
    }
}
