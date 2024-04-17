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
        /// ����good
        /// </summary>
        void CreateGood();
        /// <summary>
        /// ֹͣgood
        /// </summary>
        void StopGood();

        /// <summary>
        /// �÷�
        /// </summary>
        /// <param name="m_GoodInfo"></param>
        void Score(GoodInfo m_GoodInfo);
        /// <summary>
        /// �۷�
        /// </summary>
        /// <param name="m_Deduct"></param>
        void Deduct(GoodInfo m_GoodInfo);
    }
}
