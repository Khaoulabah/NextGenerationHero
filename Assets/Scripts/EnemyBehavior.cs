using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 20f;
	public float kRotateSpeed = 120f/2f;

	///////Gabe Code//////////////////////////////////////////
	private bool targetRandomWaypoint = false;
	//public Enums.Directions useSide = Enums.Directions.Up;
	private GameObject currWayPoint;
	//private GameObject greenArrow = GameObject.FindGameObjectWithTag("WaypointA");
	/////////////////////////////////////////////////
		
	// Use this for initialization
	void Start () {
		NewDirection();
		chooseRandomWaypoint();
	}
	
	// Update is called once per frame
	void Update () {
		
		////Gabe Code////////////////////////////////////////
		if (Input.GetKey(KeyCode.J)) {
			targetRandomWaypoint = !targetRandomWaypoint;
		}
		////////////////////////////////////////////////

		transform.position += (mSpeed * Time.smoothDeltaTime) * transform.up;
		GlobalBehavior globalBehavior = GameObject.Find ("GameManager").GetComponent<GlobalBehavior>();
		
		GlobalBehavior.WorldBoundStatus status =
			globalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
			
		if (status != GlobalBehavior.WorldBoundStatus.Inside) {
			Debug.Log("collided position: " + this.transform.position);
			NewDirection();
		}	
	}

	////Gabe Code///////////////////////////////////
	 
	void FixedUpdate () {
		//Utils.SetAxisTowards(useSide, transform, targetWayPoint.position - transform.position);
		///Gabe Code//////////////////////////////////////////////////////////////////////////////////////
		PointAtPosition(currWayPoint.transform.localPosition, kRotateSpeed * Time.smoothDeltaTime);
        transform.localPosition += mSpeed * Time.smoothDeltaTime * transform.up;
		//////////////////////////////////////////////////////////////////////////////////////////////////

	}

	private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
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
		if (randomNumber == 1) {
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointA");
		} else if (randomNumber == 2) {
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointB");
		} else if (randomNumber == 3) {
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointC");
		} else if (randomNumber == 4) {
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointD");
		} else if (randomNumber == 5) {
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointE");
		} else { //if (randomNumber == 6)
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointF");
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collision) {
		//on collision with a waypoint
		if (collision.GetComponent<Collider2D>() == currWayPoint.GetComponent<Collider2D>()) {
			if (targetRandomWaypoint) {
				chooseRandomWaypoint();
			} else {
				if (currWayPoint == GameObject.FindGameObjectWithTag("WaypointA")) {
					currWayPoint = GameObject.FindGameObjectWithTag("WaypointB");
				} else if (currWayPoint == GameObject.FindGameObjectWithTag("WaypointB")) {
					currWayPoint = GameObject.FindGameObjectWithTag("WaypointC");
				} else if (currWayPoint == GameObject.FindGameObjectWithTag("WaypointC")) {
					currWayPoint = GameObject.FindGameObjectWithTag("WaypointD");
				} else if (currWayPoint == GameObject.FindGameObjectWithTag("WaypointD")) {
					currWayPoint = GameObject.FindGameObjectWithTag("WaypointE");
				} else if (currWayPoint == GameObject.FindGameObjectWithTag("WaypointE")) {
					currWayPoint = GameObject.FindGameObjectWithTag("WaypointF");
				} else { // if(currWayPoint == GameObject.FindGameObjectWithTag("WaypointF")) {
					currWayPoint = GameObject.FindGameObjectWithTag("WaypointA");
				}
			}
		
		} else if (collision.GetComponent<Collider2D>().CompareTag("Player")) { // on collision with hero object
			//increment "touched enemy" counter
			//teleport this object to a random location
		} else if (collision.GetComponent<Collider2D>().CompareTag("EggBullet")) { // on collision with egg object
			//increment "destroyed enemy" counter
			//teleport this object to a random location
		}
	}	
	/////////////////////////////////////////////////////
}
