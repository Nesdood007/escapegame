using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousPlayerController : MonoBehaviour {
  private GameObject tracking = null;
  private float nextCheck = 0.0f;
  public float pollTime = 10.0f; //Amount of time that elapses before the Seeker Looks for a player.
  public float rotateTime = 2.5f; //How much time it takes for the player to rotate toward the target
  //State that the Seeker is in
  private enum State {Idle, Moving, Seeking};
  private State state = State.Idle;
  //Movement Variables
  private float degToTurn = 0.0f;
  private float endRotationTime = 0.1f;
  //Seeking Variables
  public float speed = 3.0f;
  
  //Radius for Attacking
  public bool doAttack = false;
  public float radius = 20f;
  

  public GameObject projectile;
  
  private ColorMonitor color;
  
	// Use this for initialization
	void Start () {
    color = gameObject.GetComponent<ColorMonitor>();
  }
	
	// Update is called once per frame
	void Update () {
    
    if (Time.time - nextCheck >= 0.0f) {
      GameObject temp = findNearestTag("Player");
      if (temp != null && temp != tracking) {
        state = State.Moving;
        tracking = temp;
        degToTurn = findAngle(tracking.transform.position) - transform.rotation.y;
        endRotationTime = Time.time + rotateTime;
      }
      nextCheck = Time.time + pollTime;
      float dist = Vector3.Distance(transform.position, tracking.transform.position);
      if (dist <= radius) {
        GameObject go = Instantiate(projectile, transform.position, transform.rotation);
        go.tag = gameObject.tag;
      }
    }
    
    if (tracking != null) {
      
    }
    
    
    //Maybe do something for Idle State later?
    if (tracking == null) return;
    
    if (state == State.Moving) {
      if (endRotationTime - Time.time > 0) transform.Rotate(0, degToTurn * ((endRotationTime - Time.time)/endRotationTime) * Time.deltaTime, 0); //Timed Movement
      else transform.Rotate(0, findAngle(tracking.transform.position) - transform.rotation.y, 0); //After Time Expires
      if (endRotationTime - Time.time < 0) {
        state = State.Seeking;
      }
    }
		
    //Monitor both Direction and Rotation.
    if (state == State.Seeking) {
      transform.LookAt(tracking.transform);
      transform.Translate(0, 0, speed * Time.deltaTime);
    }
	}
  
  GameObject findNearestTag(string tag) {
    GameObject[] players = GameObject.FindGameObjectsWithTag(tag);
    //Debug.Log(players.Length);
    if (players.Length <= 0) return null;
    GameObject nearest = players[0];
    foreach (GameObject obj in players) {
      if (Vector3.Distance(obj.transform.position, transform.position) < Vector3.Distance(nearest.transform.position, transform.position)) {
        nearest = obj;
      }
    }
    return nearest;
  }
  
  //Returns the angle in degrees that the point is in the direction of relative to the player
  float findAngle(Vector3 point) {
    return Mathf.Rad2Deg * Mathf.Tan(point.z/point.x);
  }
  
  void OnCollisionEnter(Collision col) {
    //Check that this is the projectile
    if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<ProjectileBehaviour>() != null) {
      ColorMonitor cm = col.gameObject.GetComponent<ColorMonitor>();
      if (color.blue && !cm.blue) return;
      if (color.red && !cm.red) return;
      if (color.green && !cm.green) return;
      if (color.yellow && !cm.yellow) return;
      
      Destroy(gameObject);
    }
  }
}
