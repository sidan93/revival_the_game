using UnityEngine;
using Assets.Scripts.Weapon;

namespace Assets.Scripts.Units.Heroes
{
    class Hero : BaseUnit
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();

            if (Health.IsAlive)
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

                MoveTo(transform.position + direction.normalized);

                if (Weapon)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
                    {
                        Weapon.Attack(Input.mousePosition);
                    }
                }
            }
        }
    }
}

