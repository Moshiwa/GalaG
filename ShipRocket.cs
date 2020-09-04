using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRocket : MonoBehaviour
{
    public SoundManager sm;
    private void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<SimpleEnemy>().GetDamage(10);
            Destroy(gameObject);
            sm.PlaySound(0);

        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
        if (collision.gameObject.CompareTag("Mine"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
    }
}
