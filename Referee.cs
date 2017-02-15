using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Referee : MonoBehaviour {

    public Transform cueBall;
    public Transform yellowBall;
    public Transform greenBall;
    public Transform brownBall;
    public Transform blueBall;
    public Transform pinkBall;
    public Transform blackBall;
    public Transform redBall1;
    public Transform redBall2;
    public Transform redBall3;
    public Transform redBall4;
    public Transform redBall5;
    public Transform redBall6;
    public Transform redBall7;
    public Transform redBall8;
    public Transform redBall9;
    public Transform redBall10;
    public Transform redBall11;
    public Transform redBall12;
    public Transform redBall13;
    public Transform redBall14;
    public Transform redBall15;

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

    public Player1Text firstBox;
    public P2HSText secondBox;
    public MessageText messageBox;

    private string onTable;
    private string offTable;
    private bool mode;
    private bool colour;
    private int player1Score;
    private int player2Score;
    private int highestScore;
    private string[] potted;
    private string firstTouch;
    private bool checkY;
    private Vector3[] positions;
    private Rigidbody[] rigidbodies;
    private bool putInPlace;
    private float time;

	void Start () {
        onTable = "Player 1";
        offTable = "Player 2";
        colour = false;
        player1Score = 0;
        player2Score = 0;
        highestScore = 0;
        potted = new string[0];
        firstTouch = "";

        positions = new Vector3[22];
        rigidbodies = new Rigidbody[22];
        rigidbodies[0] = cueBallRB;
        rigidbodies[1] = yellowBallRB;
        rigidbodies[2] = greenBallRB;
        rigidbodies[3] = brownBallRB;
        rigidbodies[4] = blueBallRB;
        rigidbodies[5] = pinkBallRB;
        rigidbodies[6] = blackBallRB;
        rigidbodies[7] = redBall1RB;
        rigidbodies[8] = redBall2RB;
        rigidbodies[9] = redBall3RB;
        rigidbodies[10] = redBall4RB;
        rigidbodies[11] = redBall5RB;
        rigidbodies[12] = redBall6RB;
        rigidbodies[13] = redBall7RB;
        rigidbodies[14] = redBall8RB;
        rigidbodies[15] = redBall9RB;
        rigidbodies[16] = redBall10RB;
        rigidbodies[17] = redBall11RB;
        rigidbodies[18] = redBall12RB;
        rigidbodies[19] = redBall13RB;
        rigidbodies[20] = redBall14RB;
        rigidbodies[21] = redBall15RB;
        putInPlace = false;
        time = 0.5f;
    }

    void FixedUpdate()
    {
        if(checkY)
        {
            positions[0] = cueBall.position;
            positions[1] = yellowBall.position;
            positions[2] = greenBall.position;
            positions[3] = brownBall.position;
            positions[4] = blueBall.position;
            positions[5] = pinkBall.position;
            positions[6] = blackBall.position;
            positions[7] = redBall1.position;
            positions[8] = redBall2.position;
            positions[9] = redBall3.position;
            positions[10] = redBall4.position;
            positions[11] = redBall5.position;
            positions[12] = redBall6.position;
            positions[13] = redBall7.position;
            positions[14] = redBall8.position;
            positions[15] = redBall9.position;
            positions[16] = redBall10.position;
            positions[17] = redBall11.position;
            positions[18] = redBall12.position;
            positions[19] = redBall13.position;
            positions[20] = redBall14.position;
            positions[21] = redBall15.position;
            for (int i = 0; i < positions.Length; i++)
            {
                if(positions[i].y < -5)
                {
                    rigidbodies[i].useGravity = false;
                    rigidbodies[i].velocity = new Vector3(0.0f, 0.0f, 0.0f);
                    checkY = false;
                }
            }
        }
        if(putInPlace)
        {
            yellowBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            greenBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            brownBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            blueBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            pinkBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            blackBallRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
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
            time -= Time.deltaTime;
            if(time < 0)
            {
                putInPlace = false;
            }
        }
        
    }

    public void SetModePractice()
    {
        mode = true;
        player1Score = 0;
        highestScore = 0;
        colour = false;
        firstBox.text.text = "Player 1: " + player1Score;
        secondBox.text.text = "High Score: " + highestScore;
        messageBox.text.text = "";
    }

    public void SetModeTwoPlayer()
    {
        mode = false;
        player1Score = 0;
        player2Score = 0;
        colour = false;
        firstBox.text.text = "Player 1: " + player1Score;
        secondBox.text.text = "Player 2: " + player2Score;
        messageBox.text.text = "";
    }

    public void TurnEnded()
    {
        if(potted.Length == 0)//You've taken a shot and haven't potted anything
        {
            if(mode)//You're in practice mode
            {
                if(colour)//You should pot a colour
                {
                    if(!firstTouch.Equals(""))//You have touched something
                    {
                        if(!firstTouch.Equals("Red"))//You've touched a colour
                        {
                            player1Score = 0;
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Highest Score: " + highestScore;
                            messageBox.text.text = "You did not pot a colour. Your score has been reset to 0.";
                            colour = false;
                        } else//You've touched a red instead
                        {
                            player1Score = 0;
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Highest Score: " + highestScore;
                            messageBox.text.text = "You have touched a red first instead of a colour. Your score has been reset to 0.";
                            colour = false;
                        }
                    } else//You have not touched anything
                    {
                        player1Score = 0;
                        firstBox.text.text = "Player 1: " + player1Score;
                        secondBox.text.text = "Highest Score: " + highestScore;
                        messageBox.text.text = "You have not touched any ball. Your score has been reset to 0.";
                        colour = false;
                    }
                } else//You should pot a red
                {
                    if(!firstTouch.Equals(""))//You have touched something
                    {
                        if(!firstTouch.Equals("Red"))//You have touched a colour
                        {
                            player1Score = 0;
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Highest Score: " + highestScore;
                            messageBox.text.text = "You have touched a colour first instead of a red. Your score has been reset to 0.";
                            colour = false;
                        } else//You have touched a red
                        {
                            player1Score = 0;
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Highest Score: " + highestScore;
                            messageBox.text.text = "You did not pot a red. Your score has been reset to 0.";
                            colour = false;
                        }
                    } else//You have not touched anything
                    {
                        player1Score = 0;
                        firstBox.text.text = "Player 1: " + player1Score;
                        secondBox.text.text = "Highest Score: " + highestScore;
                        messageBox.text.text = "You have not touched any ball. Your score has been reset to 0.";
                        colour = false;
                    }
                }
            } else//You are in two-player mode
            {
                if(colour)//You should pot a colour
                {
                    if(!firstTouch.Equals(""))//You have touched something
                    {
                        if(!firstTouch.Equals("Red"))//You have touched a colour first
                        {
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Player 2: " + player2Score;
                            messageBox.text.text = onTable + "has not potted a colour. It is now " + offTable + "'s turn.";
                            colour = false;
                            string middleMan = onTable;
                            onTable = offTable;
                            offTable = middleMan;
                        } else//You have touched a red
                        {
                            if(onTable.Equals("Player 1"))
                            {
                                player2Score += 4;
                            } else
                            {
                                player1Score += 4;
                            }
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Player 2: " + player2Score;
                            messageBox.text.text = onTable + "has hit a red first instead of hitting a colour. " + offTable + " receives 4 points. It is now " + offTable + "'s turn.";
                            colour = false;
                            string middleMan = onTable;
                            onTable = offTable;
                            offTable = middleMan;
                        }
                    } else//You have not touched anything
                    {
                        if (onTable.Equals("Player 1"))
                        {
                            player2Score += 4;
                        }
                        else
                        {
                            player1Score += 4;
                        }
                        firstBox.text.text = "Player 1: " + player1Score;
                        secondBox.text.text = "Player 2: " + player2Score;
                        messageBox.text.text = onTable + " has not touched any ball. " + offTable + " receives 4 points. It is now " + offTable + "'s turn.";
                        colour = false;
                        string middleMan = onTable;
                        onTable = offTable;
                        offTable = middleMan;
                    }
                } else//You should pot a red
                {
                    if(!firstTouch.Equals(""))//You have touched something
                    {
                        if(!firstTouch.Equals("Red"))//You have touched a colour
                        {
                            int foul = 0;
                            if(firstTouch.Equals("Black"))
                            {
                                foul = 7;
                            } else if(firstTouch.Equals("Pink"))
                            {
                                foul = 6;
                            } else if(firstTouch.Equals("Blue"))
                            {
                                foul = 5;
                            } else
                            {
                                foul = 4;
                            }
                            if (onTable.Equals("Player 1"))
                            {
                                player2Score += foul;
                            }
                            else
                            {
                                player1Score += foul;
                            }
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Player 2: " + player2Score;
                            messageBox.text.text = onTable + " has touched a colour first instead of hitting a red. " + offTable + " is awarded " + foul + " points. It is now " + offTable + "'s turn.";
                            colour = false;
                            string middleMan = onTable;
                            onTable = offTable;
                            offTable = middleMan;
                        } else//You have touched a red
                        {
                            firstBox.text.text = "Player 1: " + player1Score;
                            secondBox.text.text = "Player 2: " + player2Score;
                            messageBox.text.text = onTable + " has not potted a red. It is now " + offTable + "'s turn.";
                            colour = false;
                            string middleMan = onTable;
                            onTable = offTable;
                            offTable = middleMan;
                        }
                    } else//You have not touched anything
                    {
                        if (onTable.Equals("Player 1"))
                        {
                            player2Score += 4;
                        }
                        else
                        {
                            player1Score += 4;
                        }
                        firstBox.text.text = "Player 1: " + player1Score;
                        secondBox.text.text = "Player 2: " + player2Score;
                        messageBox.text.text = onTable + " has not touched any ball. " + offTable + " receives 4 points. It is now " + offTable + "'s turn.";
                        colour = false;
                        string middleMan = onTable;
                        onTable = offTable;
                        offTable = middleMan;
                    }
                }
            }
        } else if(potted.Length == 1)
        {
            if(potted[0].Equals("CueBall"))
            {
                if(mode)//You are in practice mode
                {
                    player1Score = 0;
                    firstBox.text.text = "Player 1: " + player1Score;
                    secondBox.text.text = "Highest Score: " + highestScore;
                    messageBox.text.text = "You have potted the cue ball. Your score has been reset to 0.";
                    colour = false;
                    PutInPlace("CueBall");
                } else//You are in two-player mode
                {
                    if (onTable.Equals("Player 1"))
                    {
                        player2Score += 4;
                    }
                    else
                    {
                        player1Score += 4;
                    }
                    firstBox.text.text = "Player 1: " + player1Score;
                    secondBox.text.text = "Player 2: " + player2Score;
                    messageBox.text.text = onTable + " has potted the cue ball. " + offTable + " receives 4 points and it is now " + offTable + "'s turn.";
                    colour = false;
                    string middleMan = onTable;
                    onTable = offTable;
                    offTable = middleMan;
                    PutInPlace("CueBall");
                }
            }
            if(mode)//This is practice mode
            {
                if(colour)//You are supposed to pot a colour
                {
                    if (!firstTouch.Equals("Red"))//You have touched a colour first
                    {
                        if(potted[0].Equals("Red"))
                        {
                            if (onTable.Equals("Player 1"))
                            {
                                player2Score += 4;
                            }
                            else
                            {
                                player1Score += 4;
                            }
                            ImplementOutcome();
                        } else if(potted[0].Equals("Yellow"))
                        {

                        }
                        else if (potted[0].Equals("Green"))
                        {

                        }
                        else if (potted[0].Equals("Brown"))
                        {

                        }
                        else if (potted[0].Equals("Blue"))
                        {

                        }
                        else if (potted[0].Equals("Pink"))
                        {

                        }
                        else if (potted[0].Equals("Black"))
                        {

                        }
                    } else//You have touched a red first
                    {

                    }
                } else//You are supposed to pot a red
                {
                    if (!firstTouch.Equals("Red"))//You have touched a colour first
                    {

                    }
                    else//You have touched a red first
                    {

                    }
                }
            } else//You are in two-player mode
            {
                if (colour)//You are supposed to pot a colour
                {
                    if (!firstTouch.Equals("Red"))//You have touched a colour first
                    {

                    }
                    else//You have touched a red first
                    {

                    }
                }
                else//You are supposed to pot a red
                {
                    if (!firstTouch.Equals("Red"))//You have touched a colour first
                    {

                    }
                    else//You have touched a red first
                    {

                    }
                }
            }
        }
        firstTouch = "";
    }


    public void Potted(string colour)
    {
        string[] potted2 = new string[potted.Length + 1];
        for (int i = 0; i < potted.Length; i++)
        {
            if(i != 0)
            {
                potted2[i] = potted[i];
            }
        }
        potted2[potted.Length] = colour;
        potted = potted2;
        checkY = true;
    }

    public void SetFirst(string tag)
    {
        firstTouch = tag;
    }

    public bool HasFirst()
    {
        if(firstTouch.Equals(""))
        {
            return false;
        } else
        {
            return true;
        }

    }

    private void PutInPlace(string ball)
    {
        if(ball.Equals("CueBall"))
        {
            rigidbodies[0].useGravity = true;
            Collider collider = rigidbodies[0].GetComponent<Collider>();
            collider.enabled = true;
            cueBall.position = new Vector3(12.5f, 0.25f, 1.5f);
        } else if(ball.Equals("Yellow"))
        {
            rigidbodies[1].useGravity = true;
            Collider collider = rigidbodies[1].GetComponent<Collider>();
            collider.enabled = true;
            yellowBall.position = new Vector3(11.0f, 0.25f, 3.0f);
        } else if(ball.Equals("Green"))
        {
            rigidbodies[2].useGravity = true;
            Collider collider = rigidbodies[2].GetComponent<Collider>();
            collider.enabled = true;
            cueBall.position = new Vector3(11.0f, 0.25f, -3.0f);
        } else if(ball.Equals("Brown"))
        {
            rigidbodies[3].useGravity = true;
            Collider collider = rigidbodies[3].GetComponent<Collider>();
            collider.enabled = true;
            cueBall.position = new Vector3(11.0f, 0.25f, 0.0f);
        } else if(ball.Equals("Blue"))
        {
            rigidbodies[4].useGravity = true;
            Collider collider = rigidbodies[4].GetComponent<Collider>();
            collider.enabled = true;
            cueBall.position = new Vector3(0.0f, 0.25f, 0.0f);
        } else if(ball.Equals("Pink"))
        {
            rigidbodies[5].useGravity = true;
            Collider collider = rigidbodies[5].GetComponent<Collider>();
            collider.enabled = true;
            cueBall.position = new Vector3(-9.0f, 0.25f, 0.0f);
        } else if(ball.Equals("Black"))
        {
            rigidbodies[6].useGravity = true;
            Collider collider = rigidbodies[6].GetComponent<Collider>();
            collider.enabled = true;
            cueBall.position = new Vector3(-15.0f, 0.25f, 0.0f);
        }
        putInPlace = true;
        time = 0.5f;
    }

    private void ImplementOutcome()
    {
        
    }

}
