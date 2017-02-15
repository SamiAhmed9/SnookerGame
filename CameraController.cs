using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    
    private Transform tansform;
    private bool upPressed;
    private bool downPressed;
    private bool rightPressed;
    private bool leftPressed;
    private bool qPressed;
    private bool wPressed;
    private bool ePressed;

    private bool xAxisTranslationUp;
    private bool xAxisTranslationDown;
    private bool zAxisTranslationRight;
    private bool zAxisTranslationLeft;
    private bool yAxisTranslationUp;
    private bool yAxisTranslationDown;
    private bool zoomIn;
    private bool zoomOut;
    private bool cameraTranslated;
    private double cameraYRotation;
    private string cameraYString;

    private double dampen;
    private string lastDirection;

    private bool locked;

	void Start () {
        upPressed = false;
        downPressed = false;
        rightPressed = false;
        leftPressed = false;
        qPressed = false;
        wPressed = false;
        ePressed = false;

        xAxisTranslationUp = false;
        xAxisTranslationDown = false;
        zAxisTranslationRight = false;
        zAxisTranslationLeft = false;
        yAxisTranslationUp = false;
        yAxisTranslationDown = false;
        zoomIn = false;
        zoomOut = false;
        cameraTranslated = false;
        cameraYRotation = transform.localEulerAngles.y;
        cameraYString = "";

        dampen = 1;
        lastDirection = "";

        locked = false;
	}
	
	void Update () {
        xAxisTranslationUp = false;
        xAxisTranslationDown = false;
        zAxisTranslationRight = false;
        zAxisTranslationLeft = false;
        yAxisTranslationUp = false;
        yAxisTranslationDown = false;
        zoomIn = false;
        zoomOut = false;
        cameraTranslated = false;
        cameraYRotation = transform.localEulerAngles.y;
        if (cameraYRotation >= 225 && cameraYRotation < 315)
        {
            cameraYString = "up";
        }
        else if (cameraYRotation >= 45 && cameraYRotation < 135)
        {
            cameraYString = "down";
        }
        else if (cameraYRotation >= 315 || cameraYRotation < 45)
        {
            cameraYString = "right";
        }
        else if (cameraYRotation >= 135 && cameraYRotation < 225)
        {
            cameraYString = "left";
        }

        if (!locked)
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

            if (Input.GetKeyDown("q"))
            {
                //print("Q pressed");
                qPressed = true;
            }
            if (Input.GetKeyUp("q"))
            {
                //print("Q released");
                qPressed = false;
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

            if (Input.GetKeyDown("e"))
            {
                //print("E pressed");
                ePressed = true;
            }
            if (Input.GetKeyUp("e"))
            {
                //print("E released");
                ePressed = false;
            }
        }

        if(ePressed && upPressed)
        {
            zoom("in");
        } else if(ePressed && downPressed)
        {
            zoom("out");
        } else if (wPressed && rightPressed)
        {
            yAxisRotation("right");
        } else if(wPressed && leftPressed)
        {
            yAxisRotation("left");
        } else if(wPressed && upPressed)
        {
            xAxisRotation("up");
        } else if(wPressed && downPressed)
        {
            xAxisRotation("down");
        } else if (qPressed && upPressed)
        {
            yAxisTranslation("up");
        } else if (qPressed && downPressed)
        {
            yAxisTranslation("down");
        } else if (upPressed)
        {
            xAxisTranslation("up");
        } else if (downPressed)
        {
            xAxisTranslation("down");
        } else if (rightPressed)
        {
            zAxisTranslation("right");
        } else if (leftPressed)
        {
            zAxisTranslation("left");
        } else {

            if (dampen != 1)
            {
                decreaseDampen();
                if (lastDirection.Equals("up"))
                {
                    if (inZone("up"))
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
                        }
                        lastDirection = "up";
                    } else
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                        }
                    }

                } else if (lastDirection.Equals("down"))
                {
                    if (inZone("down"))
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
                        }
                        lastDirection = "down";
                    } else
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                        }
                    }

                } else if (lastDirection.Equals("right"))
                {
                    if (inZone("right"))
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        lastDirection = "right";
                    } else
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                    }

                } else if (lastDirection.Equals("left"))
                {
                    if (inZone("left"))
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        lastDirection = "left";
                    } else
                    {
                        if (cameraYString.Equals("up"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("down"))
                        {
                            transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                        }
                        else if (cameraYString.Equals("right"))
                        {
                            transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                        else if (cameraYString.Equals("left"))
                        {
                            transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                        }
                    }

                } else if (lastDirection.Equals("verticalUp"))
                {
                    if (inZone("verticalUp"))
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * Time.deltaTime, 0.0f), Space.World);
                        lastDirection = "verticalUp";
                    } else
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * -1 * Time.deltaTime, 0.0f), Space.World);
                    }
                } else if (lastDirection.Equals("verticalDown"))
                {
                    if (inZone("verticalDown"))
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * -1 * Time.deltaTime, 0.0f), Space.World);
                        lastDirection = "verticalDown";
                    } else
                    {
                        transform.Translate(new Vector3(0.0f, (float)dampen * Time.deltaTime, 0.0f), Space.World);
                    }
                } else if (lastDirection.Equals("rotationUp"))
                {
                    float x = transform.eulerAngles.x;
                    transform.Rotate(new Vector3(Time.deltaTime * -25 * ((float)(dampen / 4)), 0, 0));
                    if (x <= 340 && x >= 270)
                    {
                        transform.Rotate(new Vector3(Time.deltaTime * 25 * ((float)(dampen / 4)), 0, 0));
                    }
                } else if(lastDirection.Equals("rotationDown"))
                {
                    float x = transform.eulerAngles.x;
                    transform.Rotate(new Vector3(Time.deltaTime * 25 * ((float)(dampen / 4)), 0, 0));
                    if (x > 75 && x < 145)
                    {
                        transform.Rotate(new Vector3(Time.deltaTime * -25 * ((float)(dampen / 4)), 0, 0));
                    }
                } else if(lastDirection.Equals("rotationRight"))
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * 25 * (((float)dampen)/2), 0), Space.World);
                }
                else if (lastDirection.Equals("rotationLeft"))
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * -25 * (((float)dampen)/2), 0), Space.World);
                } else if(lastDirection.Equals("zoomIn"))
                {
                    if (inZone("zoomIn"))
                    {
                        transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime));
                        lastDirection = "zoomIn";
                    } else
                    {
                        transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime));
                    }
                }
                else if (lastDirection.Equals("zoomOut"))
                {
                    if (inZone("zoomOut"))
                    {
                        transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime));
                        lastDirection = "zoomOut";
                    } else
                    {
                        transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime));
                    }
                }
            }//end of if

        }//end of else

        if(xAxisTranslationUp)
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
            }
            cameraTranslated = true;
        } else if(xAxisTranslationDown)
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
            }
            cameraTranslated = true;
        } else if(zAxisTranslationRight)
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            cameraTranslated = true;
        } else if(zAxisTranslationLeft)
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3((float)dampen * -1 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3((float)dampen * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            cameraTranslated = true;
        }
        else if (yAxisTranslationUp)
        {
            transform.Translate(new Vector3(0.0f, (float)dampen * Time.deltaTime, 0.0f), Space.World);
            cameraTranslated = true;
        }
        else if (yAxisTranslationDown)
        {
            transform.Translate(new Vector3(0.0f, (float)dampen * -1 * Time.deltaTime, 0.0f), Space.World);
            cameraTranslated = true;
        } else if(zoomIn)
        {
            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * Time.deltaTime));
            cameraTranslated = true;
        } else if(zoomOut)
        {
            transform.Translate(new Vector3(0.0f, 0.0f, (float)dampen * -1 * Time.deltaTime));
            cameraTranslated = true;
        }
        if (dampen != 9 && cameraTranslated)
        {
            IncreaseDampen();
        }

	}//end of Update

    private void xAxisRotation(string direction)
    {
        bool enableUp = true;
        bool enableDown = true;
        float x = transform.eulerAngles.x;
        if (x <= 340 && x >= 270)
        {
            lastDirection = "rotationUp";
            enableUp = false;
        }
        else if (x > 75 && x < 145)
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
            transform.Rotate(new Vector3(Time.deltaTime * 25 * ((float)(dampen / 4)), 0 , 0));
            lastDirection = "rotationDown";
        }

        if (dampen != 9)
        {
            IncreaseDampen();
        }
    }

    private void yAxisRotation(string direction)
    {
        if (direction.Equals("right"))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * 25 * (((float)dampen)/2), 0), Space.World);

            lastDirection = "rotationRight";
        }
        else if (direction.Equals("left"))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -25 * (((float)dampen)/2), 0), Space.World);
            lastDirection = "rotationLeft";
        }

        if (dampen != 9)
        {
            IncreaseDampen();
        }
    }

    private void xAxisTranslation(string direction)
    {
        if (direction.Equals("up"))
        {
            if (inZone("up"))
            {
                xAxisTranslationUp = true;
                lastDirection = "up";
            } else
            {
                if (cameraYString.Equals("up"))
                {
                    transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
                else if (cameraYString.Equals("down"))
                {
                    transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
                else if (cameraYString.Equals("right"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                }
                else if (cameraYString.Equals("left"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                }
            }
        }
        else if (direction.Equals("down"))
        {
            if (inZone("down"))
            {
                xAxisTranslationDown = true;
                lastDirection = "down";
            } else
            {
                if (cameraYString.Equals("up"))
                {
                    transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
                else if (cameraYString.Equals("down"))
                {
                    transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
                else if (cameraYString.Equals("right"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                }
                else if (cameraYString.Equals("left"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                }
            }
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
                transform.Translate(new Vector3(0.0f, -10 * Time.deltaTime, 0.0f), Space.World);
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
                transform.Translate(new Vector3(0.0f, 10 * Time.deltaTime, 0.0f), Space.World);
            }
        }
    }

    private void zAxisTranslation(string direction)
    {
        if (direction.Equals("right"))
        {
            if (inZone("right"))
            {
                zAxisTranslationRight = true;
                lastDirection = "right";
            } else
            {
                if (cameraYString.Equals("up"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                }
                else if (cameraYString.Equals("down"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                }
                else if (cameraYString.Equals("right"))
                {
                    transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
                else if (cameraYString.Equals("left"))
                {
                    transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
            }
        }
        else if (direction.Equals("left"))
        {
            if (inZone("left"))
            {
                zAxisTranslationLeft = true;
                lastDirection = "left";
            } else
            {
                if (cameraYString.Equals("up"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
                }
                else if (cameraYString.Equals("down"))
                {
                    transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
                }
                else if (cameraYString.Equals("right"))
                {
                    transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
                else if (cameraYString.Equals("left"))
                {
                    transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
                }
            }
        }
    }

    private void zoom(string direction)
    {
        if (direction.Equals("in"))
        {
            if (inZone("zoomIn"))
            {
                zoomIn = true;
                lastDirection = "zoomIn";
            }
            else
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime));
            }
        }
        else if (direction.Equals("out"))
        {
            if (inZone("zoomOut"))
            {
                zoomOut = true;
                lastDirection = "zoomOut";
            }
            else
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime));
            }
        }
    }

    private bool inZone(string direction)
    {
        if (direction.Equals("up"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
            lastDirection = "";
        } else if (direction.Equals("down"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
            lastDirection = "";
        } else if (direction.Equals("right"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            lastDirection = "";
        } else if(direction.Equals("left"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            lastDirection = "";
        } else if(direction.Equals("verticalUp"))
        {
            transform.Translate(new Vector3(0.0f, 10 * Time.deltaTime, 0.0f), Space.World);
            lastDirection = "";
        } else if(direction.Equals("verticalDown"))
        {
            transform.Translate(new Vector3(0.0f, -10 * Time.deltaTime, 0.0f), Space.World);
            lastDirection = "";
        } else if(direction.Equals("zoomIn"))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime));
            lastDirection = "";
        } else if(direction.Equals("zoomOut"))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime));
            lastDirection = "";
        }
        
        if(transform.position.x < -20)
        {
            return false;
        } else if(transform.position.x > 30)
        {
            return false;
        } else if(transform.position.y > 15)
        {
            return false;
        } else if(transform.position.y < 0.4)
        {
            return false;
        } else if(transform.position.z > 11)
        {
            return false;
        } else if(transform.position.z < -11)
        {
            return false;
        }

        if (direction.Equals("up"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
        }
        else if (direction.Equals("down"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
        }
        else if (direction.Equals("right"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
        }
        else if (direction.Equals("left"))
        {
            if (cameraYString.Equals("up"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("down"))
            {
                transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime), Space.World);
            }
            else if (cameraYString.Equals("right"))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
            else if (cameraYString.Equals("left"))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0.0f, 0.0f), Space.World);
            }
        }
        else if (direction.Equals("verticalUp"))
        {
            transform.Translate(new Vector3(0.0f, -10 * Time.deltaTime, 0.0f), Space.World);
        }
        else if (direction.Equals("verticalDown"))
        {
            transform.Translate(new Vector3(0.0f, 10 * Time.deltaTime, 0.0f), Space.World);
        } else if(direction.Equals("zoomIn"))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -10 * Time.deltaTime));
        }
        else if (direction.Equals("zoomOut"))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, 10 * Time.deltaTime));
        }

        return true;
    }

    private void IncreaseDampen()
    {
        if(dampen < 2)
        {
            dampen += 0.1;
        } else if(dampen < 4)
        {
            dampen += 0.2;
        } else if(dampen < 9)
        {
            dampen += 0.25;
        } else
        {
            dampen = 9;
        }
        
        //print(dampen);
    }

    private void decreaseDampen()
    {
        if (dampen > 9)
        {
            dampen -= 0.1;
        }
        else if (dampen > 6)
        {
            dampen -= 0.2;
        }
        else if (dampen > 1)
        {
            dampen -= 0.25;
        }
        else
        {
            dampen = 1;
        }

        //print(dampen);
    }

    public void Lock()
    {
        upPressed = false;
        downPressed = false;
        rightPressed = false;
        leftPressed = false;
        qPressed = false;
        wPressed = false;
        ePressed = false;

        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }
}
