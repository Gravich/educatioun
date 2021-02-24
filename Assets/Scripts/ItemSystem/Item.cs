using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemBase config;
    // Start is called before the first frame update
    void Start()
    {
        config = GameObject.Instantiate(config);
    }
}


/*
Стек
 LIFO
Last In First Out

Список
FIFO
First In First Out

 */