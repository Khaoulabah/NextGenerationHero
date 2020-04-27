using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroBehavior : MonoBehaviour {

    public EggStatSystem mEggStat = null;
    public float mHeroSpeed = 20f;
    public float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds

    private bool controlToggle;
    private float depth = 5f;

	// Use this for initialization
	void Start () {
        Debug.Assert(mEggStat != null);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMotion();
        BoundPosition();
        ProcessEggSpawn();
    }

    private void UpdateMotion() {
        if (Input.GetKeyDown(KeyCode.M)) {
            controlToggle = !controlToggle;
        }
        if (controlToggle) { 
            mHeroSpeed += Input.GetAxis("Vertical");
            transform.position += transform.up * (mHeroSpeed * Time.smoothDeltaTime);
            transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") *
                                        (kHeroRotateSpeed * Time.smoothDeltaTime));
        }
        else {
            Vector3 mousePos = Input.mousePosition;
            Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
            transform.position = wantedPos;
        }
    }

    private void BoundPosition() {
        GlobalBehavior.WorldBoundStatus status = GlobalBehavior.sTheGlobalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
        switch (status) {
            case GlobalBehavior.WorldBoundStatus.CollideBottom:
            case GlobalBehavior.WorldBoundStatus.CollideTop:
                transform.up = new Vector3(transform.up.x, -transform.up.y, 0.0f);
                break;
            case GlobalBehavior.WorldBoundStatus.CollideLeft:
            case GlobalBehavior.WorldBoundStatus.CollideRight:
                transform.up = new Vector3(-transform.up.x, transform.up.y, 0.0f);
                break;
        }
    }

    private void ProcessEggSpawn() {
        if (mEggStat.CanSpawn()) {
            if (Input.GetKey("space"))
                mEggStat.SpawnAnEgg(transform.position, transform.up);
        }
    }
}