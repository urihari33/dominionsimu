using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simulate : MonoBehaviour
{
    //横断したい変数
    int tempAction;
    int tempBuy;
    int tempCoin;

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
        public string name;

        //カード固有の動作をどう持たせるか未検討(倉庫とか岐路とか)
        public Card(bool isAction,bool isCoin,bool isVictory,int action,int buy,int coin,int draw,int priority,string name)
        {
            this.isAction = isAction;
            this.isCoin = isCoin;
            this.isVictory = isVictory;
            this.action = action;
            this.buy = buy;
            this.coin = coin;
            this.draw = draw;
            this.priority = priority;
            this.name = name;
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
                Draw(hand, deck, dispile, openhand);
                //アクション、購入、金量、の初期化
                tempAction = openaction;
                tempBuy = openbuy;
                tempCoin = opencoin;
                //この後優先度順にプレイしていきたいの
                while (hand.Count == 0)
                {
                    //一旦優先度上限を10とする
                    for(int pri = 10; pri > -1; pri--)
                    {
                        for(int check = 0; check < hand.Count; check++)
                        {
                            if(hand[check].priority >= pri)
                            {
                                //ターミナルかつアクションならば優先度を1あげる。
                                if(hand[check].action == 0 && hand[check].isAction)
                                {
                                    pri++;
                                }
                                Play(inplay, hand, check, deck, dispile);
                            }
                         
                        }

                    }
                }
            }
        }
        else
        {
            Debug.Log("deck has no card!");
        }
        

        
    }

    //受け取ったデッキをシャッフルする
    void Shuffle(List<Card> list)
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
    void Draw(List<Card> hand,List<Card> deck,List<Card> dispile,int N)
    {
        for(int i = 0; i < N; i++)
        {
            if (deck.Count == 0)
            {
                deck = dispile;
                Shuffle(deck);
            }
            if (deck.Count > 0)
            {
                hand.Add(deck[0]);
                deck.RemoveAt(1);
            }
            
        }
                
    }

    //カードをプレイする。
    void Play(List<Card> inplay,List<Card> hand,int nownum,List<Card> deck,List<Card> dispile)
    {
        //シミュレート用変数のtempが内側にしかない。どうしよう
        tempAction = tempAction + hand[nownum].action - 1;
        tempBuy += hand[nownum].buy;
        tempCoin += hand[nownum].coin;
        Draw(hand, deck, dispile, hand[nownum].draw);
        //アクション固有の挙動
        Effect(hand[nownum].name,inplay,hand,deck,dispile);

        //状態遷移
        inplay.Add(hand[nownum]);
        hand.RemoveAt(nownum);
    }
    //カードをN枚捨てる
    void Discard()
    {

    }

    //カード効果(手札、捨て札、場、デッキがいる)
    void Effect(string name,List<Card> inplay, List<Card> hand, List<Card> deck, List<Card> dispile)
    {
        //こんな感じで各アクションの特別効果を作る？
        //倉庫
        string warehouse = "warehouse";
        if(name == warehouse)
        {
            //discard3
        }
    }

}
