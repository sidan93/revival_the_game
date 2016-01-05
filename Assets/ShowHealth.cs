using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour {
    public Hero hero;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (hero)
        {
            var text = this.GetComponent<Text>() as Text;
            text.text = "Health: " + hero.currentHealth.ToString() + " HP";
        }
    }
}
