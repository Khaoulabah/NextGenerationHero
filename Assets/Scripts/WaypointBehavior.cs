using UnityEngine;
using System.Collections;

public class WaypointBehavior : MonoBehaviour
{
    public char character;
    SpriteRenderer sprite = null;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            sprite.enabled = !sprite.enabled;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (sprite.enabled && other.tag == "EggBullet")
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - .25f);
            Destroy(other.gameObject);
            if (sprite.color.a == 0)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);

                float deltaX = Random.Range(-15, 15);
                float deltaY = Random.Range(-15, 15);
                transform.position = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY);
                GlobalBehavior.sTheGlobalBehavior.ObjectClampToWorldBound(transform);
            }
        }
    }
}