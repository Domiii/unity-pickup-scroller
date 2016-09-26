using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float forwardSpeed = 5;
    public float horizontalSpeed = 2;
    public float health = 3;
    public float acceleration = 0.5f;	// acceleration
	public GameObject followPlayer;
	Vector3 followPlayerDistance;

	void Start() {
		if (followPlayer != null) {
			followPlayerDistance = followPlayer.transform.position - transform.position;
		}
	}

	void FixedUpdate () {
        // keep increasing forward speed
		forwardSpeed += acceleration * Time.fixedDeltaTime;

		// compute forward and sideward movement
		var pos = transform.position;
		var dx = horizontalSpeed * Input.GetAxis("Horizontal");
        var dz = forwardSpeed;

		var body = GetComponent<Rigidbody> ();
		var v = body.velocity;

		v.x = dx;
		v.z = dz;

		// rotate velocity to facing direction
		v = transform.localRotation * v;

		body.velocity = v;

		// player dies when falling too low
		if (pos.y < -10) {
			Die ();
		}

		// let object automatically follow player
		if (followPlayer != null) {
			followPlayer.transform.position = transform.position + followPlayerDistance;
			followPlayer.transform.localRotation = transform.localRotation;
		}
    }

    public void AddHealth(float health) {
        health += health;
        if (health <= 0) {
			Die ();
        }
    }

	void Die() {
		SceneManager.LoadScene(0);
	}
}
