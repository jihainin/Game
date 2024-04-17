using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MrJi
{
    public interface IGame
    {
        int Check { get; }

        bool IsCreateGood { set; get; }

        /// <summary>
        /// 生成good
        /// </summary>
        void CreateGood();
        /// <summary>
        /// 停止good
        /// </summary>
        void StopGood();

        /// <summary>
        /// 得分
        /// </summary>
        /// <param name="m_GoodInfo"></param>
        void Score(GoodInfo m_GoodInfo);
        /// <summary>
        /// 扣分
        /// </summary>
        /// <param name="m_Deduct"></param>
        void Deduct(GoodInfo m_GoodInfo);
    }
}
