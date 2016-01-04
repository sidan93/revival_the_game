using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {
    public Hero hero;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (hero)
        {
            var text = this.GetComponent<Text>() as Text;
            text.text = "Score: " + hero.Score.ToString();

            if (!hero.isLife)
               text.text = "YOU LOSE!!! Score: " + hero.Score.ToString();
        }
    }
}
