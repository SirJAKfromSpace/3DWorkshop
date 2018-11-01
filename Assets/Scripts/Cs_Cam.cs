using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Cam : MonoBehaviour {

    public bool lockCursor;
    public float mouseSensitivity = 10;
    public Transform target;
    public float distFromTarget = 2;
    
    public Vector2 pitchminmax = new Vector2(-15, 40);
    Vector3 rotSmoothVel, currRot;
    public float rotSmoothTime = .12f;
    
    float pitch, yaw;

    public Transform cannon;

    private void Start() {
        if (lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchminmax.x, pitchminmax.y);


        Vector3 targetRot = new Vector3(pitch, yaw);
        currRot = Vector3.SmoothDamp(currRot, targetRot, ref rotSmoothVel, rotSmoothTime);
        transform.eulerAngles = currRot; //targetRot;

        transform.position = Vector3.Lerp(transform.position, target.position - transform.forward * distFromTarget, rotSmoothTime);
        cannon.position = target.position;
        cannon.eulerAngles = new Vector3(cannon.eulerAngles.x, transform.eulerAngles.y + 90, cannon.eulerAngles.z);
    }
}
