﻿using Assets.Scripts.Units.Monsters;
using Assets.Scripts.Buildings;
using UnityEngine;
using UnityEngine.UI;

public class ShowTarget : MonoBehaviour {

    bool startDelete = false;
    float startTime;
    float deleteTime = 1;
    // Use this for initialization

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody)
                switch(hit.rigidbody.gameObject.tag)
                {
                    case "Monster":
                        var monster = hit.rigidbody.gameObject.GetComponent<BaseMonster>();
                        setText("Monster", ((int)monster.CurrentHealth).ToString());
                        break;
                    case "Building":
                        var building = hit.rigidbody.gameObject.GetComponent<BaseBuilding>();
                        setText("BaseBuilding", ((int)building.CurrentHealth).ToString());
                        break;
                    default:
                        setText();
                        break;
                }
            else
               setText();
        }
    }

    void setText(string name=null, string health=null)
    {
        var text = this.GetComponent<Text>() as Text;
        if (name == null)
        {
            if (startDelete)
            {
                if (Time.time - startTime > deleteTime)
                {
                    startDelete = false;
                    text.text = "";
                }
            }
            else
            {
                startDelete = true;
                startTime = Time.time;
            }
        }
        else
        {
            startDelete = false;
            text.text = name + ": " + health + " HP";
        }
    }
}
