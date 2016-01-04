using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Vector3 Direction;
    public float Speed = 20;
    public float LifeTime = 1;
    public int Damage = 50;
    public bool isCalc = false;
    public Hero parent;

    private float CreateTime;

    // Use this for initialization
    void Start () {
        CreateTime = Time.time;
        var rigidbody = this.GetComponent("Rigidbody") as Rigidbody;
        rigidbody.AddForce(Direction * Speed, ForceMode.VelocityChange);
        
    }
	
	// Update is called once per frame
	void Update () {
        //var move_target = Direction * Speed * Time.fixedDeltaTime;
        //transform.position += move_target;

        if (Time.time - CreateTime > LifeTime && LifeTime != 0)
        {
            Destroy(this.gameObject);            
        }
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject && LifeTime != 0)
            LifeTime = -1;
    }
}
