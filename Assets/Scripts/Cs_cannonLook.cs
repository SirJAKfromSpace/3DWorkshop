using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_cannonLook : MonoBehaviour {

    Transform cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, cam.eulerAngles.y + 90, transform.eulerAngles.z);
	}
}
