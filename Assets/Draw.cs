using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ConsoleApp1.CardInfos;
using ConsoleApp1.Params;
using ConsoleApp1;

namespace ConsoleApp1.CardEffects
{
    class Draw
    {
        public PlayerStatus ps;
        public Draw(PlayerStatus ps)//コンストラクタを
        {
            var tmpCard = ps.Deck.FirstOrDefault(); /
            if(tmpCard != null)
            {
                ps.Deck.Remove(tmpCard);
                ps.Hands.Add(tmpCard);
            }
            
        }
    }
    
        
    

}