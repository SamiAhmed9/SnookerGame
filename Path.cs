using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

    public Transform transform;

    private bool initialized;
    private bool increase;
    private float speed;
    private float previousRotation;

    void Start()
    {
        speed = 0.5f;
        previousRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        if(previousRotation != transform.eulerAngles.y)
        {
            increase = true;
        }
        if(initialized)
        {
            transform.localScale += new Vector3(2.0f, 2.0f, 0.0f);
            initialized = false;
        }
        if(increase)
        {
            transform.localScale += new Vector3(0.0f, 0.0f, speed);
        }
    }

	void OnTriggerStay(Collider collider)
    {
        if(collider.tag.Equals("Red") || collider.tag.Equals("Yellow") || collider.tag.Equals("Green") || collider.tag.Equals("Brown")
            || collider.tag.Equals("Blue") || collider.tag.Equals("Pink") || collider.tag.Equals("Black"))
        {
            increase = false;
            if(!(transform.localScale.z <= 1.0f))
            {
                transform.localScale -= new Vector3(0.0f, 0.0f, speed * 2.0f);
            }
        } else if(collider.tag.Equals("Table"))
        {
            increase = false;
            if(!(transform.localScale.z <= 1.0f))
            {
                transform.localScale -= new Vector3(0.0f, 0.0f, speed * 2.0f);
            }
        }
    }

    void OnTriggerExit()
    {
        previousRotation = transform.eulerAngles.y;
    }

    public void SetPath()
    {
        initialized = true;
    }

    public void UnsetPath()
    {
        initialized = false;
        increase = false;
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
