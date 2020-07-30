using UnityEngine;
enum TrialState {
    Eye, HeadEye
}
public class EyeOnlyRunner : MonoBehaviour
{
    public static GameObject selectedObj;
    public GameObject objMain;      // The main pattern object
    public GameObject[] subObj;     // pattern objects list
    public GameObject[] subFrame;   // the frame object list (which co-responding with pattern objects as container)
    public Sprite[] spriteList;     // list of sprites for patterns
    public Sprite[] frameSprites;   // list of sprites for frame objects (use for different color of the frame)
    // private Sprite selectedPattern; // current selected pattern (which the eye gaze is onto)
    public float timeLeft = 30;     // the trial time left, will counted down right from start

    // after this amount of time when eye gaze hit the objects, it will be counted as "lock" (eye only scenario)
    private float eyeLockTime = 2;

    // after this amount of seconds when selecting, active confirmation result (correct or incorrect) 
    private float confirmTime = 2;  

    private int currentRandomIndex = -1;    // the saved sprite index of the main object

    TrialState state = TrialState.Eye;

    void Start()
    {
        // Cursor.visible = true;

        // fill random pattern sprites
        this.fillSubObjectWithRandomSprite();

        // then chose one of them randomly as the main object to compare
        this.getRandomMainObjSprite();

        // Debug.Log(GameObject.Find("obj_main").GetComponent<SpriteRenderer>().sprite.name);
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.state) {
            case TrialState.Eye:
                updateInEyeOnly();
                break;
            case TrialState.HeadEye:
                updateInHeadEye();
                break;
        }
    }

    private void updateInEyeOnly() {
        // trial time count down (in total)
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            //TODO: put the trail to end state
        } else {
            //Debug.Log(timeLeft);
        }

        // the selected pattern must be one of the pattern in the provided patterns list, so compare to find out its index
        int selectedIndex = System.Array.IndexOf(subFrame, selectedObj);
        
        /*
        with every frame, if there is a selected object (it can be only one at the time anyway),
        selected index will be the index number, otherwise it will be -1, so just need to check instead
        */
        // if (selectedIndex != -1) {
        //     selectedPattern = spriteList[selectedIndex];    // save the current selected pattern
        // }
        
        /*
            eye lock time counting down, but will reset and stop the next seps if there is no selected object
        */
        eyeLockTime -= Time.deltaTime;
        if (selectedObj == null) {
            eyeLockTime = 2;
            confirmTime = 2;
            return;
        }

        /*
            when the lock time is over, start the confirm time
        */
        if (eyeLockTime <= 0) {
            EyeOnlyRunner.selectedObj.GetComponent<SpriteRenderer>().sprite = 
                GameObject.Find("GameRunner").GetComponent<EyeOnlyRunner>().frameSprites[4];

            confirmTime -= Time.deltaTime;
            if (selectedObj == null) {
                confirmTime = 2;
                eyeLockTime = 2;
                return;
            } else {
                if (confirmTime <= 0.0) {
                    EyeOnlyRunner.selectedObj.GetComponent<SpriteRenderer>().sprite = 
                        GameObject.Find("GameRunner").GetComponent<EyeOnlyRunner>()
                            .frameSprites[(selectedIndex == currentRandomIndex) ? 2 : 3];
                }
            }
        } else {
            return;
        }
    }

    private void updateInHeadEye() {
        //TODO:
    }

    private void getRandomMainObjSprite() {

        System.Random random = new System.Random();
        int randomIndex = random.Next(0,spriteList.Length - 1);

        // when the random main object has been chosen, save its index from the pattern's sprites array
        currentRandomIndex = randomIndex;

        // apply the pattern sprite from the sprites array by the random index
        objMain.GetComponent<SpriteRenderer>().sprite = spriteList[randomIndex];
    }

    private void fillSubObjectWithRandomSprite() {
        // first, shuffle the order of the sprites array
        this.reshuffle(spriteList);

        // finally, fill them into the pattern objects
        for (int index = 0; index < subObj.Length; index++) {
            subObj[index].GetComponent<SpriteRenderer>().sprite = spriteList[index];
        }
    }
    /// <summary>
    /// shuffle the elements in an array
    /// </summary>
    void reshuffle<T>(T[] array) {
        for (int index = 0; index < array.Length; index++) {
            T temp = array[index];
            int random = Random.Range(index, array.Length);
            array[index] = array[random];
            array[random] = temp;
        }
    }
}
