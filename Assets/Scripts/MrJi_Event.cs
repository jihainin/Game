using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MrJi
{
    public class MrJi_Event
    {
        /// <summary>
        /// 重置分数    关卡
        /// </summary>
        public static System.Action<int> ResetUIGrade;
        /// <summary>
        /// 分数事件  加减   item1   关卡      item2   分数
        /// </summary>
        public static System.Action<int,int> Action_ReviseGrade;
        /// <summary>
        /// 通知UI显示分数
        /// </summary>
        public static System.Action<string> Action_UIShowGrade;
        /// <summary>
        /// 生成Good
        /// </summary>
        public static System.Action<GoodInfo, Vector2> Active_CreateGood;
        /// <summary>
        /// 游戏状态   暂停  开始       true是暂停    false 没有暂停
        /// </summary>
        public static System.Action<bool> Action_GameState;
        /// <summary>
        /// 获得道具
        /// </summary>
        public static System.Action<GoodInfo> GainGood;

    }
}