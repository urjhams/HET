using UnityEngine;

public class ColliderHandleHard : MonoBehaviour
{
    private void registerSelectedObject() {
        EyeOnlyHardRunner.selectedObj = this.gameObject;
    }

    private void deRegisterSelectedObject() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameRunner").GetComponent<EyeOnlyHardRunner>().white;
        EyeOnlyHardRunner.selectedObj = null;
        EyeOnlyHardRunner.headSelectedObj = null;
    }

    private void registerHeadSelectedObject() {
        // only work if in head-eye mode and this is the selected object already
        if (Global.currentState != TrialState.HeadEye) { return; }
        if (EyeOnlyHardRunner.selectedObj == this.gameObject) {
            EyeOnlyHardRunner.headSelectedObj = this.gameObject;
        }
        
    }

    private void deRegisterHeadSelectedObject() {
        if (Global.currentState != TrialState.HeadEye) { return; }
        if (EyeOnlyHardRunner.selectedObj == this.gameObject) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameRunner").GetComponent<EyeOnlyHardRunner>().blue;
            EyeOnlyHardRunner.headSelectedObj = null;
        }
        
    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("eyeCursor")) 
        {
            registerSelectedObject();
        }
        if (other.gameObject.name.Equals("headCursor")) 
        {
            registerHeadSelectedObject();
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("eyeCursor")) 
        {
            deRegisterSelectedObject();
        }
        if (other.gameObject.name.Equals("headCursor")) 
        {
            deRegisterHeadSelectedObject();
        }
    }
}
