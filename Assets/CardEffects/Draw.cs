using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ConsoleApp1.CardInfos;
using ConsoleApp1.Params;
using ConsoleApp1;


namespace ConsoleApp1
{
    class Draw
    {
        public PlayerStatus ps;
       

        public Draw(PlayerStatus ps)//コンストラクタを
        {
            this.ps = ps;
            var tmpCard = ps.Deck.FirstOrDefault(); //TODO引けなかったときの処理が未実装       
            ps.Deck.Remove(tmpCard);
            ps.Hands.Add(tmpCard);
        }

        
    }
    
        
    

}