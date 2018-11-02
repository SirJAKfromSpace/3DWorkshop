using UnityEngine;
using UnityEngine.SceneManagement;

public class Cs_Player : MonoBehaviour {

    public float moveSpeed = 7;
    Vector3 velocity;
    public Rigidbody playerBody;
    Vector3 starting;
    
    public float turnSpeed = 8;
    float angle;

    Animator anim;
    Transform cameraTransform;

    Transform tankCockpit, tankCannon;

	void Start () {
        print("player start");
        //playerBody = gameObject.transform.GetChild(0).GetComponent<Rigidbody>();
        playerBody = GetComponent<Rigidbody>();
        starting = transform.position;

        //animation
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
	}
	
	void FixedUpdate () {
        //move
        //Vector3 inputDir = Vector3.zero;
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float inputMag = inputDir.magnitude;

        //animation
        if (inputDir == Vector3.zero) anim.SetBool("isMoving", false);
        else anim.SetBool("isMoving", true);

        //rotation
        float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMag);

        //move
        velocity = transform.forward * moveSpeed * inputMag;
        if (transform.position.y < -2) transform.position = starting;

        //rotation
        playerBody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        //move
        playerBody.MovePosition(playerBody.position + velocity * Time.deltaTime);
    }
}
