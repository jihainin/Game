using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using MrJi.Example;
using MrJi.Model;
using MrJi.UnityManager;
namespace MrJi
{
    public class UI_Basis : MonoBehaviour,IDisposable
    {
        #region UI按钮事件消息
        /// <summary>
        /// 开始游戏按钮
        /// </summary>
        internal Action UIEvent_StartGame;
        /// <summary>
        /// 调节音量控件  Slider
        /// </summary>
        internal Action<float> UIEvent_Volume;
        /// <summary>
        /// 背景音乐开关  Toggle
        /// </summary>
        internal Action<bool> UIEvent_BGM;
        /// <summary>
        /// 返回游戏按钮
        /// </summary>
        internal Action UIEvent_ReturnGame;
        /// <summary>
        /// 领取礼物按钮
        /// </summary>
        internal Action UIEvent_Receive;
        /// <summary>
        /// 下一关按钮
        /// </summary>
        internal Action UIEvent_NextLevel;
        /// <summary>
        /// 分享按钮
        /// </summary>
        internal Action UIEvent_Share;
        #endregion



        protected virtual async void OnEnable()
        {
            await this.transform.UGUICenterManager(null,new Data_Edge());
        }

        protected virtual async void Update()
        {
            
        }

        internal async void Recycle()
        {
            GameObjectPool.Instance.Recycle(this.gameObject);
            await Task.Yield();
        }

        void OnDestroy()
        {
            Dispose();
        }

        void OnDisable()
        {
            Dispose();
        }

        public virtual void Dispose()
        {

        }
    }
}
