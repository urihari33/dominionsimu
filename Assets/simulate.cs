using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simulate : MonoBehaviour
{

    //カードの構造
    public class Card
    {
        public int action;
        public int buy;
        public int coin;
        public int draw;
        public bool isAction;
        public bool isCoin;
        public bool isVictory;
        public int priority;

        public Card(bool isAction,bool isCoin,bool isVictory,int action,int buy,int coin,int draw,int priority)
        {
            this.isAction = isAction;
            this.isCoin = isCoin;
            this.isVictory = isVictory;
            this.action = action;
            this.buy = buy;
            this.coin = coin;
            this.draw = draw;
            this.priority = priority;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
