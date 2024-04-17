
using MrJi.Model;
using MrJi.UnityManager;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Scripting;

namespace MrJi
{
    /// <summary>
    /// ตฺถþนุ
    /// </summary>
    public class Game_TheSecondHurdle : IGame
    {
        public int Check { get => 2; }
        public bool IsCreateGood { set; get; }

        [Preserve]
        public Game_TheSecondHurdle()
        {
            IsCreateGood = false;
        }
        public void CreateGood()
        {
            IsCreateGood = true;
            MrJi_Game.Instance.StartCoroutine(ICreateGood());
        }
        IEnumerator ICreateGood()
        {
            while (IsCreateGood)
            {
                GoodInfo m_GoodInfo = MrJi_Init.m_ViewGood.Get_GoodInfo(Check);
                GameObjectPool.Instance.Get_Game(m_GoodInfo.name, MrJi_Game.Instance.m_Canvas.transform, new Data_Location(Vector3.zero, Vector3.zero, Vector3.zero, Quaternion.Euler(Vector3.zero)), $"Good", (game) => InitGameGood(game, m_GoodInfo));
                yield return new WaitForSeconds(MrJi_Init.m_ViewGood.Get_Good(this.Check).createTime);
            }
        }

        void InitGameGood(GameObject game, GoodInfo m_GoodInfo)
        {
            GameGood m_GameGood = game.GetComponent<GameGood>();
            m_GameGood.Show(m_GoodInfo);
        }
        public void StopGood()
        {
            IsCreateGood = false;
        }
        public void Deduct(GoodInfo m_GoodInfo)
        {
            MrJi_Event.Action_ReviseGrade?.Invoke(Check, m_GoodInfo.deduct);
        }

        public void Score(GoodInfo m_GoodInfo)
        {
            MrJi_Event.Action_ReviseGrade?.Invoke(Check, m_GoodInfo.score);
        }
    }
}
