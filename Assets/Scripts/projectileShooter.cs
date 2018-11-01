using UnityEngine;
using UnityEngine.SceneManagement;

public class projectileShooter : MonoBehaviour {

	public Rigidbody rocketProjectile;
    public Transform spout;

    bool isShooting = false;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1")) ShootProj();

        if (Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene("MainMenu");
        
	}

    public void ShootProj() {
        if (!isShooting) {
            isShooting = true;
            Rigidbody rock = Instantiate(rocketProjectile,spout.position,Quaternion.identity,null);
            rock.velocity = Camera.main.transform.TransformDirection(new Vector3(0,0.2f,1)* 30);
            Invoke("NotShooting", 1f);
        }
    }

    void NotShooting() {
        isShooting = false;
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
