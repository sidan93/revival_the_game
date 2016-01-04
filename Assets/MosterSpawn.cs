using UnityEngine;
using System.Collections.Generic;

public class MosterSpawn : MonoBehaviour {

    public GameObject Monster = null;
    public GameObject Target = null;
    public int SpawnLimit = 1000;
    public bool isSpawn = true;

    private List<GameObject> monsters;
    private float startTime;


	// Use this for initialization
	void Start () {
        monsters = new List<GameObject>();
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > 1 && monsters.Count < SpawnLimit && isSpawn)
        {
            var new_monster = Instantiate(Monster, Monster.transform.position + new Vector3(0, 50, 0), Monster.transform.rotation) as GameObject;
            var monster = new_monster.GetComponent("Monster") as Monster;
            monster.Target = Target;
            monster.isDestr = true;
            monster.MaxHealth = Random.Range(50, 200);
            monsters.Add(new_monster);
            startTime = Time.time;
        }
	}
}
