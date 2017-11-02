using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	[Header("Stats")]
	public float ms;
	public int health;
	public int count;
	public int max;
	[Header("Other")]
	public int flashAmount;
	public float flashTime;

	public bool canHurt = true;
	public bool carrying = false;
	private Rigidbody RB;
	private MeshRenderer MR;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		MR = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");
		move (hAxis, vAxis);
	}
	IEnumerator flash(){
		for (int i = 0; i < flashAmount; i++) {
			MR.enabled = false;
			yield return new WaitForSeconds (flashTime);
			MR.enabled = true;
			yield return new WaitForSeconds (flashTime);
		}
		canHurt = true;
	}
	void OnMouseDown(){
		StartCoroutine (flash ());
	}
	public void takeDamage(){
		if (canHurt) {
			StartCoroutine (flash ());
			canHurt = false;
		}
	}
	void move(float a, float b){
		RB.velocity = new Vector3 (a*-ms, RB.velocity.y, b*-ms);
	}
	public bool getcarry(){
		return carrying;
	}
	public void setCarry(bool a){
		count++;
		if (count == max) {

		}
	}
}
