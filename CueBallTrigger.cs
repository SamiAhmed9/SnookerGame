using UnityEngine;
using System.Collections;

public class CueBallTrigger : MonoBehaviour {

    public CameraManager cameraManager;
    public ShotManager shotManager;
    public Referee referee;

    private void OnMouseDown()
    {
        cameraManager.UnlockCueBallCamera();
        if(!cameraManager.GetCheckBallsPositions())
        {
            shotManager.ShotMode();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if(collider.tag.Equals("Red") || collider.tag.Equals("Yellow") || collider.tag.Equals("Green") || collider.tag.Equals("Brown") || collider.tag.Equals("Blue")
             || collider.tag.Equals("Pink") || collider.tag.Equals("Black"))
        {
            if (!referee.HasFirst())
            {
                referee.SetFirst(collider.tag);
            }
        }
    }
}
