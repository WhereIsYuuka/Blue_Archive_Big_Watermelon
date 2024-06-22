using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FruitCollision : MonoBehaviour
{
    private List<GameObject> fruitList;
    private bool isCollided = false;

    private int thisTag;
    private int collidedTag;
    private string path;

    // Start is called before the first frame update
    void Start()
    {
        fruitList = FruitList.Instance.fruitList;
        thisTag = int.Parse(this.tag);
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
            collidedTag = int.Parse(collidedFruitTag);
            Debug.Log("Tag标签" + collidedTag);
            Debug.Log(fruitList.Count);
            //判断碰撞的大头是否在超出fruitList的范围
            if(collidedTag < fruitList.Count)
            {
                //销毁碰撞的大头和当前大头
                // other.transform.DOScale(0, 0.9f);
                // Destroy(other.gameObject);
                // Debug.Log(other.gameObject + "destroyed");
                //调用DoTween动画
                transform.DOScale(0, 0.3f);
                Tweener tweener = other.transform.DOScale(0, 0.25f);
                //当动画结束时销毁物体
                tweener.OnComplete(() => {
                    Destroy(other.gameObject);
                });
                tweener.OnComplete(() => Destroy(gameObject));
                // Destroy(this.gameObject);   
                Debug.Log(this.gameObject + "destroyed");

                //加分
                ScoreController.Instance.AddScore(5 * collidedTag);

                //生成一个新的大头
                GameObject newFruit = Instantiate(fruitList[collidedTag], collidedFruitPosition.position, Quaternion.identity);
                newFruit.transform.position = collidedFruitPosition.position + new Vector3(UnityEngine.Random.Range(-10, 10) * 0.1f, UnityEngine.Random.Range(-10, 10) * 0.1f, 0);//! 生成物体 使用随机防止同地点击无限堆高

                //小于6的大头不生成音效，减少杂音
                if(thisTag >= 5)
                {
                    //设置生成音效路径
                    //从角色对应语音数量中获取随机数并生成对应音效
                    SoundManager.instance.PlaySpawnSE((thisTag + 1).ToString());
                }

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
