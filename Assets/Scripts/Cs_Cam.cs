using UnityEngine;

public class Cs_Cam : MonoBehaviour {

    //cam move
    float pitch, yaw;
    public float mouseSensitivity = 10;
    public float distFromTarget = 2;
    public Vector2 pitchminmax = new Vector2(-15, 40);
    public Transform target;

    public bool lockCursor;

    //smooth
    Vector3 rotSmoothVel, currRot;
    public float rotSmoothTime = .12f;
    
    //cannon look
    public Transform cannon;

    private void Start() {
        if (lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //raw cam move
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchminmax.x, pitchminmax.y);
        Vector3 targetRot = new Vector3(pitch, yaw);

        //smooth
        currRot = Vector3.SmoothDamp(currRot, targetRot, ref rotSmoothVel, rotSmoothTime);
        transform.position = Vector3.Lerp(transform.position, target.position - transform.forward * distFromTarget, rotSmoothTime);

        //apply to cam
        transform.eulerAngles = currRot; //targetRot;

        //cannon look
        cannon.position = target.position;
        cannon.eulerAngles = new Vector3(cannon.eulerAngles.x, transform.eulerAngles.y + 90, cannon.eulerAngles.z);
    }
}
