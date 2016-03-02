using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Magic;


namespace Assets.Scripts.Factory
{
    static class MagicFactory
    {
        static SortedList<string, BaseMagic> magics = new SortedList<string, BaseMagic>();
         
        static MagicFactory()
        {
            var magicObjects = GameObject.FindGameObjectsWithTag(BaseMagic.BaseMagicTag);
            foreach (var magic in magicObjects)
            {
                var baseMagic = magic.GetComponent<BaseMagic>();
                magics.Add(BaseMagic.MagicName, baseMagic);
            }
        }
        public static BaseMagic GetInstantiate(string magicName)
        {
            var savedMagic = magics[magicName];
            if (savedMagic == null)
                return null;
            var newMagic = BaseMagic.Instantiate(savedMagic) as BaseMagic;
            return newMagic;
        }
    }
}
