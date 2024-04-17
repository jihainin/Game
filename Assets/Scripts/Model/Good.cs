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
        /// 管卡ID
        /// </summary>
        public int check;
        /// <summary>
        /// 道具
        /// </summary>
        public GoodInfo[] goods;
        /// <summary>
        /// 本关卡生成间隔  越小  生成的越快
        /// </summary>
        public float createTime;
    }


    public class GoodInfo
    {
        [Preserve]
        public GoodInfo() { }
        /// <summary>
        /// 道具ID
        /// </summary>
        public int id;
        /// <summary>
        /// 道具名称
        /// </summary>
        public string name;

        public string url;
        /// <summary>
        /// 被接到特效名称
        /// </summary>
        public string specialEfficacy;
        /// <summary>
        /// 被接到音效
        /// </summary>
        public string audio;
        /// <summary>
        /// 降落速度
        /// </summary>
        public float speed;
        /// <summary>
        /// 接到加分
        /// </summary>
        public int score;
        /// <summary>
        /// 未接到加分
        /// </summary>
        public int deduct;
    }
}
