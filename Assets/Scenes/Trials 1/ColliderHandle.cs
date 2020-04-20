using UnityEngine;

public class ColliderHandle : MonoBehaviour
{
    /// <summary>
    /// Called every frame while the mouse is over the GUIElement or Collider.
    /// </summary>
    void OnMouseOver()
    {
        EyeOnlyRunner.selectedObj = this.gameObject;
        EyeOnlyRunner.selectedObj.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameRunner").GetComponent<EyeOnlyRunner>().frameSprites[1];
    }

    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    void OnMouseExit()
    {
        EyeOnlyRunner.selectedObj.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameRunner").GetComponent<EyeOnlyRunner>().frameSprites[0];
        EyeOnlyRunner.selectedObj = null;
    }

    /// Note: here we are using a mouse so I override those functions
    /// However, when using a tracker or something, try to get the point (Vector 3) and check if it inside a collider of this object
    /// https://docs.unity3d.com/ScriptReference/Bounds.Contains.html?_ga=2.68712785.1575043690.1587391725-154023349.1587391725
}
