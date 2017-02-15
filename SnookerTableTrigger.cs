using UnityEngine;
using System.Collections;

public class SnookerTableTrigger : MonoBehaviour {

    public CameraManager cameraManager;
    public ShotManager shotManager;

    private void OnMouseDown()
    {
        cameraManager.UnlockCamera();
        if (!cameraManager.GetCheckBallsPositions())
        {
            shotManager.EscapeShotMode();
        }
    }
}
