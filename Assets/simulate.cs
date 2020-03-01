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

        //カード固有の動作をどう持たせるか未検討(倉庫とか岐路とか)
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

    //実際に計算するときに呼ばれる
    public void Onclick()
    {
        Debug.Log("cul start");
        int simuTimes = 1000;//反復回数
        //初期状態に関するパラメタ
        int openhand = 5;
        int opencoin = 0;
        int openaction = 1;
        int openbuy = 1;

        //デッキを作る（まだデータなし）
        List<Card> masterdeck = new List<Card>();
        //ここにデッキの作り方を考える

        //エラー回避用のデッキ枚数参照
        int decksize = masterdeck.Count;

        if (decksize > 0)
        {
            for(int i= 0; i < simuTimes; i++)
            {
                //デッキ、場、手札、捨て札
                List<Card> deck = new List<Card>();
                List<Card> inplay = new List<Card>();
                List<Card> hand = new List<Card>();
                List<Card> dispile = new List<Card>();
                deck = masterdeck;
                draw(hand, deck, dispile, openhand);
                //アクション、購入、金量、
                int tempAction = openaction;
                int tempBuy = openbuy;
                int tempCoin = opencoin;
                //この後優先度順にプレイしていきたいの
            }
        }
        else
        {
            Debug.Log("deck has no card!");
        }
        

        
    }

    //受け取ったデッキをシャッフルする
    void shuffle(List<Card> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Card temp = list[i];
            int randomIndex = UnityEngine.Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;

        }
    }
    //カードをN枚引く
    void draw(List<Card> hand,List<Card> deck,List<Card> dispile,int N)
    {
        for(int i = 0; i < N; i++)
        {
            if (deck.Count == 0)
            {
                deck = dispile;
                shuffle(deck);
            }
            if (deck.Count > 0)
            {
                hand.Add(deck[0]);
                deck.RemoveAt(1);
            }
            
        }
                
    }

    //カードをプレイする。
    void play(List<Card> inplay,List<Card> hand,int nownum,List<Card> deck,List<Card> dispile)
    {
        //シミュレート用変数のtempが内側にしかない。どうしよう
        tempAction = tempAction + hand[nownum].action - 1;
        tempBuy += hand[nownum].buy;
        tempcoin += hand[nownum].coin;
        draw(hand, deck, dispile, hand[nownum].draw);
        //アクション固有の挙動がまだ定義できていない

        //状態遷移
        inplay.Add(hand[nownum]);
        hand.RemoveAt(nownum);
    }
    //カードをN枚捨てる

}
