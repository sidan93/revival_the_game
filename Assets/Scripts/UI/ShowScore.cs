using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    public _Hero hero;
    private Text text;

    void Start ()
    {
        text = this.GetComponent<Text>();
    }

    void Update ()
    {
	    if (hero)
        {
            text.text = "Score: " + hero.Score.ToString();

            if (!hero.isAlive)
               text.text = "YOU LOSE!!! Score: " + hero.Score.ToString();
        }
    }
}
