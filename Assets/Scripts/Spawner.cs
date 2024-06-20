﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool isSpawned = false; //用于判断是否已经生成了水果
    private GameObject fruit; //用于存储生成的水果


    // Update is called once per frame
    void Update()
    {
        //如果没有生成水果，则生成水果
        if(!isSpawned)
        {
            SpawnFruit();
        }

        if(Input.GetMouseButton(0))
        {
            //获取鼠标点击的位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //将水果的y坐标设置为与生成器的y坐标相同    
            fruit.transform.position = new Vector3(mousePosition.x, transform.position.y, 0);
        }

        if(Input.GetMouseButtonUp(0))
        {
            //simulated属性用于控制刚体是否受到物理引擎的影响
            fruit.GetComponent<Rigidbody2D>().simulated = true;
            //将水果对象置空
            fruit = null;
            //改变isSpawned的值，使得下一次可以生成水果
            isSpawned = !isSpawned;
        }
    }

    private void SpawnFruit()
    {
        //获取一个随机水果
        GameObject theFruit = FruitList.Instance.GetRandomFruit();
        if(theFruit != null)
        {
            //生成水果
            fruit = Instantiate(theFruit, transform.position, Quaternion.identity);
            isSpawned = !isSpawned;
        }
    }
}