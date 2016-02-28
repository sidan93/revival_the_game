using UnityEngine;
using Assets.Scripts.Units.Heroes;

namespace Assets.Scripts.Camera
{
    class Camera : BaseObject
    {
        public Hero Target;
        public float CameraDistance = 30;
        

        protected override void Update()
        {
            base.Update();

            if (Input.mouseScrollDelta.y != 0)
                if (CameraDistance - Input.mouseScrollDelta.y > 5 && CameraDistance - Input.mouseScrollDelta.y < 100)
                    CameraDistance -= Input.mouseScrollDelta.y;

            if (Target)
                transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + CameraDistance, Target.transform.position.z);
        }
    }
}
