
using MrJi.Example;
using MrJi.UnityManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


namespace MrJi
{
    /// <summary>
    /// 特效处理类
    /// </summary>
    public class GameSpecialEfficacy : MonoBehaviour,IDisposable
    {

        Animator animator = null;
        Animator m_Animator { get => animator.IsNull() ? animator = this.GetComponent<Animator>() : animator; }

        AnimationClip clip = null;
        AnimationClip m_AnimationClip { get => clip.IsNull() ? clip = this.m_Animator.runtimeAnimatorController.animationClips.First() : clip; }


        private  async void OnEnable()
        {
            StartCoroutine("PlayAnimator");
        }

        IEnumerator PlayAnimator()
        {
            this.m_Animator.speed = 1;
            yield return new WaitForEndOfFrame();
            this.m_Animator.Play(m_AnimationClip.name);
            yield return new WaitForSeconds(this.m_AnimationClip.length);
            Recycle();
        }

        /// <summary>
        /// 销毁
        /// </summary>
        void Recycle()
        {
            StopCoroutine("PlayAnimator");
            GameObjectPool.Instance.Recycle(this.gameObject);
        }

        public void Dispose()
        { 
            this.m_Animator.speed = 0;
            //this.m_Animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0);
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void OnDisable()
        {
            Dispose();
        }
    }
}
