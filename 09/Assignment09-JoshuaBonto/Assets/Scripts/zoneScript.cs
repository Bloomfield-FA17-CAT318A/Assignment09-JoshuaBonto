using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class zoneScript : MonoBehaviour {
	public player playerS;
	public float coins;
	// Use this for initialization

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Player") {
			SceneManager.LoadScene ("gameroom");
		}
	}

}
