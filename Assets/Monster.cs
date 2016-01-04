using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public GameObject Target;
    public float Speed;
    public bool isDestr = false;

    public int MaxHealth = 100;
    private int CurrHealth;

    public int Damage = 10;
    public float LastDamage = 0;
    public float AttackSpeed = 1;

	// Use this for initialization
	void Start () {
        CurrHealth = MaxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (Target)
        {
            var move_target = Target.transform.position - transform.position;
            move_target.y = 0;
            move_target = move_target.normalized * Speed * Time.fixedDeltaTime;
            transform.position += move_target;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject && collision.gameObject.tag == "Bullet" && isDestr)
        {
            var bullet = collision.gameObject.GetComponent("Bullet") as Bullet;
            if (!bullet.isCalc)
            {
                bullet.isCalc = true;
                CurrHealth -= bullet.Damage;
                Debug.Log(CurrHealth);
                if (CurrHealth <= 0)
                {
                    bullet.parent.Score++;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
