using UnityEngine;
using System.Collections;
using System;

public class WaypointBehavior : MonoBehaviour
{
    SpriteRenderer sprite = null;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EggBullet")
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - .25f);
            if (sprite.color.a == 0)
            {
                int signX = Math.Sign(UnityEngine.Random.Range(-1, 1));
                int signY = Math.Sign(UnityEngine.Random.Range(-1, 1));
                transform.position= new Vector3(transform.position.x+ signX*15,transform.position.y+signY*15);
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);

            }
        }
    }
}