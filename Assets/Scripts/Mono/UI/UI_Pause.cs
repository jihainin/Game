
using MrJi.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MrJi
{
    /// <summary>
    /// ”Œœ∑‘›Õ£ΩÁ√Ê
    /// </summary>
    public class UI_Pause : UI_Basis
    {
        Slider slider = null;
        Slider m_VolumeSlider { get => slider.IsNull() ? slider = this.transform.Find("Back/VolumeSlider").GetComponent<Slider>() : slider; }


        Toggle bgm = null;

        Toggle m_BGM { get => bgm.IsNull() ? bgm = this.transform.Find("Back/BGM").GetComponent<Toggle>() : bgm; }


        Button retureGameClick = null;

        Button m_ReturnGameClick { get => retureGameClick.IsNull() ? retureGameClick = this.transform.Find("Back/ReturnGameClick").GetComponent<Button>() : retureGameClick; }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_VolumeSlider.onValueChanged.AddListener((value)=> UIEvent_Volume?.Invoke(value));
            m_BGM.onValueChanged.AddListener((ison)=>UIEvent_BGM?.Invoke(ison));
            m_ReturnGameClick.onClick.AddListener(()=>UIEvent_ReturnGame?.Invoke());

            m_BGM.isOn = MrJi_Init.m_ViewCache.m_Cache.BGMIson;
        }


        public override void Dispose()
        {
            m_VolumeSlider?.onValueChanged.RemoveAllListeners();
            m_BGM?.onValueChanged.RemoveAllListeners();
            m_ReturnGameClick?.onClick.RemoveAllListeners();
            base.Dispose();
        }
    }
}
