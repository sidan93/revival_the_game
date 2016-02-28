﻿using UnityEngine;
using System.Collections.Generic;
using Assets.Units;
using Assets.Utilities;
using Assets.Weapons;

namespace Assets.Scripts
{
    class BaseObject : MonoBehaviour
    {
        private static int __idObject;
        protected int IdObject { private set; get; }
        protected new Rigidbody rigidbody;

        protected virtual void Start()
        {
            rigidbody = this.GetComponent<Rigidbody>();
            IdObject = __idObject++;
        }

        protected virtual void Update()
        {

        }
    }
}