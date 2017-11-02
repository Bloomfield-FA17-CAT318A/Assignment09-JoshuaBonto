using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class zoneScript : MonoBehaviour {
	public player playerS;
	public float coins;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "coin") {
			Destroy (other.gameObject);
			playerS.setCarry (false);
			coins--;
		}
	}
	public void coin(GameObject a){
		Destroy (a.gameObject);
		playerS.setCarry (false);
		coins--;
	}
}
