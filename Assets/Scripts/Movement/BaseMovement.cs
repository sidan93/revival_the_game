using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Movement
{
    class BaseMovement
    {
        protected float MaxSpeed { private set; get; }
        public float CurrentSpeed { private set; get; }
            
        public BaseMovement(float MaxSpeed)
        {
            this.MaxSpeed = MaxSpeed;
            CurrentSpeed = MaxSpeed;
        }
    }
}
