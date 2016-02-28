using UnityEngine;

namespace Assets.Scripts.Utilities
{
    class LifeTimer
    {
        protected float LifeTime { private set; get; }
        public float CreateTime { private set; get; }

        public bool isAlive { get { return CreateTime == 0 || Time.time - CreateTime < LifeTime; } }

        public LifeTimer(float LifeTime = 0)
        {
            this.LifeTime = LifeTime;
            CreateTime = Time.time;
        }

        public void Kill()
        {
            LifeTime = -1;
        }
    }
}
