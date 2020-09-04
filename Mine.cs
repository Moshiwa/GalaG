using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject ship;
    public float distToActive;
    public float speed;
    public SoundManager sm;
   
    void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        ship = GameObject.Find("Spaceship");
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, ship.transform.position) < distToActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, ship.transform.position, Time.deltaTime * speed);
        }
        if (Vector2.Distance(transform.position, ship.transform.position) <= 0.5f)
        {
            ship.GetComponent<ShipController>().GetDamage(3);
            sm.PlaySound(0);
            Destroy(gameObject);
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
        }
    }
}
