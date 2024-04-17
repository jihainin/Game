
using MrJi.Example;
using MrJi.Model;
using MrJi.UnityManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MrJi
{
    public class GamePlayer : MonoBehaviour, IDragHandler,IDisposable
    {

        public static GamePlayer Instance;

        RawImage rawImage = null;
        public RawImage m_RawImage { get => rawImage.IsNull() ? rawImage = this.GetComponent<RawImage>() : rawImage; }


        RectTransform rectTransform = null;
        public RectTransform m_TectTransform { get => rectTransform.IsNull() ? rectTransform = m_RawImage.GetComponent<RectTransform>() : rectTransform; }

        float width;

        Vector2 m_DefaultPosition = Vector2.zero;

        public Vector2 Get_LocalPosition { get => this.transform.localPosition; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            m_DefaultPosition = this.transform.localPosition;

            MrJi_Event.Action_GameState += UpdateGameState;
            MrJi_Event.GainGood += GainGood;
            width = (MrJi_Init.m_Equipment.Width - m_TectTransform.sizeDelta.x) / 2;

            
        }

        private async void GainGood(GoodInfo info)
        {
             await GameObjectPool.Instance.Get_Game(info.specialEfficacy,this.transform,new Data_Location().Default, "Special efficacy");
        }

        private void UpdateGameState(bool state)
        {
            m_RawImage.raycastTarget = !state;
        }







        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform.parent, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);

            Vector2 vector2 = new Vector2(Mathf.Clamp(localPoint.x, -width, width), m_DefaultPosition.y);
            transform.localPosition = vector2;
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
            MrJi_Event.Action_GameState -= UpdateGameState;
            MrJi_Event.GainGood -= GainGood;
        }
    }
}
