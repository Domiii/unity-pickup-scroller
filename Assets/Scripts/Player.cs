using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float m_ForwardSpeed = 5;
    public float m_HorizontalSpeed = 2;
    public float m_Health = 3;
    public float m_SpeedIncrease = 0.5f;

    /// <summary>
    /// Max distance from center of ground
    /// </summary>
    private float m_MaxSideMovement = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // keep increasing forward speed
        m_ForwardSpeed += m_SpeedIncrease * Time.deltaTime;

        // if we have a parent, move that instead
        var trans = transform.parent;
        if (trans == null) {
            trans = transform;
        }
        var pos = trans.position;

        // compute forward and sideward movement
        var dz = m_ForwardSpeed * Time.deltaTime;
        var dx = m_ForwardSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

        // make sure, we won't go too left or right
        var minX = -m_MaxSideMovement + transform.localScale.x / 2;
        var maxX = m_MaxSideMovement - transform.localScale.x / 2;
        dx = Mathf.Clamp(pos.x + dx, minX, maxX) - pos.x;

        trans.Translate(dx, 0, dz);
    }

    public void AddHealth(float health) {
        m_Health += health;
        if (m_Health <= 0) {
            SceneManager.LoadScene(0);
        }
    }
}
