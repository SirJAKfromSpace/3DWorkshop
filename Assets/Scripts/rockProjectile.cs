using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockProjectile : MonoBehaviour {


	private float curSpeed = 0; 
	public float lifetime = 1;
	
	// Update is called once per frame
	void Update () {
	
		if(lifetime > 0)lifetime -= Time.deltaTime;
		else Destroy(this.gameObject);
    }

	float getSpeed(){
		return curSpeed;
	}

	void setSpeed(float speed){
		curSpeed = speed;
	}
}
