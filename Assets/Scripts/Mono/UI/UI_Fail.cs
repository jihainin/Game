using MrJi.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MrJi
{
    /// <summary>
    /// 通关失败界面
    /// </summary>
    public class UI_Fail : UI_Basis
    {

        Button shareClick = null;

        Button m_ShareClick { get => shareClick.IsNull() ? shareClick = this.transform.Find("Back/ShareClick").GetComponent<Button>() : shareClick; }



        protected override void OnEnable()
        {
            base.OnEnable();
            m_ShareClick.onClick.AddListener(()=> UIEvent_Share?.Invoke());
        }


        public override void Dispose()
        {
            m_ShareClick?.onClick.RemoveAllListeners();
            base.Dispose();
        }


    }

}
