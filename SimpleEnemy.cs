using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public int resistHit;
    public GameObject bullet;
    public float shootInterval;
    public Transform targetShoot;
    public ShipController ship;
    public bool isDead = false;
    public SoundManager sm;
    void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        ship = GameObject.Find("Spaceship").GetComponent<ShipController>();
        InvokeRepeating("Shoot", 2, shootInterval);
    }
    private void Update()
    {
            if (resistHit == 0 && !isDead)
            {
                Death();
            }
    }
    void Death()
    {
        isDead = true;
        Destroy(gameObject);
        sm.PlaySound(0);
    }
    void Shoot()
    {
        GameObject b = Instantiate(bullet, targetShoot.position, Quaternion.identity);
    }

    public void GetDamage(int setDamage)
    {
        resistHit = resistHit - setDamage;
        if(resistHit < 0)
        {
            resistHit = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            GetDamage(ship.bulletDmg);
            Destroy(collision.gameObject);
            sm.PlaySound(1);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GetDamage(1);
            Destroy(collision.gameObject);
            sm.PlaySound(1);
        }
    }
     
}
