using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class enemy : MonoBehaviour {
	public enum eSate{patrol, patrolAttack, dormant, pursue}
	public eSate curState;
	public float moveSpeed, range;
	public Transform destination, playerT, origin;
	public GameObject Player;
	private NavMeshAgent nMA;
	private bool calm = false;
	public Transform[] pts;
	private int last = -2;
	// Use this for initialization
	void Start () {
		GameObject o = new GameObject();
		o.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		origin = o.transform;
		nMA = GetComponent<NavMeshAgent> ();
		nMA.autoBraking = false;
		nMA.speed = moveSpeed;
		if (pts.Length > 0) {
			shuffle ();
			StartCoroutine (newP ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (curState == eSate.pursue) {
			setDest ();
		} else if (curState == eSate.patrol) {
			ptrlMove ();
			if (Vector3.Distance (this.transform.position, playerT.position) <= range) {
				curState = eSate.patrolAttack;
			}
		} else if (curState == eSate.patrolAttack) {
			setDest ();
			if (Vector3.Distance (this.transform.position, playerT.position) > range) {
				curState = eSate.patrol;
			}

		}
	}
	void setDest(){
		nMA.SetDestination (playerT.position);
	}
	void ptrlMove(){
		nMA.SetDestination (destination.position);
	}
	void stop(){
		nMA.SetDestination (this.transform.position);
	}
	void OnMouseDown(){
		nMA.SetDestination (this.transform.position);
	}
	void OnCollisionStay(Collision other){
		if (other.transform.tag == "Player") {
			SceneManager.LoadScene ("gameroom");
		}
	}
	public void wakeUp(){
		curState = eSate.pursue;
	}
	void shuffle(){
		int i= Random.Range (0, pts.Length);
		while (i == last)
			i = Random.Range (0, pts.Length);
		destination = pts[i];
		last = i;
	}
	IEnumerator newP(){
		yield return new WaitForSeconds (10f);
		shuffle ();
		StartCoroutine (newP ());
	}
}
