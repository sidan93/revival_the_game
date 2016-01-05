using UnityEngine;
using System.Collections.Generic;
using Assets.Units;
using Assets.Utilities;

public class Hero : BaseUnit
{
    public int Score = 0;
    public int MaxHealth = 100;

    public GameObject Bullet = null;
    private List<GameObject> bullets;

    // Use this for initialization
    void Start () {
        bullets = new List<GameObject>();
        Score = 0;
        health = new Health(MaxHealth);
    }
	
	// Update is called once per frame
	void Update () {
	    if (health.isAlive)
        {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
                direction.x--;
            if (Input.GetKey(KeyCode.D))
                direction.x++;
            if (Input.GetKey(KeyCode.W))
                direction.z++;
            if (Input.GetKey(KeyCode.S))
                direction.z--;
            this.transform.position = this.transform.position + direction.normalized * Speed * Time.fixedDeltaTime;

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    var point = hit.point;
                    point.y = transform.position.y;

                    Vector3 direction1 = (point - transform.position).normalized;
                    var new_bullet = Instantiate(Bullet, transform.position + direction1, Bullet.transform.rotation) as GameObject;
                    var comp = new_bullet.GetComponent("Bullet") as Bullet;
                    comp.Direction = (point - comp.transform.position).normalized;
                    comp.LifeTime = Random.Range(1, 10);
                    bullets.Add(new_bullet);
                }
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
    }
}
