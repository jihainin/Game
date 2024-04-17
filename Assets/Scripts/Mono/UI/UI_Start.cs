
using MrJi.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MrJi
{
    /// <summary>
    /// 开始游戏界面
    /// </summary>
    public class UI_Start : UI_Basis
    {

        Button startClick = null;
        Button m_StartClick { get => startClick.IsNull() ? startClick = this.transform.Find("Back/StartClick").GetComponent<Button>() : startClick; }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_StartClick.onClick.AddListener(() => UIEvent_StartGame?.Invoke());
        }

        public override void Dispose()
        {
            m_StartClick?.onClick.RemoveAllListeners();

            base.Dispose();
        }
    }
}