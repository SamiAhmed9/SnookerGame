using UnityEngine;
using System.Collections;

public class CueBallYRotation : MonoBehaviour {

    private bool rightPressed;
    private bool leftPressed;
    private bool wPressed;

    private double dampen;
    private string lastDirection;

    public Transform cameraTransform;

    private bool locked;

    void Start () {
        rightPressed = false;
        leftPressed = false;
        wPressed = false;

        dampen = 0.5;
        lastDirection = "";

        locked = false;
    }
	
	void Update () {
        if(!locked)
        {
            if (Input.GetKeyDown("right"))
            {
                //print("Right pressed");
                rightPressed = true;
            }
            if (Input.GetKeyUp("right"))
            {
                //print("Right released");
                rightPressed = false;
            }

            if (Input.GetKeyDown("left"))
            {
                //print("Left pressed");
                leftPressed = true;
            }
            if (Input.GetKeyUp("left"))
            {
                //print("Left released");
                leftPressed = false;
            }

            if (Input.GetKeyDown("w"))
            {
                //print("W pressed");
                wPressed = true;
            }
            if (Input.GetKeyUp("w"))
            {
                //print("W released");
                wPressed = false;
            }
        }

        if (rightPressed && !wPressed)
        {
            yAxisRotation("right");
        }
        else if (leftPressed && !wPressed)
        {
            yAxisRotation("left");
        }
        else
        {
            if(dampen != 0.5)
            {
                decreaseDampen();
                if (lastDirection.Equals("rotationRight"))
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * 25 * (((float)dampen) / 4), 0), Space.World);
                }
                else if (lastDirection.Equals("rotationLeft"))
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * -25 * (((float)dampen) / 4), 0), Space.World);
                }
            }//end of if
        }//end of else

    }//end of update

    private void yAxisRotation(string direction)
    {
        if (direction.Equals("right"))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * 25 * (((float)dampen) / 4), 0), Space.World);

            lastDirection = "rotationRight";
        }
        else if (direction.Equals("left"))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -25 * (((float)dampen) / 4), 0), Space.World);
            lastDirection = "rotationLeft";
        }

        if (dampen != 9)
        {
            IncreaseDampen();
        }
    }

    private bool inZone(string direction)
    {
        if (direction.Equals("right"))
        {
            cameraTransform.Translate(new Vector3((float)3.5 * Time.deltaTime, 0.0f, 0.0f));
            lastDirection = "";
        }
        else if (direction.Equals("left"))
        {
            cameraTransform.Translate(new Vector3((float)-3.5 * Time.deltaTime, 0.0f, 0.0f));
            lastDirection = "";
        }

        if (cameraTransform.localPosition.x < -2)
        {
            return false;
        }
        else if (cameraTransform.localPosition.x > 2)
        {
            return false;
        }
        else if (cameraTransform.localPosition.y > 3)
        {
            return false;
        }
        else if (cameraTransform.localPosition.y < (float)1.1)
        {
            return false;
        }
        else if (cameraTransform.localPosition.z > (float)-4.5)
        {
            return false;
        }
        else if (cameraTransform.localPosition.z < -6)
        {
            return false;
        }

        if (direction.Equals("right"))
        {
            cameraTransform.Translate(new Vector3((float)-3.5 * Time.deltaTime, 0.0f, 0.0f));
        }
        else if (direction.Equals("left"))
        {
            cameraTransform.Translate(new Vector3((float)3.5 * Time.deltaTime, 0.0f, 0.0f));
        }

        return true;
    }

    private void IncreaseDampen()
    {
        if (dampen < 1)
        {
            dampen += 0.05;
        }
        else if (dampen < 2)
        {
            dampen += 0.08;
        }
        else if (dampen < 3)
        {
            dampen += 0.11;
        } else if(dampen < 4)
        {
            dampen += 0.14;
        } else if(dampen < 5)
        {
            dampen += 0.17;
        } else if(dampen < 6)
        {
            dampen += 0.20;
        } else if(dampen < 7)
        {
            dampen += 0.23;
        } else if(dampen < 8)
        {
            dampen += 0.26;
        } else
        {
            dampen = 10;
        }

        //print(dampen);
    }

    private void decreaseDampen()
    {
        if(dampen > 5)
        {
            dampen -= 0.30;
        } else if(dampen > 2)
        {
            dampen -= 0.40;
        } else
        {
            dampen = 0.5;
        }

        //print(dampen);
    }

    public void Lock()
    {
        rightPressed = false;
        leftPressed = false;
        wPressed = false;

        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }
}
