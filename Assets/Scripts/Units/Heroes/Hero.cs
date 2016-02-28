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
                
                RotateTo(Input.mousePosition);
                MoveTo(transform.position + direction.normalized);
                animator.SetBool("Run", direction != Vector3.zero);

                if (Weapon)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
                    {
                        Weapon.Attack(Input.mousePosition);
                        animator.SetTrigger("Attack");
                    }
                }
            }
        }

        public override void MoveTo(Vector3 target)
        {
            if (rigidbody)
                rigidbody.MovePosition(Vector3.MoveTowards(transform.position, target, Movement.CurrentSpeed * Time.fixedDeltaTime));
        }

        public void RotateTo(Vector3 target)
        {
            var ray = UnityEngine.Camera.main.ScreenPointToRay(target);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var rotation = (hit.point - transform.position).normalized;
                if (!rotation.Equals(Vector3.zero))
                {
                    var q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.fixedDeltaTime * 5);
                    q.x = 0;
                    q.z = 0;
                    transform.rotation = q;
                }
            }

            
        }
    }
}

