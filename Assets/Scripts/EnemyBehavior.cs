using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 20f;

	///////Gabe Code//////////////////////////////////////////
	private bool targetRandomWaypoint = false;
	private char targetWayPoint;
	/////////////////////////////////////////////////
		
	// Use this for initialization
	void Start () {
		NewDirection();
		targetWayPoint = chooseRandomWaypoint();
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

	// New direction will be something completely random!
	private void NewDirection() {
		Vector2 v = Random.insideUnitCircle;
		transform.up = new Vector3(v.x, v.y, 0.0f);
	}

	//////Gabe Code//////////////////////////////////////////
	private char chooseRandomWaypoint() {
		int randomNumber = (int) Random.Range(65f, 70f);
		char waypointChar = (char) randomNumber;
		return waypointChar;
	}
	////////////////////////////////////////////////
}
