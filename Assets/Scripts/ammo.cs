using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    public ParticleSystem blast;
    public GameObject shrapnel;
    public float remain;
    public float timerBase;
    public bool isParent;
    public float Damage;

    // Start is called before the first frame update
  
    
    void Awake()
    {
        isParent = false;
        remain = timerBase;
    }

    // Update is called once per frame
    void Update()
    {
        if (remain < 0)
        {
            Babah();
        }
        else
        {
            remain -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var target = collision.gameObject.GetComponent<Creature>();
        if (target)
        {
            target.TakeDamage(Damage);
        }
        Babah();
    }


    private void Babah()
    {
        //if (isParent)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        var temp = GameObject.Instantiate(shrapnel, this.transform.position, new Quaternion());
        //        var RB = temp.GetComponent<Rigidbody>();
        //        if (RB != null)
        //        {
        //            Vector3 randomDirection = new Vector3();
        //            randomDirection.x = Random.Range(0, 1);
        //            randomDirection.y = Random.Range(0, 1);
        //            randomDirection.z = Random.Range(0, 1);
        //            RB.AddForce(randomDirection * 300, ForceMode.Impulse);
        //        }
        //    }
        //}
        GameObject.Instantiate(blast, this.transform.position, new Quaternion()).Play();
        GameObject.Destroy(this.gameObject);
    }
}
