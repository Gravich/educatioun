using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveFuel : MonoBehaviour
{
    public ParticleSystem explode;
    public int HP;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.gameObject);
        var tempAmmo = collision.collider.gameObject.GetComponent<ammo>();
        if (tempAmmo != null)
        {
            HP -= 100;
            if (HP<0)
            {
                GameObject.Instantiate(explode, this.transform.position, new Quaternion()).Play();
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
