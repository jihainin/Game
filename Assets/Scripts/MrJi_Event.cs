using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MrJi
{
    public class MrJi_Event
    {
        /// <summary>
        /// ���÷���    �ؿ�
        /// </summary>
        public static System.Action<int> ResetUIGrade;
        /// <summary>
        /// �����¼�  �Ӽ�   item1   �ؿ�      item2   ����
        /// </summary>
        public static System.Action<int,int> Action_ReviseGrade;
        /// <summary>
        /// ֪ͨUI��ʾ����
        /// </summary>
        public static System.Action<string> Action_UIShowGrade;
        /// <summary>
        /// ����Good
        /// </summary>
        public static System.Action<GoodInfo, Vector2> Active_CreateGood;
        /// <summary>
        /// ��Ϸ״̬   ��ͣ  ��ʼ       true����ͣ    false û����ͣ
        /// </summary>
        public static System.Action<bool> Action_GameState;
        /// <summary>
        /// ��õ���
        /// </summary>
        public static System.Action<GoodInfo> GainGood;

    }
}