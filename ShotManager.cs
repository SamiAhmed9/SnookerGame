using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour {

    public Path path;
    public PowerText powerText;
    public Rigidbody rb;
    public Transform transform;
    public GameObject cueStick;
    public Transform cueStickTransform;
    public GameObject cueStick2;
    public Transform cueStick2Transform;
    public CameraManager cameraManager;
    public Camera shotCamera;
    public Retake retake;

    private float thrust;
    private bool hitCueBall;
    private bool cueStickForward;
    private float time;
    private bool AllowTime;
    private float allowTime;

    void Start()
    {
        path.UnsetPath();
        thrust = 1;
        hitCueBall = false;
        cueStick.SetActive(false);
        cueStickForward = false;
        time = 1.5f;
        AllowTime = false;
        allowTime = 1.5f;
    }

    void Update()
    {
        if (cueStickForward)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                if (thrust == 1)
                {
                    CueStickForward(0.3f);
                } else if(thrust == 2)
                {
                    CueStickForward(0.6f);
                }
                else if (thrust == 3)
                {
                    CueStickForward(1.1f);
                }
                else if (thrust == 4)
                {
                    CueStickForward(1.6f);
                }
                else if (thrust == 5)
                {
                    CueStickForward(2.1f);
                }
                else if (thrust == 6)
                {
                    CueStickForward(2.6f);
                }
                else if (thrust == 7)
                {
                    CueStickForward(3.2f);
                }
                else if (thrust == 8)
                {
                    CueStickForward(3.8f);
                }
                else if (thrust == 9)
                {
                    CueStickForward(4.4f);
                }
                else if (thrust == 10)
                {
                    CueStickForward(5.0f);
                }
            }
        }
        
    }//end of update

    private void CueStickForward(float speed)
    {
        if (cueStickTransform.localPosition.z <= -25.5f)
        {
            cueStickTransform.localPosition += new Vector3(0.0f, 0.0f, speed);
        }
        else
        {
            cueStick2Transform.position = cueStickTransform.position;
            cueStick2Transform.rotation = cueStickTransform.rotation;
            if(shotCamera.enabled)
            {
                cueStick2.SetActive(true);
            }
            hitCueBall = true;
            cueStickForward = false;
            if (thrust == 1)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -25.5f);
            } else if(thrust == 2)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -26.5f);
            }
            else if (thrust == 3)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -27.5f);
            }
            else if (thrust == 4)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -28.5f);
            }
            else if (thrust == 5)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -29.5f);
            }
            else if (thrust == 6)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -30.5f);
            }
            else if (thrust == 7)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -31.5f);
            }
            else if (thrust == 8)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -32.5f);
            }
            else if (thrust == 9)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -33.5f);
            }
            else if (thrust == 10)
            {
                cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -34.5f);
            }
            cueStick.SetActive(false);
            time = 1.5f;
        }
    }

    void FixedUpdate()
    {
        if (hitCueBall)
        {
            float finalPower = 1.0f;
            if (thrust == 1)
            {
                finalPower = 3;
            } else if(thrust == 2)
            {
                finalPower = 6;
            }
            else if (thrust == 3)
            {
                finalPower = 12;
            }
            else if (thrust == 4)
            {
                finalPower = 17;
            }
            else if (thrust == 5)
            {
                finalPower = 23;
            }
            else if (thrust == 6)
            {
                finalPower = 28;
            }
            else if (thrust == 7)
            {
                finalPower = 33;
            }
            else if (thrust == 8)
            {
                finalPower = 38;
            }
            else if (thrust == 9)
            {
                finalPower = 43;
            }
            else if (thrust == 10)
            {
                finalPower = 50;
            }
            if(shotCamera.enabled)
            {
                retake.SetTransforms();
                rb.AddForce(transform.forward * finalPower, ForceMode.Impulse);
            }
            hitCueBall = false;
            AllowTime = true; 
        }

        if(AllowTime)
        {
            if (allowTime > 0)
            {
                allowTime -= Time.deltaTime;
            }
            else
            {
                cameraManager.AllowPositionChecks();
                allowTime = 1.5f;
                AllowTime = false;
            }
        }
    }
    
	public void ShotMode()
    {
        path.SetPath();
        cueStick.SetActive(true);
    }

    public void EscapeShotMode()
    {
        path.UnsetPath();
        cueStick.SetActive(false);
    }

    public void SetValue(float value)
    {
        if(value == 10)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -34.5f);
        } else if(value == 9)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -33.5f);
        } else if(value == 8)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -32.5f);
        } else if(value == 7)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -31.5f);
        } else if(value == 6)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -30.5f);
        } else if(value == 5)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -29.5f);
        } else if(value == 4)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -28.5f);
        } else if(value == 3)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -27.5f);
        } else if(value == 2)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -26.5f);
        } else if(value == 1)
        {
            cueStickTransform.localPosition = new Vector3(0.0f, 1.6f, -25.5f);
        }
        thrust = value;
        powerText.SetValue((int)thrust);
    }

    public void SetShot()
    {
        cameraManager.UnlockShotCamera();
        cueStickForward = true;
        path.UnsetPath();
    }

    public void Lock()
    {
        cueStick2.SetActive(false);
    }

}
