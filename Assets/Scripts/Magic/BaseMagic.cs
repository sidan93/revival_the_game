using UnityEngine;
using Assets.Scripts.Factory;

namespace Assets.Scripts.Magic
{
    class BaseMagic : BaseObject
    {
        public static string MagicName { get { return _magicName; } }
        protected static string _magicName;
        public static readonly string MagicTag = "Magic";
        public static readonly string BaseMagicTag = "BaseMagic";

        public float CurrentDamage;
        protected float Damage { private set; get; }

        protected override void Start()
        {
            Damage = CurrentDamage;
        }

        public static BaseMagic GetInstantiate(Vector3 position)
        {
            var newMagic = MagicFactory.GetInstantiate(MagicName);
            newMagic.transform.position = position;
            newMagic.tag = MagicTag;
            return newMagic;
        }
    }
}
