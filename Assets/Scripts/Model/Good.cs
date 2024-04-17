using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace MrJi
{
    public class Good 
    {
        [Preserve]
        public Good() { }
        /// <summary>
        /// �ܿ�ID
        /// </summary>
        public int check;
        /// <summary>
        /// ����
        /// </summary>
        public GoodInfo[] goods;
        /// <summary>
        /// ���ؿ����ɼ��  ԽС  ���ɵ�Խ��
        /// </summary>
        public float createTime;
    }


    public class GoodInfo
    {
        [Preserve]
        public GoodInfo() { }
        /// <summary>
        /// ����ID
        /// </summary>
        public int id;
        /// <summary>
        /// ��������
        /// </summary>
        public string name;

        public string url;
        /// <summary>
        /// ���ӵ���Ч����
        /// </summary>
        public string specialEfficacy;
        /// <summary>
        /// ���ӵ���Ч
        /// </summary>
        public string audio;
        /// <summary>
        /// �����ٶ�
        /// </summary>
        public float speed;
        /// <summary>
        /// �ӵ��ӷ�
        /// </summary>
        public int score;
        /// <summary>
        /// δ�ӵ��ӷ�
        /// </summary>
        public int deduct;
    }
}
