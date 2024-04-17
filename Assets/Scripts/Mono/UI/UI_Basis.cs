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
        #region UI��ť�¼���Ϣ
        /// <summary>
        /// ��ʼ��Ϸ��ť
        /// </summary>
        internal Action UIEvent_StartGame;
        /// <summary>
        /// ���������ؼ�  Slider
        /// </summary>
        internal Action<float> UIEvent_Volume;
        /// <summary>
        /// �������ֿ���  Toggle
        /// </summary>
        internal Action<bool> UIEvent_BGM;
        /// <summary>
        /// ������Ϸ��ť
        /// </summary>
        internal Action UIEvent_ReturnGame;
        /// <summary>
        /// ��ȡ���ﰴť
        /// </summary>
        internal Action UIEvent_Receive;
        /// <summary>
        /// ��һ�ذ�ť
        /// </summary>
        internal Action UIEvent_NextLevel;
        /// <summary>
        /// ����ť
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
