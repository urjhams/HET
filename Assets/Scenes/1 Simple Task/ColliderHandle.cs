using UnityEngine;

public class ColliderHandle : MonoBehaviour
{
    private void registerSelectedObject() {
        EyeOnlyRunner.selectedObj = this.gameObject;
        EyeOnlyRunner.selectedObj.GetComponent<SpriteRenderer>().sprite = 
        GameObject.Find("GameRunner").GetComponent<EyeOnlyRunner>().frameSprites[1];
    }

    private void deRegisterSelectedObject() {
        EyeOnlyRunner.selectedObj.GetComponent<SpriteRenderer>().sprite = 
        GameObject.Find("GameRunner").GetComponent<EyeOnlyRunner>().frameSprites[0];
        EyeOnlyRunner.selectedObj = null;
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
    }
}
