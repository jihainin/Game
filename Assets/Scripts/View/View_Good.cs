
using MrJi.Example;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Scripting;

namespace MrJi
{
    public class View_Good : System.IDisposable
    {

        Good[] m_Good { set; get; }

        Dictionary<int, Good> m_GoodLists = null;

        [Preserve]
        public View_Good()
        {
            m_Good = ResourcesManager.Instance.Good.bytes.GetObject<Good[]>();
        }


        public Good Get_Good(int CheckPoint)
        {
            if (this.m_GoodLists.IsNull()) this.m_GoodLists = new Dictionary<int, Good>();

            if (!this.m_GoodLists.ContainsKey(CheckPoint))
                this.m_GoodLists[CheckPoint] = m_Good.Where(value => value.check == CheckPoint).FirstOrDefault();

            return this.m_GoodLists[CheckPoint];
        }


        public GoodInfo Get_GoodInfo(int CheckPoint)
        {
            Good good = Get_Good(CheckPoint);

            if (good.IsNull()) return null;

            return good.goods[Random.Range(0, good.goods.Length)];
        }

        /// <summary>
        /// 是否是最后一关
        /// </summary>
        /// <param name="good">当前关</param>
        /// <returns></returns>
        public bool IsLastCheck(Good good)
        {
            return Get_Good(good.check + 1).IsNull();
        }
        /// <summary>
        /// 是否是最后一关
        /// </summary>
        /// <param name="CheckId">当前关Id</param>
        /// <returns></returns>
        public bool IsLastCheck(int CheckId)
        {
            return Get_Good(CheckId + 1).IsNull();
        }

        public void Dispose()
        {
            this.m_GoodLists?.Clear();
            this.m_GoodLists = null;
        }
    }
}
