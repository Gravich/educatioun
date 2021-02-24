using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : Creature
{
    public static Actor Instanse;
    protected override void Start()
    {
        base.Start();
        Instanse = this;
    }
}
