using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {
	private bool follow = false;
	public GameObject player;
	public float offset;
	public enemy guardian;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			this.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + offset,
				player.transform.position.z);
		}
	}
	void OnColliderEnter(Collision other){

	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("enter");
		if (other.transform.tag == "zone") {
			Debug.Log ("zone");
			other.GetComponent<zoneScript> ().coin (this.gameObject);
		}
		if(other.GetComponent<player>().getcarry()==false){
			if (guardian) {
				guardian.wakeUp ();
			}
			other.GetComponent<player> ().setCarry (true);
			Destroy (this.gameObject);
		}

	}
}
