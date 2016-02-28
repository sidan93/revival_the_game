using Assets.Scripts.Units.Heroes;
using UnityEngine;
using UnityEngine.UI;

class ShowHealth : MonoBehaviour {
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
            text.text = "Health: " + hero.CurrentHealth + " HP";
        }
    }
}
