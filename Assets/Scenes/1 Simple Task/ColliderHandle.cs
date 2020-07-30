using UnityEngine;

public class ColliderHandle : MonoBehaviour
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
    }

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
    /// Note: here we are using a mouse so I override those functions
    /// However, when using a tracker or something, try to get the point (Vector 3) and check if it inside a collider of this object
    /// https://docs.unity3d.com/ScriptReference/Bounds.Contains.html?_ga=2.68712785.1575043690.1587391725-154023349.1587391725
}
