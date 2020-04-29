using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    private const float kEggSpeed = 40f;
    private float SpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);

        // Figure out termination
        bool outside = GlobalBehavior.sTheGlobalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds) == GlobalBehavior.WorldBoundStatus.Outside;
        bool timeToDie = (Time.realtimeSinceStartup - SpawnTime) > 1f;
        if (outside || timeToDie)
        {
            Destroy(gameObject);  // this.gameObject, this is destroying the game object
            GlobalBehavior.sTheGlobalBehavior.DestroyAnEgg();
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        OnTriggerEnter2D(collisionData.collider);
    }

    // This function gets called everytime this object collides with another trigger
    private void OnTriggerEnter2D(Collider2D collisionData)
    {
        // is the other object an Enemy?
        if (collisionData.gameObject.CompareTag("Enemy"))
        {
            // then destroy this object
            Destroy(gameObject);
            GlobalBehavior.sTheGlobalBehavior.DestroyAnEgg();
        }
    }
}
