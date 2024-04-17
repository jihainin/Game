
using MrJi.Event;
using MrJi.Model;
using MrJi.UnityManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MrJi
{
    [DefaultExecutionOrder(20)]
    public class MrJi_Game : MonoBehaviour, IDisposable
    {
        internal static MrJi_Game Instance;

        public Canvas m_Canvas;

        Dictionary<int, IGame> GameManager = new Dictionary<int, IGame>() {

        { 1,new Game_FirstLevel()},
        { 2,new Game_TheSecondHurdle()},
        { 3,new Game_ThridLevel()}
        };

        public IGame PresentGame { set; get; } = null;


        private void Awake()
        {
            Instance = this;

            new View_Grade();
        }


        private async void Start()
        {
            MrJi_Event.Action_GameState += GameState;
            AudioManager.Instance.PlayBGM("BGM", MrJi_Init.m_ViewCache.m_Cache.BGMIson ? 0: MrJi_Init.m_ViewCache.m_Cache.BGMVolume, Floder: "Audio");
            CreateUI<UI_Start>(m_Canvas.transform);
        }

        private void GameState(bool obj)
        {
            if (!obj) return;

            CreateUI<UI_Pause>(this.m_Canvas.transform);
        }

        /// <summary>
        /// 启动关卡
        /// </summary>
        /// <param name="CheckPointId">关卡ID</param>
        public async void StartCheckPoint(int CheckPointId)
        {
            if (!GameManager.ContainsKey(CheckPointId)) return;

            MrJi_Event.ResetUIGrade?.Invoke(CheckPointId);

            this.PresentGame = GameManager[CheckPointId];

            this.PresentGame.CreateGood();
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
            MrJi_Event.Action_GameState -= GameState;
            PresentGame?.StopGood();
        }



        #region UI Screen



        public async void CreateUI<T>(Transform Parent) where T : class
        {
            UI_Basis m_UIBasis = (await GameObjectPool.Instance.Get_Game<T>(Parent, new Data_Location().Default, "UI")) as UI_Basis;
            ///UI_Start
            m_UIBasis.UIEvent_StartGame = () => Function_StartGame(m_UIBasis);
            ///UI_Pause
            m_UIBasis.UIEvent_Volume = (volume) => Function_Volume(m_UIBasis, volume);
            m_UIBasis.UIEvent_BGM = (ison) => Function_BGM(m_UIBasis, ison);
            m_UIBasis.UIEvent_ReturnGame = () => Function_ReturnGame(m_UIBasis);
            ///UI_Success
            m_UIBasis.UIEvent_Receive = () => Function_Receive(m_UIBasis);
            m_UIBasis.UIEvent_NextLevel = () => Function_NextLevel(m_UIBasis);
            ///UI_Fail
            m_UIBasis.UIEvent_Share = () => Function_Share(m_UIBasis);
        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        /// <param name="m_UIBasis"></param>
        private async void Function_StartGame(UI_Basis m_UIBasis)
        {
            m_UIBasis.Recycle();
            await Task.Yield();
            this.StartCheckPoint(1);
        }

        /// <summary>
        /// 调节音量
        /// </summary>
        /// <param name="volume"></param>
        private void Function_Volume(UI_Basis m_UIBasis, float volume)
        {
            Debug.Log(volume);
        }

        /// <summary>
        /// 背景音乐
        /// </summary>
        /// <param name="m_UIBasis"></param>
        /// <param name="ison"></param>
        private void Function_BGM(UI_Basis m_UIBasis, bool ison)
        {
            MrJi_Init.m_ViewCache.Setting_BGMIson(ison);
            EventManager.Update_AudioSourceVolume(ison ? 0 : MrJi_Init.m_ViewCache.m_Cache.BGMVolume, AudioSourceType.BackGroundMusic);
        }
        /// <summary>
        /// 返回游戏
        /// </summary>
        /// <param name="m_UIBasis"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Function_ReturnGame(UI_Basis m_UIBasis)
        {
            m_UIBasis.Recycle();
            MrJi_UI.Instance.PauseToPlay(false);
        }

        /// <summary>
        /// 领取礼品
        /// </summary>
        /// <param name="m_UIBasis"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Function_Receive(UI_Basis m_UIBasis)
        {
            Debug.Log("领取礼品");
        }
        /// <summary>
        /// 下一关
        /// </summary>
        /// <param name="m_UIBasis"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Function_NextLevel(UI_Basis m_UIBasis)
        {
            Debug.Log("下一关");
        }

        /// <summary>
        /// 分享
        /// </summary>
        /// <param name="m_UIBasis"></param>
        private void Function_Share(UI_Basis m_UIBasis)
        {
            Debug.Log("分享");
        }
        #endregion

    }
}
