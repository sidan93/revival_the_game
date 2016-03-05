using UnityEngine;

namespace Assets.Scripts.Magic.Explosion
{
    class BaseExplosion : BaseMagic
    {
        protected override void Start()
        {
            base.Start();

            _magicName = "BaseExplosion";
            MagicType = MagicList.Explosion;
        }
    }
}
