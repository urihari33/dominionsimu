using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleApp1.CardInfos
{
    /// <summary>
    /// 銅貨
    /// </summary>
    public class Copper : ICardInfo, ITresureCard
    {
        public string Name { get { return "銅貨"; } }

        public CardTypeAttr CardType { get { return CardTypeAttr.Treasure; } }

        public int Priority => 0;

        public void DoTreasure(PlayerStatus ps)
        {
            ps.Coin += 1;
        }
    }
}

