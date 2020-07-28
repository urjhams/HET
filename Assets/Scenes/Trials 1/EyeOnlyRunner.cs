using UnityEngine;

public class EyeOnlyRunner : MonoBehaviour
{
    public static GameObject selectedObj;
    public GameObject objMain;
    public GameObject[] subObj;
    public GameObject[]subFrame;
    public Sprite[] spriteList;
    public Sprite[] frameSprites;
    private Sprite selectedPattern;
    public float timeLeft = 30;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        this.getRandomMainObjSprite();
        this.fillSubObjectWithRandomSprite();
        Debug.Log(GameObject.Find("obj_main").GetComponent<SpriteRenderer>().sprite.name);
    }

    // Update is called once per frame
    void Update()
    {
        // timeLeft -= Time.deltaTime;
        // if (timeLeft >= 0) {
        //     Debug.Log(timeLeft);
        // }
        int selectedIndex = System.Array.IndexOf(subFrame, selectedObj);
        if (selectedIndex != -1) {
            selectedPattern = spriteList[selectedIndex];
        }
        //Debug.Log(selectedIndex);
    }

    private void getRandomMainObjSprite() {
        System.Random random = new System.Random();
        int randomIndex = random.Next(0,spriteList.Length - 1);
        objMain.GetComponent<SpriteRenderer>().sprite = spriteList[randomIndex];
    }

    private void fillSubObjectWithRandomSprite() {
        this.reshuffle(spriteList);
        for (int index = 0; index < subObj.Length; index++) {
            subObj[index].GetComponent<SpriteRenderer>().sprite = spriteList[index];
        }
    }

    void reshuffle<T>(T[] array) {
        for (int index = 0; index < array.Length; index++) {
            T temp = array[index];
            int random = Random.Range(index, array.Length);
            array[index] = array[random];
            array[random] = temp;
        }
    }
}
