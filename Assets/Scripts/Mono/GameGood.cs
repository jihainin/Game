
using MrJi.Event;
using MrJi.Example;
using MrJi.UnityManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MrJi
{
    public class GameGood : MonoBehaviour, IDisposable
    {

        RawImage rawImage = null;
        public RawImage m_RawImage { get => rawImage.IsNull() ? rawImage = this.GetComponent<RawImage>() : rawImage; }


        RectTransform rectTransform = null;
        public RectTransform m_TectTransform { get => rectTransform.IsNull() ? rectTransform = m_RawImage.GetComponent<RectTransform>() : rectTransform; }



        GoodInfo goodInfo = null;


        public GameGood Show(GoodInfo m_GoodInfo)
        {
            this.goodInfo = m_GoodInfo;

            Vector2 m_Vector2 = new Vector2();
            float Value = (MrJi_Init.m_Equipment.Width - m_TectTransform.sizeDelta.x) / 2;
            m_Vector2.x = UnityEngine.Random.Range(-Value, Value);
            m_Vector2.y = MrJi_Init.m_Equipment.Height / 2 + 50f;
            this.transform.localPosition = m_Vector2;


            this.transform.localScale = Vector3.one;
            return this;
        }

        private void FixedUpdate()
        {
            if (this.goodInfo.IsNull()) return;
            float value = Time.deltaTime * this.goodInfo.speed * 100;
            float NextY = this.transform.localPosition.y - value;
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, NextY);

            float Distance = Vector3.Distance(this.transform.localPosition, GamePlayer.Instance.Get_LocalPosition);

            if (NextY < -(MrJi_Init.m_Equipment.Height / 2 + 800))
            {
                MrJi_Game.Instance.PresentGame?.Deduct(goodInfo);
                GameObjectPool.Instance.Recycle(this.gameObject);
            }

            
            if (Distance <= 120)
            {
                MrJi_Game.Instance.PresentGame?.Score(this.goodInfo);
                AudioManager.Instance.Play(this.goodInfo.audio, m_AudioSourceType: AudioSourceType.SoundEffect, Volume: 1f, Floder: "Audio");
                MrJi_Event.GainGood?.Invoke(this.goodInfo);
                GameObjectPool.Instance.Recycle(this.gameObject);
            }
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void OnDisable()
        {
            Dispose();
        }

        public void Dispose()
        {
        }
    }
}
