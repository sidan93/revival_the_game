using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Magic;
using Assets.Scripts.Magic.Explosion;
using Assets.Scripts.Utilities.Mana;

namespace Assets.Scripts.Utilities.Magic
{
    class MagicBox
    {
        HashSet<MagicList> magicList;
        BaseAliveObject Caster;

        public MagicBox(BaseAliveObject Caster)
        {
            this.magicList = new HashSet<MagicList>();
            this.Caster = Caster;
        }

        public void AddMagic(MagicList magic)
        {
            magicList.Add(magic);
        }
        public void AddMagic(BaseMagic magic)
        {
            magicList.Add(magic.MagicType);
        }

        public BaseMagic Cast(BaseMagic magic, Vector3 position)
        {
            if (magicList.Contains(magic.MagicType))
            {
                if (Caster.CurrentMana >= magic.Mana)
                {
                    Caster.ReduceMana(magic.Mana);
                    return magic.GetInstantiate(position);

                }
            }
            return null;
        }
    }
}
