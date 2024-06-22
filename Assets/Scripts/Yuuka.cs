using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuuka : MonoBehaviour
{
    private int thisTag;
    private int collidedTag;
    private bool couldDestroy = true;
    public Sprite newSprite;
    public Rigidbody2D rb;
    
    private void Awake() {
        // 获取当前物体的tag
        thisTag = int.Parse(this.tag);
    }
    void Start()
    {
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        //如果碰撞的物体是墙或者碰撞的物体的tag大于当前物体的tag，则不销毁
        if(!couldDestroy)
            return;
        if(other.transform.tag == "Wall" || thisTag < int.Parse(other.transform.tag))
        {
            couldDestroy = false;
            return;
        }
        collidedTag = int.Parse(other.transform.tag);
        if(collidedTag < thisTag)
        {
            //加分
            ScoreController.Instance.AddScore(5 * collidedTag);
            //销毁碰撞的物体,并播放音效
            SoundManager.instance.PlayDestorySE(collidedTag.ToString());
            Destroy(other.gameObject);
        }

    }

    private void ChangeSprite()
    {
        // 获取所有带有"05"tag的物件
        GameObject[] objectsWithTag05 = GameObject.FindGameObjectsWithTag("05");
        //如果不为空
        if (objectsWithTag05.Length == 0)
        {
            return;
        }
        else
        {
            // SoundManager.instance.PlayDestorySE("5");
            // 遍历这些物件并更换它们的Sprite
            foreach (GameObject obj in objectsWithTag05)
            {
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = newSprite; // 更换Sprite
                }
            }

        }
    }
}
