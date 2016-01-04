using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour {

    public GameObject Bullet = null;

    private List<GameObject> bullets;
    // Use this for initialization
    void Start () {
        bullets = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var point = hit.point;
                point.y = transform.position.y;

                Vector3 direction = (point - transform.position).normalized;
                var new_bullet = Instantiate(Bullet, transform.position + direction * 2, Bullet.transform.rotation) as GameObject;
                var comp = new_bullet.GetComponent("Bullet") as Bullet;
                comp.Direction = (point - comp.transform.position).normalized;
                comp.LifeTime = Random.Range(1, 10);
                comp.parent = this.gameObject.GetComponent("Hero") as Hero;
                bullets.Add(new_bullet);
            }
        }
    }
}