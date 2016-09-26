using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
    public float m_Health;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnTriggerEnter(Collider collider) {
        var player = collider.gameObject.GetComponent<Player>();
        if (player != null) {
            player.AddHealth(m_Health);
            Destroy(gameObject);
        }
    }
}
