using UnityEngine;
using Assets.Units;
using Assets.Utilities;

public class Monster : BaseUnit
{
    public GameObject Target;
    public bool isDestr = false;

    public int MaxHealth = 100;

    public int Damage = 10;
    public float AttackSpeed = 1;

	// Use this for initialization
	void Start ()
    {
        health = new Health(MaxHealth);
        attack = new Attack(Damage, AttackSpeed);
    }

    public int getScore()
    {
        return MaxHealth / 100 + 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isAlive)
        {
            if (Target)
            {
                Hero hero = Target.GetComponent("Hero") as Hero;
                hero.Score += getScore();
            }
            Destroy(this.gameObject);
        }

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
        if (collision.gameObject && collision.gameObject.tag == "Hero")
        {
            var hero = collision.gameObject.GetComponent("Hero") as Hero;
            hero.setDamage(attack.MakeAttack());
        }
    }
}
