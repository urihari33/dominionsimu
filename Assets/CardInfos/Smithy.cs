using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ConsoleApp1.CardInfos
{
    [Expansion("basic")]
    public class Smithy : ICardInfo, IActionCard
    {
        public string Name => "鍛冶屋";

        public CardTypeAttr CardType => CardTypeAttr.Action;

        public int Priority { get; set; }

        public void DoAction(PlayerStatus ps)
        {
            for (int j = 0; j < 3; j++)
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