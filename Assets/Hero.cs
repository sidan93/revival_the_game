using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public int Score = 0;
    public int MaxHealth = 100;
    private int CurrentHealth;
    public float Speed = 10;

    public bool isLife { private set; get; }

    // Use this for initialization
    void Start () {
        CurrentHealth = MaxHealth;
        isLife = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if (isLife)
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position = this.transform.position + Vector3.left * Speed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position = this.transform.position + Vector3.right * Speed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position = this.transform.position + Vector3.forward * Speed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position = this.transform.position + Vector3.back * Speed * Time.fixedDeltaTime;
            }
        }
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject && collision.gameObject.tag == "Monster")
        {
            var monster = collision.gameObject.GetComponent("Monster") as Monster;
            if (Time.time - monster.LastDamage > monster.AttackSpeed)
            {
                monster.LastDamage = Time.time;
                CurrentHealth -= monster.Damage;
                if (CurrentHealth <= 0)
                    isLife = false;
            }
        }
    }
}
