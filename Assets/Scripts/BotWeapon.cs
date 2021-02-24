using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWeapon : Creature
{
    public Transform ShootPosition;
    public Transform LerpPos;

    public ammo bullet;
    public float Strength;
    public float ShootSpeed;
    private float _shootElapsed;

    protected override void Start()
    {
        base.Start();
        this.GetComponent<Rigidbody>().useGravity = false;
        _shootElapsed = Random.Range(0, 60 / ShootSpeed);
        ShootSpeed = Random.Range(ShootSpeed*0.7f, ShootSpeed*1.3f);
        GameObject parentPos = new GameObject();
        parentPos.transform.parent = LerpPos;
        parentPos.transform.localPosition = this.transform.localPosition;
        LerpPos = parentPos.transform;
        this.transform.parent = null;
    }
    private void Update()
    {
        if (LerpPos)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, LerpPos.position, 0.03f);
            this.transform.forward = Vector3.Lerp(this.transform.forward, LerpPos.transform.forward, 0.01f);
        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
        if (_shootElapsed > 0)
        {
            _shootElapsed -= Time.deltaTime;
        }
    }


    public override void Die()
    {
        Instantiate(Explosion, this.transform.position, new Quaternion()).Play();
        Destroy(this.gameObject);
    }


    public void Shoot()
    {
        if (_shootElapsed <= 0)
        {
            Instantiate(bullet, ShootPosition.position, new Quaternion()).GetComponent<Rigidbody>().AddForce(this.transform.forward*Strength, ForceMode.Impulse);
            _shootElapsed = 60 / ShootSpeed;
        }
    }
}
