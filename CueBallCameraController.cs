using UnityEngine;
using System.Collections;

public class CueBallCameraController : MonoBehaviour {

    public Transform transform;
    public GameObject canvas;

    private bool upPressed;
    private bool downPressed;
    private bool wPressed;

    private bool yAxisTranslationUp;
    private bool yAxisTranslationDown;
    private bool cameraTranslated;

    private double dampen;
    private string lastDirection;

    private bool locked;

    void Start () {
        upPressed = false;
        downPressed = false;
        wPressed = false;

        yAxisTranslationUp = false;
        yAxisTranslationDown = false;
        cameraTranslated = false;

        dampen = 0.5;
        lastDirection = "";

        locked = false;
    }
	
	void Update () {
        yAxisTranslationUp = false;
        yAxisTranslationDown = false;
        cameraTranslated = false;

        if(!locked)
        {
            if (Input.GetKeyDown("up"))
            {
                //print("Up pressed");
                upPressed = true;
            }
            if (Input.GetKeyUp("up"))
            {
                //print("Up released");
                upPressed = false;
            }

            if (Input.GetKeyDown("down"))
            {
                //print("Down pressed");
                downPressed = true;
            }
            if (Input.GetKeyUp("down"))
            {
                //print("Down released");
                downPressed = false;
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

        if(wPressed && upPressed)
        {
            xAxisRotation("up");
        } else if(wPressed && downPressed)
        {
            xAxisRotation("down");
        } else if (upPressed)
        {
            yAxisTranslation("up");
        } else if(downPressed)
        {
            yAxisTranslation("down");
        } else
        {
            if(dampen != 0.5)
            {
                decreaseDampen();
                if (lastDirection.Equals("verticalUp"))
                {
                    if(inZone("verticalUp"))
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * Time.deltaTime, 0.0f), Space.World);
                        lastDirection = "verticalUp";
                    } else
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * -1 * Time.deltaTime, 0.0f), Space.World);
                    }
                } else if(lastDirection.Equals("verticalDown"))
                {
                    if (inZone("verticalDown"))
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * -1 * Time.deltaTime, 0.0f), Space.World);
                        lastDirection = "verticalDown";
                    }
                    else
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * Time.deltaTime, 0.0f), Space.World);
                    }
                } else if(lastDirection.Equals("rotationUp"))
                {
                    float x = transform.eulerAngles.x;
                    transform.Rotate(new Vector3(Time.deltaTime * -25 * ((float)(dampen / 4)), 0, 0));
                    if (x <= 355 && x >= 300)
                    {
                        transform.Rotate(new Vector3(Time.deltaTime * 25 * ((float)(dampen / 4)), 0, 0));
                    }
                } else if(lastDirection.Equals("rotationDown"))
                {
                    float x = transform.eulerAngles.x;
                    transform.Rotate(new Vector3(Time.deltaTime * 25 * ((float)(dampen / 4)), 0, 0));
                    if (x > 15 && x < 45)
                    {
                        transform.Rotate(new Vector3(Time.deltaTime * -25 * ((float)(dampen / 4)), 0, 0));
                    }
                }
            }//end of if
        }//end of else

        if(yAxisTranslationUp)
        {
            transform.Translate(new Vector3(0.0f, (float)dampen * Time.deltaTime, 0.0f), Space.World);
            cameraTranslated = true;
        } else if(yAxisTranslationDown)
        {
            transform.Translate(new Vector3(0.0f, (float)dampen * -1 * Time.deltaTime, 0.0f), Space.World);
            cameraTranslated = true;
        }
        if (dampen != 3 && cameraTranslated)
        {
            IncreaseDampen();
        }

    }//end of Update

    private void xAxisRotation(string direction)
    {
        bool enableUp = true;
        bool enableDown = true;
        float x = transform.eulerAngles.x;
        if (x <= 355 && x >= 300)
        {
            lastDirection = "rotationUp";
            enableUp = false;
        }
        else if (x > 15 && x < 45)
        {
            lastDirection = "rotationDown";
            enableDown = false;
        }

        if (direction.Equals("up") && enableUp)
        {
            transform.Rotate(new Vector3(Time.deltaTime * -25 * ((float)(dampen / 4)), 0, 0));
            lastDirection = "rotationUp";
        }
        else if (direction.Equals("down") && enableDown)
        {
            transform.Rotate(new Vector3(Time.deltaTime * 25 * ((float)(dampen / 4)), 0, 0));
            lastDirection = "rotationDown";
        }

        if (dampen != 3)
        {
            IncreaseDampen();
        }
    }

    private void yAxisTranslation(string direction)
    {
        if (direction.Equals("up"))
        {
            if (inZone("verticalUp"))
            {
                yAxisTranslationUp = true;
                lastDirection = "verticalUp";
            }
            else
            {
                transform.Translate(new Vector3(0.0f, (float)-3.5 * Time.deltaTime, 0.0f), Space.World);
            }
        }
        else if (direction.Equals("down"))
        {
            if (inZone("verticalDown"))
            {
                yAxisTranslationDown = true;
                lastDirection = "verticalDown";
            }
            else
            {
                transform.Translate(new Vector3(0.0f, (float)3.5 * Time.deltaTime, 0.0f), Space.World);
            }
        }
    }

    private bool inZone(string direction)
    {
        if (direction.Equals("verticalUp"))
        {
            transform.Translate(new Vector3(0.0f, (float)3.5 * Time.deltaTime, 0.0f), Space.World);
            lastDirection = "";
        }
        else if (direction.Equals("verticalDown"))
        {
            transform.Translate(new Vector3(0.0f, (float)-3.5 * Time.deltaTime, 0.0f), Space.World);
            lastDirection = "";
        }

        if (transform.localPosition.x < -2)
        {
            return false;
        }
        else if (transform.localPosition.x > 2)
        {
            return false;
        }
        else if (transform.localPosition.y > 2.0f)
        {
            return false;
        }
        else if (transform.localPosition.y < (float)1.1)
        {
            return false;
        }
        else if (transform.localPosition.z > (float)-4.5)
        {
            return false;
        }
        else if (transform.localPosition.z < -6)
        {
            return false;
        }

        if (direction.Equals("verticalUp"))
        {
            transform.Translate(new Vector3(0.0f, (float)-3.5 * Time.deltaTime, 0.0f), Space.World);
        }
        else if (direction.Equals("verticalDown"))
        {
            transform.Translate(new Vector3(0.0f, (float)3.5 * Time.deltaTime, 0.0f), Space.World);
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
        else if(dampen < 3)
        {
            dampen += 0.11;
        }
        else
        {
            dampen = 3;
        }

        //print(dampen);
    }

    private void decreaseDampen()
    {
        if (dampen > 3)
        {
            dampen -= 0.05;
        }
        else if (dampen > 2)
        {
            dampen -= 0.8;
        }
        else if(dampen > 1)
        {
            dampen -= 0.11;
        }
        else
        {
            dampen = 0.5;
        }

        //print(dampen);
    }

    public void Lock()
    {
        upPressed = false;
        downPressed = false;
        wPressed = false;
        canvas.SetActive(false);

        locked = true;
    }

    public void Unlock()
    {
        locked = false;
        canvas.SetActive(true);
    }
}
