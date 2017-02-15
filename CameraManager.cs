using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public Camera camera;
    public CameraController cameraController;

    public Camera cueBallCamera;
    public CueBallCameraController cueBallCameraController;
    public CueBallXTranslation cueBallXTranslation;
    public CueBallYRotation cueBallYRotation;

    public Camera shotCamera;
    public ShotManager shotManager;

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

    private bool checkBallsPositions;
    private Vector3[] positions;
    private Vector3[] newPositions;
    private bool allowPositionChecks;

    public Referee referee;
    
	void Start () {
        cameraController.Unlock();
        camera.enabled = true;

        cueBallCameraController.Lock();
        cueBallXTranslation.Lock();
        cueBallYRotation.Lock();
        cueBallCamera.enabled = false;

        shotManager.Lock();
        shotCamera.enabled = false;

        checkBallsPositions = false;
        positions = new Vector3[22];
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
        newPositions = new Vector3[22];
        GetNewPositions();
        allowPositionChecks = false;
	}

    void FixedUpdate()
    {
        if (allowPositionChecks)
        {
            GetNewPositions();
            if (!CheckBallsPositions())
            {
                GetPositions();
                checkBallsPositions = true;
            }
            else
            {
                checkBallsPositions = false;
                allowPositionChecks = false;
                referee.TurnEnded();
            }
        }
    }

    public void UnlockCamera()
    {
        if(!checkBallsPositions)
        {
            cameraController.Unlock();
            camera.enabled = true;

            cueBallCameraController.Lock();
            cueBallXTranslation.Lock();
            cueBallYRotation.Lock();
            cueBallCamera.enabled = false;

            shotManager.Lock();
            shotCamera.enabled = false;

            allowPositionChecks = false;
        }
    }

    public void OverrideUnlockCamera()
    {
        cameraController.Unlock();
        camera.enabled = true;

        cueBallCameraController.Lock();
        cueBallXTranslation.Lock();
        cueBallYRotation.Lock();
        cueBallCamera.enabled = false;

        shotManager.Lock();
        shotCamera.enabled = false;

        checkBallsPositions = false;
        allowPositionChecks = false;
    }

    public void UnlockCueBallCamera()
    {
        if(!checkBallsPositions)
        {
            cueBallCameraController.Unlock();
            cueBallXTranslation.Unlock();
            cueBallYRotation.Unlock();
            cueBallCamera.enabled = true;

            cameraController.Lock();
            camera.enabled = false;

            shotManager.Lock();
            shotCamera.enabled = false;

            allowPositionChecks = false;
        }
    }

    public void UnlockShotCamera()
    {
        shotCamera.enabled = true;

        cameraController.Lock();
        camera.enabled = false;

        cueBallCameraController.Lock();
        cueBallXTranslation.Lock();
        cueBallYRotation.Lock();
        cueBallCamera.enabled = false;

        allowPositionChecks = false;
    }

    public void SetWaitTime()
    {
        checkBallsPositions = true;
    }

    public void AllowPositionChecks()
    {
        if(shotCamera.enabled)
        {
            allowPositionChecks = true;
        }
    }

    private bool CheckBallsPositions()
    {
        for(int i = 0; i < positions.Length; i++)
        {
            if (positions[i] != newPositions[i])
            {
                return false;
            }
        }

        return true;
    }

    private void GetPositions()
    {
        for(int i = 0; i < 22; i++)
        {
            positions[i] = newPositions[i];
        }
    }

    public void GetNewPositions()
    {
        newPositions[0] = cueBall.position;
        newPositions[1] = yellowBall.position;
        newPositions[2] = greenBall.position;
        newPositions[3] = brownBall.position;
        newPositions[4] = blueBall.position;
        newPositions[5] = pinkBall.position;
        newPositions[6] = blackBall.position;
        newPositions[7] = redBall1.position;
        newPositions[8] = redBall2.position;
        newPositions[9] = redBall3.position;
        newPositions[10] = redBall4.position;
        newPositions[11] = redBall5.position;
        newPositions[12] = redBall6.position;
        newPositions[13] = redBall7.position;
        newPositions[14] = redBall8.position;
        newPositions[15] = redBall9.position;
        newPositions[16] = redBall10.position;
        newPositions[17] = redBall11.position;
        newPositions[18] = redBall12.position;
        newPositions[19] = redBall13.position;
        newPositions[20] = redBall14.position;
        newPositions[21] = redBall15.position;
    }

    public bool GetCheckBallsPositions()
    {
        return checkBallsPositions;
    }
}
