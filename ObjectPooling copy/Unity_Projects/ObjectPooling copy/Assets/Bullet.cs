using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 speed;
    float lifeTime;

    bool isMoving = false;

    //it shouldnt move until its shot


    public void Shoot(Vector3 startingPosition, Vector2 speed, float lifeTime)
    {
        this.gameObject.SetActive(true);
        this.transform.position = startingPosition;
        this.speed = speed;
        this.lifeTime = lifeTime;
        this.isMoving = true;
    }

    public void Stop()
    {
        this.isMoving = false;
        this.gameObject.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(speed.x, speed.y, 0) * Time.deltaTime;
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Stop();
            }
        }
    }
}
