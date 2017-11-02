using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utility : MonoBehaviour {
	public static bool checkBetween(float data, float min, float max){
		if (data > min && data < max)
			return true;
		return false;
	}
	public static int larger(int a, int b){
		if (a >= b) {
			return a;
		} else {
			return b;
		}
	}
	public static float larger(float a, float b){
		if (a >= b) {
			return a;
		} else {
			return b;
		}
	}
	public static int smaller(int a, int b){
		if (a <= b) {
			return a;
		} else {
			return b;
		}
	}
	public static float smaller(float a, float b){
		if (a <= b) {
			return a;
		} else {
			return b;
		}
	}
}
