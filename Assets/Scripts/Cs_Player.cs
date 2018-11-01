using UnityEngine;
using UnityEngine.SceneManagement;

public class Cs_Player : MonoBehaviour {

    public float moveSpeed = 7;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    public Rigidbody playerBody;

    Vector3 velocity;
    Vector3 starting;
    float angle;
    float smoothInputMag;
    float smoothMoveVel;

    Animator anim;
    Transform cameraTransform;

    Transform tankCockpit, tankCannon;

	void Start () {
        print("player start");
        //playerBody = gameObject.transform.GetChild(0).GetComponent<Rigidbody>();
        playerBody = GetComponent<Rigidbody>();
        starting = transform.position;

        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
	}
	
	void FixedUpdate () {
        Vector3 inputDir = Vector3.zero;
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float inputMag = inputDir.magnitude;
        smoothInputMag = Mathf.SmoothDamp(smoothInputMag, inputMag, ref smoothMoveVel, smoothMoveTime);

        if (inputDir == Vector3.zero) anim.SetBool("isMoving", false);
        else anim.SetBool("isMoving", true);

        float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMag);

        velocity = transform.forward * moveSpeed * smoothInputMag;
        if (transform.position.y < -2) transform.position = starting;
        
        playerBody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        playerBody.MovePosition(playerBody.position + velocity * Time.deltaTime);
    }
}
