using UnityEngine;
using Assets.Scripts.Factory;
using Assets.Scripts.Utilities.Timers;

namespace Assets.Scripts.Magic
{
    class BaseMagic : BaseObject
    {
        public static string MagicName { get { return _magicName; } }
        protected static string _magicName;
        public static readonly string MagicTag = "Magic";
        public static readonly string BaseMagicTag = "BaseMagic";
        public MagicList MagicType { protected set; get; }

        public float CurrentDamage;
        public float Damage { private set; get; }

        public float ManaCount;
        public float Mana { private set; get; }

        public float LifeTime;
        protected LifeTimer lifeTime;

        protected override void Start()
        {
            base.Start();

            Damage = CurrentDamage;
            Mana = ManaCount;
            lifeTime = new LifeTimer(LifeTime);
        }

        protected override void Update()
        {
            base.Update();
            if (!lifeTime.isAlive)
                Destroy(this.gameObject);
        }

        public BaseMagic GetInstantiate(Vector3 position)
        {
            var newMagic = MagicFactory.GetInstantiate(MagicName);
            if (newMagic == null)
                return newMagic;

            newMagic.transform.position = position;
            newMagic.tag = MagicTag;
            newMagic.SetMagicData(this);
            return newMagic;
        }

        protected void SetMagicData(BaseMagic paramMagic)
        {
            CurrentDamage = paramMagic.Damage;
            ManaCount = paramMagic.Mana;
            LifeTime = paramMagic.LifeTime;
        }
    }
}
