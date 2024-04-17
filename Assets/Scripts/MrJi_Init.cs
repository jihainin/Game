
using MrJi.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MrJi
{
    public class MrJi_Init
    {
        static View_Good viewGood = null;
        internal static View_Good m_ViewGood { get => viewGood.IsNull() ? viewGood = new View_Good() : viewGood; }


        static Equipment equipment = null;
        internal static Equipment m_Equipment { get => equipment.IsNull() ? equipment = new Equipment() : equipment; }


        static View_Cache viewCache = null;
        internal static View_Cache m_ViewCache { get => viewCache.IsNull() ? viewCache = new View_Cache() : viewCache; }


    }
}
