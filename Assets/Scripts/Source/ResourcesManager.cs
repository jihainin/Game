using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Scripting;
using System;
using MrJi.Example;

namespace MrJi
{
    /// <summary>
    /// ◊ ‘¥ø‚
    /// </summary>
    [Preserve]
    public class ResourcesManager : MonoBehaviour
    {
        static ResourcesManager instance = null;

        public static ResourcesManager Instance
        {
            get
            {
                if (instance.IsNull())
                {
                    instance = Resources.Load("ResourcesManager").GetComponent<ResourcesManager>();
                }
                return instance;
            }
        }

        [Header("πÿø®≈‰÷√")] public TextAsset Good;

    }

}
