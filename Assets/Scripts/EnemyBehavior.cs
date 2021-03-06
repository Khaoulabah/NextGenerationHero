using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 20f;
	public float kRotateSpeed = 0.01f;

	///////Gabe Code//////////////////////////////////////////
	private bool targetRandomWaypoint = true;
	private float waypointNum = 0;
	//public Enums.Directions useSide = Enums.Directions.Up;
	private GameObject currWaypoint;
	public bool randOrderbool;
	/////////////////////////////////////////////////
		
	// Use this for initialization
	void Start () {
		randOrderbool = true;
		NewDirection();
		chooseRandomWaypoint();
	}
	
	// Update is called once per frame
	void Update () {
		
		////Gabe Code////////////////////////////////////////
		if (Input.GetKeyDown(KeyCode.J)) {
			if (randOrderbool) {
				WayOrder.waypointOrder = "alph";
				randOrderbool = false;
			} else {
				WayOrder.waypointOrder = "rand";
				randOrderbool = true;
			}
			targetRandomWaypoint = !targetRandomWaypoint;
		}
		////////////////////////////////////////////////

		GlobalBehavior globalBehavior = GameObject.Find ("GameManager").GetComponent<GlobalBehavior>();
		
		GlobalBehavior.WorldBoundStatus status =
			globalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
			
		if (status != GlobalBehavior.WorldBoundStatus.Inside) {
			NewDirection();
		}	
	}

	////Gabe Code///////////////////////////////////
	void FixedUpdate () {
		PointAtPosition(currWaypoint.transform.localPosition, kRotateSpeed * Time.smoothDeltaTime);
        transform.localPosition += mSpeed * Time.smoothDeltaTime * transform.up;
		//////////////////////////////////////////////////////////////////////////////////////////////////

	}

	private void PointAtPosition(Vector3 p, float r)
    {
		Debug.Log("current position: " + transform.position);
        Vector3 v = p - transform.localPosition;
		Debug.Log("transform.up before: " + transform.up);
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
		Debug.Log("transform.up after: " + transform.up);
    }
	////////////////////////////////////////////////

	// New direction will be something completely random!
	private void NewDirection() {
		Vector2 v = Random.insideUnitCircle;
		transform.up = new Vector3(v.x, v.y, 0.0f);
	}

	//////Gabe Code//////////////////////////////////////////
	private void chooseRandomWaypoint() {
		int randomNumber = (int) Random.Range(1f, 6f);

		if (randomNumber == 1 && waypointNum != 1) {
			waypointNum = 1;
			currWaypoint = GameObject.FindGameObjectWithTag("WaypointA");
		} else if (randomNumber == 2 && waypointNum != 2) {
			waypointNum = 2;
			currWaypoint = GameObject.FindGameObjectWithTag("WaypointB");
		} else if (randomNumber == 3 && waypointNum != 3) {
			waypointNum = 3;
			currWaypoint = GameObject.FindGameObjectWithTag("WaypointC");
		} else if (randomNumber == 4 && waypointNum != 4) {
			waypointNum = 4;
			currWaypoint = GameObject.FindGameObjectWithTag("WaypointD");
		} else if (randomNumber == 5 && waypointNum != 5) {
			waypointNum = 5;
			currWaypoint = GameObject.FindGameObjectWithTag("WaypointE");
		} else if (randomNumber == 6 && waypointNum != 6) {
			waypointNum = 6;
			currWaypoint = GameObject.FindGameObjectWithTag("WaypointF");
		} else {
			chooseRandomWaypoint();
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collision) {
		GameObject collObject = collision.gameObject;
		//on collision with a waypoint
		if (collObject == currWaypoint) {
			if (targetRandomWaypoint) {
				chooseRandomWaypoint();
			} else {
				if (currWaypoint == GameObject.FindGameObjectWithTag("WaypointA")) {
					currWaypoint = GameObject.FindGameObjectWithTag("WaypointB");
				} else if (currWaypoint == GameObject.FindGameObjectWithTag("WaypointB")) {
					currWaypoint = GameObject.FindGameObjectWithTag("WaypointC");
				} else if (currWaypoint == GameObject.FindGameObjectWithTag("WaypointC")) {
					currWaypoint = GameObject.FindGameObjectWithTag("WaypointD");
				} else if (currWaypoint == GameObject.FindGameObjectWithTag("WaypointD")) {
					currWaypoint = GameObject.FindGameObjectWithTag("WaypointE");
				} else if (currWaypoint == GameObject.FindGameObjectWithTag("WaypointE")) {
					currWaypoint = GameObject.FindGameObjectWithTag("WaypointF");
				} else { // if(currWaypoint == GameObject.FindGameObjectWithTag("WaypointF")) {
					currWaypoint = GameObject.FindGameObjectWithTag("WaypointA");
				}
			}
		
		} else if (collision.GetComponent<Collider2D>().CompareTag("Player")) { // on collision with hero object
			Touched.touchedAmount++;
			collisionHelper();
		} else if (collision.GetComponent<Collider2D>().CompareTag("EggBullet")) { // on collision with egg object
			Destroyed.destroyedAmount++;
			collisionHelper();
		}
	}	

	private void collisionHelper() {
		float deltaX = Random.Range(-20, 20);
        float deltaY = Random.Range(-20, 20);
        transform.position = new Vector3(-1.5f * transform.position.x + deltaX, -1.5f * transform.position.y + deltaY);
        GlobalBehavior.sTheGlobalBehavior.ObjectClampToWorldBound(transform);
		chooseRandomWaypoint();
	}
	/////////////////////////////////////////////////////
}
