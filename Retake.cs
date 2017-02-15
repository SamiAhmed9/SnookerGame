using UnityEngine;
using System.Collections;

public class Retake : MonoBehaviour {

    public GameObject rrCanvas;

    public Transform cueBall;
    public Transform yellowBall;

    public Rigidbody cueBallRB;
    public Rigidbody yellowBallRB;

    private Vector3 cueBallV;
    private Vector3 yellowBallV;

	void Start () {
        rrCanvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            if(rrCanvas.activeSelf)
            {
                rrCanvas.SetActive(false);
            } else
            {
                rrCanvas.SetActive(true);
            }
        }
    }

    public void SetTransforms()
    {
        cueBallV = cueBall.position;
        yellowBallV = yellowBall.position;
    }
	
	public void RetakeShot()
    {
        cueBall.position = cueBallV;
        yellowBall.position = yellowBallV;

        cueBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        yellowBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
