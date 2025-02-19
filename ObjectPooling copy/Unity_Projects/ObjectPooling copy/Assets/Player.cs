using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField allows you to see the variable in the inspector in this case UNITY

    [SerializeField] Bullet bulletPrefab;

    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float bulletLifeTime = 2f;
    [SerializeField] float shootRate = 0.5f;


    float originalShootRate;

    int bulletShot = 0;

    Bullet[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        originalShootRate = shootRate;
        // object pooling
        bullets = new Bullet[100];
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            bullets[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        shootRate -= Time.deltaTime;
        if (shootRate <= 0)
        // i want random speed bullets
        {
            Vector2 randomSpeed = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * bulletSpeed;

            // get bullet from bullet pool
            Bullet bullet = null;
            for (int i = 0; i < bullets.Length; i++)
            {
                if (!bullets[i].gameObject.activeInHierarchy)
                {
                    bullet = bullets[i];
                    break;
                }
            }
            
            if (bullet != null)
            {
                bullet.Shoot(transform.position, randomSpeed, bulletLifeTime);
                bulletShot++;
                BulletEvents.bulletFired.Invoke(bulletShot);
            } 
            
            shootRate = originalShootRate;

        }


    }
}
