
using MrJi.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MrJi
{
    /// <summary>
    /// 成功通关界面
    /// </summary>
    public class UI_Success : UI_Basis
    {
        Button receiveClick = null;

        Button m_ReceiveClick { get => receiveClick.IsNull() ? receiveClick = this.transform.Find("Back/ReceiveClick").GetComponent<Button>() : receiveClick; }

        Button nextLevelClick = null;

        Button m_NextLevelClick { get => nextLevelClick.IsNull() ? nextLevelClick = this.transform.Find("Back/NextLevelClick").GetComponent<Button>() : nextLevelClick; }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_ReceiveClick.onClick.AddListener(()=> UIEvent_Receive?.Invoke());
            m_NextLevelClick.onClick.AddListener(() => UIEvent_NextLevel?.Invoke());
        }

        public override void Dispose()
        {
            m_ReceiveClick.onClick.RemoveAllListeners();
            m_NextLevelClick.onClick.RemoveAllListeners();
            base.Dispose();
        }

    }

}
