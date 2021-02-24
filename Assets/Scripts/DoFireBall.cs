using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoFireBall : MonoBehaviour
{
    public Text AmmoGUI;
    private int AmmoBox;
    public int BulletCount;
    public Transform spawnPoint;
    public ammo Shell;

    public AudioClip fireSnd;
    public AudioClip emptySnd;
    public AudioClip reloadSnd;
    private AudioSource fire;

    public float Strength;
    void Start()
    {
        fire = this.GetComponent<AudioSource>();
        AmmoBox = BulletCount;
    }


    public float ShootSpeed;
    private float _shootElapsed;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && (Cursor.lockState == CursorLockMode.Locked))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.Mouse0) && (Cursor.lockState == CursorLockMode.Locked))
        {
            if (_shootElapsed <= 0)
            {
                Shoot();
                _shootElapsed = 60 / ShootSpeed;
            }
        }

        AmmoGUI.text = "Снаряды: " + AmmoBox.ToString() + "/" + BulletCount.ToString() ;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (_shootElapsed > 0)
        {
            _shootElapsed -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (AmmoBox > 0)
        {
            var spawnedShell = GameObject.Instantiate(Shell, spawnPoint.position, new Quaternion());
            AmmoBox--;
            spawnedShell.isParent = true;
            var RB = spawnedShell.GetComponent<Rigidbody>();//null
            if (RB != null)
            {
                fire.PlayOneShot(fireSnd);
                Vector3 CudaPulat = GameObject.FindGameObjectWithTag("Actor").transform.forward;
                RB.AddForce(CudaPulat * Strength, ForceMode.Impulse);
            }
        }
        else
        {
            fire.PlayOneShot(emptySnd);
        }
    }


    public void Reload()
    {
        var inv = this.gameObject.GetComponent<Inventory>();
        if (inv != null)
        {
            foreach (var item in inv.Cargo)
            {
                try
                {
                    var ammo = (ItemAmmo)item;
                        //Debug.Log("Это патрон");
                        inv.Cargo.Remove(item);
                        AmmoBox += ammo.ammoCount;
                    break;
                }
                catch(System.Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        else
        {
            AmmoBox = BulletCount;
            fire.PlayOneShot(reloadSnd);
        }
    }
}
