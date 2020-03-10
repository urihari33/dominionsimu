using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

namespace ConsoleApp1.CardInfos
{
    /// <summary>
    /// 村
    /// </summary>
    /// <remarks>
    /// +2 アクション
    /// +1 ドロー
    /// </remarks>
    public class Village : ICardInfo, IActionCard
    {
        public int Priority { get; set; }

        public string Name => "村";

        public CardTypeAttr CardType => CardTypeAttr.Action;

        public void DoAction(PlayerStatus ps)
        {
            ps.Action += 2;

            for (int j = 0; j < 1; j++)
            {
                var tmpCard = ps.Deck.FirstOrDefault();
                if (tmpCard == null)
                {
                    break;
                }
                ps.Deck.Remove(tmpCard);
                ps.Hands.Add(tmpCard);
            }
        }
    }
}