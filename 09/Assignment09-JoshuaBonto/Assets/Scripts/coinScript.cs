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
//		
		if(other.GetComponent<player>()){
			if (guardian) {
				guardian.wakeUp ();
			}

		}

	}
}
