using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 20f;

	///////Gabe Code//////////////////////////////////////////
	private bool targetRandomWaypoint = false;
	//private char targetWayPoint;
	//public Enums.Directions useSide = Enums.Directions.Up;
	private Object currWayPoint;
	
	/////////////////////////////////////////////////
		
	// Use this for initialization
	void Start () {
		NewDirection();
		/*targetWayPoint = */chooseRandomWaypoint();
	}
	
	// Update is called once per frame
	void Update () {
		
		////Gabe Code////////////////////////////////////////
		if (Input.GetKey(KeyCode.J)) {
			targetRandomWaypoint = !targetRandomWaypoint;
		}

		/*if (targetRandomWaypoint) {
			targetWayPoint = chooseRandomWaypoint();
		} else {
			
		}*/

		/*if () {

		}*/
		/////////////////////////////////////////////

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


	}
	////////////////////////////////////////////////

	// New direction will be something completely random!
	private void NewDirection() {
		Vector2 v = Random.insideUnitCircle;
		transform.up = new Vector3(v.x, v.y, 0.0f);
	}

	//////Gabe Code//////////////////////////////////////////
	private /*char*/ void chooseRandomWaypoint() {
		int randomNumber = (int) Random.Range(1f, 6f);
		if (randomNumber == 1) {
			currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointA"));
		} else if (randomNumber == 2) {
			currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointB"));
		} else if (randomNumber == 3) {
			currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointC"));
		} else if (randomNumber == 4) {
			currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointD"));
		} else if (randomNumber == 5) {
			currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointE"));
		} else { //if (randomNumber == 6)
			currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointF"));
		}
		//char waypointChar = (char) randomNumber;
		//return waypointChar;
	}
	
	private void OnTriggerEnter2D(Collider2D collision) {
		if (targetRandomWaypoint) {
			chooseRandomWaypoint();
		} else {
			if (currWayPoint == Instantiate(Resources.Load("Prefabs/WaypointA"))) {
				currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointB"));
			} else if (currWayPoint == Instantiate(Resources.Load("Prefabs/WaypointB"))) {
				currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointC"));
			} else if (currWayPoint == Instantiate(Resources.Load("Prefabs/WaypointC"))) {
				currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointD"));
			} else if (currWayPoint == Instantiate(Resources.Load("Prefabs/WaypointD"))) {
				currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointE"));
			} else if (currWayPoint == Instantiate(Resources.Load("Prefabs/WaypointE"))) {
				currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointF"));
			} else { // if(currWayPoint == Instantiate(Resources.Load("Prefabs/WaypointF"))) {
				currWayPoint = Instantiate(Resources.Load("Prefabs/WaypointA"));
			}
		}
	}
}
/////////////////////////////////////////////////////

//on collision with a waypoint




/*
on collision with player

increment "touched enemy" counter
teleport this object to a random location

*/

/*
on collision with bullet

increment "destroyed enemy" counter
teleport this object to a random location

*/