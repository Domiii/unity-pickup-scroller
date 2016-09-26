using UnityEngine;
using System.Collections;

public class AlignDirection : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		var player = other.GetComponent<Player> ();
		if (player != null) {
			var cosAngle = Mathf.Abs(Vector3.Dot (player.transform.forward, transform.forward));

			if (cosAngle < 0.1f) {
				player.transform.forward = transform.forward;
			}
		}
	}
}
