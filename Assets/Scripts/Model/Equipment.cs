using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace MrJi
{

    /// <summary>
    /// �豸��Ϣ
    /// </summary>

    public class Equipment
    {

        public float Width { set; get; }
        public float Height { set; get; }


        [Preserve]
        public Equipment()
        {
            Width = Screen.width;
            Height = Screen.height;
        }
    }
}