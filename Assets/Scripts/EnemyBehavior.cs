using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 20f;
	public float kRotateSpeed = 120f/2f;

	///////Gabe Code//////////////////////////////////////////
	private bool targetRandomWaypoint = true;
	private float waypointNum = 0;
	//public Enums.Directions useSide = Enums.Directions.Up;
	private GameObject currWayPoint;
	//private GameObject greenArrow = GameObject.FindGameObjectWithTag("WaypointA");
	/////////////////////////////////////////////////
		
	// Use this for initialization
	void Start () {
		Debug.Log(targetRandomWaypoint.ToString());
		NewDirection();
		chooseRandomWaypoint();
	}
	
	// Update is called once per frame
	void Update () {
		
		////Gabe Code////////////////////////////////////////
		if (Input.GetKeyDown(KeyCode.J)) {
			targetRandomWaypoint = !targetRandomWaypoint;
			Debug.Log("J was pressed");
			Debug.Log(targetRandomWaypoint.ToString());
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
		int randomNumber = 1;//(int) Random.Range(1f, 6f);
		Debug.Log(randomNumber);
		if (randomNumber == 1 && waypointNum != 1) {
			waypointNum = 1;
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointA");
		} else if (randomNumber == 2 && waypointNum != 2) {
			waypointNum = 2;
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointB");
		} else if (randomNumber == 3 && waypointNum != 3) {
			waypointNum = 3;
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointC");
		} else if (randomNumber == 4 && waypointNum != 4) {
			waypointNum = 4;
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointD");
		} else if (randomNumber == 5 && waypointNum != 5) {
			waypointNum = 5;
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointE");
		} else if (randomNumber == 6 && waypointNum != 6) {
			waypointNum = 6;
			currWayPoint = GameObject.FindGameObjectWithTag("WaypointF");
		} else {
			chooseRandomWaypoint();
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log("Collided with something!");
		//on collision with a waypoint
		if (collision == currWayPoint) {
			Debug.Log("Collided with correct waypoint");
			if (targetRandomWaypoint) {
				Debug.Log("Choosing next random Waypoint");
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
