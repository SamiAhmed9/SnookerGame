using UnityEngine;
using System.Collections;

public class CueBallXTranslation : MonoBehaviour {
    
    private bool rightPressed;
    private bool leftPressed;
    private bool wPressed;

    private bool xAxisTranslationRight;
    private bool xAxisTranslationLeft;
    private bool cameraTranslated;

    private double dampen;
    private string lastDirection;

    public Transform cameraTransform;

    private bool locked;

    void Start () {
        rightPressed = false;
        leftPressed = false;
        wPressed = false;

        xAxisTranslationRight = false;
        xAxisTranslationLeft = false;
        cameraTranslated = false;

        dampen = 0.5;
        lastDirection = "";

        locked = false;
    }
	
	void Update () {
        xAxisTranslationRight = false;
        xAxisTranslationLeft = false;
        cameraTranslated = false;

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

        if(wPressed && rightPressed)
        {
            xAxisTranslation("right");
        } else if(wPressed && leftPressed)
        {
            xAxisTranslation("left");
        }
        else
        {
            if(dampen != 0.5)
            {
                decreaseDampen();
                if(lastDirection.Equals("right"))
                {
                    if (inZone("right"))
                    {
                        cameraTransform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f));
                        lastDirection = "right";
                    }
                    else
                    {
                        cameraTransform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f));
                    }
                } else if(lastDirection.Equals("left"))
                {
                    if (inZone("left"))
                    {
                        cameraTransform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f));
                        lastDirection = "left";
                    }
                    else
                    {
                        cameraTransform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f));
                    }
                }
            }//end of if
        }//end of else

        if(xAxisTranslationRight)
        {
            cameraTransform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f));
            cameraTranslated = true;
        } else if(xAxisTranslationLeft)
        {
            cameraTransform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f));
            cameraTranslated = true;
        }
        if (dampen != 3 && cameraTranslated)
        {
            IncreaseDampen();
        }
    }//end of update

    private void xAxisTranslation(string direction)
    {
        if (direction.Equals("right"))
        {
            if (inZone("right"))
            {
                xAxisTranslationRight = true;
                lastDirection = "right";
            }
            else
            {
                cameraTransform.Translate(new Vector3((float)-3.5 * Time.deltaTime, 0.0f, 0.0f));
            }
        }
        else if (direction.Equals("left"))
        {
            if (inZone("left"))
            {
                xAxisTranslationLeft = true;
                lastDirection = "left";
            }
            else
            {
                cameraTransform.Translate(new Vector3((float)3.5 * Time.deltaTime, 0.0f, 0.0f));
            }
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
        else if (dampen > 1)
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
