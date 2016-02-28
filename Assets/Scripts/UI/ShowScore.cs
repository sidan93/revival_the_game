using Assets.Scripts.Units.Heroes;
using UnityEngine;
using UnityEngine.UI;

class ShowScore : MonoBehaviour {

    public Hero hero;
    private Text text;

    void Start ()
    {
        text = this.GetComponent<Text>();
    }

    void Update ()
    {
	    if (hero)
        {
            //text.text = "Score: " + hero.Score.ToString();

            //if (!hero.isAlive)
               //text.text = "YOU LOSE!!! Score: " + hero.Score.ToString();
        }
    }
}
