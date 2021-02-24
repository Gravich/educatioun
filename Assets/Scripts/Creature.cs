using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float HP;
    public ParticleSystem Explosion;
    public Vector3 spawnPoint;

    protected virtual void Start()
    {
        spawnPoint = this.transform.position;
    }

    public virtual void TakeDamage(float _damage)
    {
        HP -= _damage;
        if (HP <=0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Instantiate(Explosion, this.transform.position, new Quaternion()).Play();
        SpawnManager.Instanse.Respawn(this);
    }


    public virtual object RespawnData { get; set; }
}
