using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public GameObject cueBall;
    public GameObject yellowBall;
    public GameObject greenBall;
    public GameObject brownBall;
    public GameObject blueBall;
    public GameObject pinkBall;
    public GameObject blackBall;
    public GameObject redBall1;
    public GameObject redBall2;
    public GameObject redBall3;
    public GameObject redBall4;
    public GameObject redBall5;
    public GameObject redBall6;
    public GameObject redBall7;
    public GameObject redBall8;
    public GameObject redBall9;
    public GameObject redBall10;
    public GameObject redBall11;
    public GameObject redBall12;
    public GameObject redBall13;
    public GameObject redBall14;
    public GameObject redBall15;

    public Transform cueBallT;
    public Transform yellowBallT;
    public Transform greenBallT;
    public Transform brownBallT;
    public Transform blueBallT;
    public Transform pinkBallT;
    public Transform blackBallT;
    public Transform redBall1T;
    public Transform redBall2T;
    public Transform redBall3T;
    public Transform redBall4T;
    public Transform redBall5T;
    public Transform redBall6T;
    public Transform redBall7T;
    public Transform redBall8T;
    public Transform redBall9T;
    public Transform redBall10T;
    public Transform redBall11T;
    public Transform redBall12T;
    public Transform redBall13T;
    public Transform redBall14T;
    public Transform redBall15T;

    public Rigidbody cueBallRB;
    public Rigidbody yellowBallRB;
    public Rigidbody greenBallRB;
    public Rigidbody brownBallRB;
    public Rigidbody blueBallRB;
    public Rigidbody pinkBallRB;
    public Rigidbody blackBallRB;
    public Rigidbody redBall1RB;
    public Rigidbody redBall2RB;
    public Rigidbody redBall3RB;
    public Rigidbody redBall4RB;
    public Rigidbody redBall5RB;
    public Rigidbody redBall6RB;
    public Rigidbody redBall7RB;
    public Rigidbody redBall8RB;
    public Rigidbody redBall9RB;
    public Rigidbody redBall10RB;
    public Rigidbody redBall11RB;
    public Rigidbody redBall12RB;
    public Rigidbody redBall13RB;
    public Rigidbody redBall14RB;
    public Rigidbody redBall15RB;


    public GameObject menuCanvas;
    public CameraManager cameraManager;
    public ShotManager shotManager;
    public Transform camera;

    private GameObject[] balls;
    
    void Start () {
        menuCanvas.SetActive(true);

        balls = new GameObject[22];
        balls[0] = cueBall;
        balls[1] = yellowBall;
        balls[2] = greenBall;
        balls[3] = brownBall;
        balls[4] = blueBall;
        balls[5] = pinkBall;
        balls[6] = blackBall;
        balls[7] = redBall1;
        balls[8] = redBall2;
        balls[9] = redBall3;
        balls[10] = redBall4;
        balls[11] = redBall5;
        balls[12] = redBall6;
        balls[13] = redBall7;
        balls[14] = redBall8;
        balls[15] = redBall9;
        balls[16] = redBall10;
        balls[17] = redBall11;
        balls[18] = redBall12;
        balls[19] = redBall13;
        balls[20] = redBall14;
        balls[21] = redBall15;
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].SetActive(false);
        }
	}
	
	void Update () {
	    if(Input.GetKeyDown("m"))
        {
            if(menuCanvas.activeSelf)
            {
                menuCanvas.SetActive(false);
            } else
            {
                menuCanvas.SetActive(true);
            }
        }
	}

    public void InitializeBalls()
    {
        cueBallT.position = new Vector3(12.5f, 0.25f, 1.5f);
        cueBallT.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
        yellowBallT.position = new Vector3(11.0f, 0.25f, 3.0f);
        greenBallT.position = new Vector3(11.0f, 0.25f, -3.0f);
        brownBallT.position = new Vector3(11.0f, 0.25f, 0.0f);
        blueBallT.position = new Vector3(0.0f, 0.25f, 0.0f);
        pinkBallT.position = new Vector3(-9.0f, 0.25f, 0.0f);
        blackBallT.position = new Vector3(-15.0f, 0.25f, 0.0f);
        cueBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        yellowBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        greenBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        brownBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        blueBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        pinkBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        blackBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);

        redBall1T.position = new Vector3(-10f, 0.25f, 0.0f);
        redBall2T.position = new Vector3(-10.5f, 0.25f, 0.25f);
        redBall3T.position = new Vector3(-10.5f, 0.25f, -0.25f);
        redBall4T.position = new Vector3(-11.0f, 0.25f, 0.0f);
        redBall5T.position = new Vector3(-11.0f, 0.25f, 0.5f);
        redBall6T.position = new Vector3(-11.0f, 0.25f, -0.5f);
        redBall7T.position = new Vector3(-11.5f, 0.25f, 0.25f);
        redBall8T.position = new Vector3(-11.5f, 0.25f, -0.25f);
        redBall9T.position = new Vector3(-11.5f, 0.25f, -0.75f);
        redBall10T.position = new Vector3(-11.5f, 0.25f, 0.75f);
        redBall11T.position = new Vector3(-12.0f, 0.25f, 0.0f);
        redBall12T.position = new Vector3(-12.0f, 0.25f, 0.5f);
        redBall13T.position = new Vector3(-12.0f, 0.25f, 1.0f);
        redBall14T.position = new Vector3(-12.0f, 0.25f, -0.5f);
        redBall15T.position = new Vector3(-12.0f, 0.25f, -1.0f);
        redBall1RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall2RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall3RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall4RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall5RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall6RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall7RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall8RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall9RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall10RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall11RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall12RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall13RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall14RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        redBall15RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].SetActive(true);
        }

        menuCanvas.SetActive(false);
        cameraManager.OverrideUnlockCamera();
        shotManager.EscapeShotMode();
        camera.position = new Vector3(17.0f, 5.0f, 0.0f);
        camera.eulerAngles = new Vector3(30.0f, -90.0f, 0.0f);
    }
}
