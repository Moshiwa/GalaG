using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public int resistHit;
    public Image[] resistsHits;
    public Color[] resistHitColors;
    public GameObject bullet;
    public GameObject rocket;
    public float shootInterval;
    public float speed;
    public Transform[] targetsShoot;
    public int bulletDmg;
    public int rocketCount;
    public Text rocketCountUI;
    public SoundManager sm;

    private bool isFire;
    private bool isReadyToShoot;
    private float minX = 2.6f;
    private float maxX = 14f;
    private float minY = -4.2f;
    private float maxY = 4.15f;

    void Start()
    {
        isReadyToShoot = true;
        isFire = false;
    }
    void Update()
    {
        rocketCountUI.text = rocketCount.ToString();
        Vector2 curPos = transform.localPosition;
        curPos.y = Mathf.Clamp(transform.localPosition.y, minY, maxY);
        curPos.x = Mathf.Clamp(transform.localPosition.x, minX, maxX);
        transform.localPosition = curPos;

        if (isFire == true && isReadyToShoot == true)
        {
            Shoot();
        }

    }
    public void PaintLIfe() { 
        for(int i = 0; i < resistsHits.Length; i++)
        {
            if(i < resistHit)
            {
                resistsHits[i].color = resistHitColors[0];
            }
            else
            {
                resistsHits[i].color = resistHitColors[1];
            }
        }

    }
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
    public void Shoot()
    {
        if (isReadyToShoot == true)
        {
            foreach (Transform shootTarget in targetsShoot)
            {
                GameObject b = Instantiate(bullet, shootTarget.position, Quaternion.identity);
                if (shootTarget == targetsShoot[targetsShoot.Length - 1])
                {
                    StartCoroutine(ShootDelay());
                }
            }
        }
        sm.PlaySound(3);
    }
    public void RocketShoot()
    {
        if (rocketCount > 0)
        {
            GameObject r = Instantiate(rocket, transform.position, Quaternion.identity);
            rocketCount--;
        }
        sm.PlaySound(2);
    }
    IEnumerator ShootDelay()
    {
        isReadyToShoot = false;
        yield return new WaitForSeconds(shootInterval);
        isReadyToShoot = true;
    }
    public void Fire(bool fire)
    {
        isFire = fire;
    }
    public void GetDamage(int setDamage)
    {
        resistHit = resistHit - setDamage;
        if (resistHit < 0)
        {
            resistHit = 0;
        }
        PaintLIfe();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GetDamage(1);
            Destroy(collision.gameObject);
            sm.PlaySound(1);
        }
    }
   
}
