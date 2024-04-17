using MrJi.Example;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace MrJi
{
    [DefaultExecutionOrder(0)]
    /// <summary>
    /// ΩÁ√Ê
    /// </summary>
    public class MrJi_UI : MonoBehaviour, IDisposable
    {
        public static MrJi_UI Instance;

        Text grade = null;
        Text M_Grade { get => grade.IsNull() ? grade = this.transform.Find("Grade/Grade").GetComponent<Text>() : grade; }

        Toggle playOrPause = null;

        Toggle m_PlayOrPause { get => playOrPause.IsNull() ? this.transform.Find("Play Pause").GetComponent<Toggle>() : playOrPause; }


        private void Start()
        {
            Instance = this;
            MrJi_Event.Action_UIShowGrade += UIShowGrade;
            MrJi_Event.Action_GameState += UpdateGameState;
            m_PlayOrPause.onValueChanged.AddListener(ison => MrJi_Event.Action_GameState?.Invoke(ison));
        }

        public void PauseToPlay(bool state)
        {
            m_PlayOrPause.isOn = state;
        }

        private void UIShowGrade(string Value)
        {
            M_Grade.text = Value;
        }

        private void UpdateGameState(bool state) {

            Time.timeScale = state ? 0 : 1;
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
            MrJi_Event.Action_UIShowGrade -= UIShowGrade;
            MrJi_Event.Action_GameState -= UpdateGameState;
            m_PlayOrPause.onValueChanged.RemoveAllListeners();
        }
    }
}
