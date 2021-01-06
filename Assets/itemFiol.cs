using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFiol : itemRed
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var spawned = GameObject.Instantiate<GameObject>(test, this.transform.position, new Quaternion());
    }
}
