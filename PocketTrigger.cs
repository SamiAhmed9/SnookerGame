using UnityEngine;
using System.Collections;

public class PocketTrigger : MonoBehaviour {

    public Referee referee;
    
	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.Equals("Red") || collider.tag.Equals("CueBall") || collider.tag.Equals("Yellow") || collider.tag.Equals("Green") || collider.tag.Equals("Brown")
             || collider.tag.Equals("Blue") || collider.tag.Equals("Pink") || collider.tag.Equals("Black"))
        {
            referee.Potted(collider.tag);
            Rigidbody rb = collider.attachedRigidbody;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            if (!collider.tag.Equals("Path"))
            {
                collider.enabled = false;
            }
        }
    }
}
