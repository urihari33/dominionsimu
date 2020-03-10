using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleApp1.CardInfos
{
    /// <summary>
    /// 銀貨
    /// </summary>
    public class Silver : ICardInfo, ITresureCard
    {
        public string Name => "銀貨";

        public CardTypeAttr CardType => CardTypeAttr.Treasure;

        public void DoTreasure(PlayerStatus ps)
        {
            ps.Coin += 2;
        }
    }
}
