using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ConsoleApp1.CardInfos;
using ConsoleApp1.Params;
using System;
using UnityEngine.UI;
using ConsoleApp1.CardEffects;
using ConsoleApp1;

namespace ConsoleApp1
{
    public class Program :MonoBehaviour
    {
        //オブジェクトと結びつける
        public InputField NumCopper;

        void Start()
        {
            //コンポーネントを使えるようにする。
            //NumCopper = GetComponent<InputField>();
        }

        public void OnClick()//変更前static void Main(string[] args)//static入れると動かないので抜いた
        {
            Debug.Log("sucsess call");
            NumCopper = NumCopper.GetComponent<InputField>();

            var service = new MainService();

            // TODO : 実行時にユーザーが画面で指定する情報
            var param = new SimulationParam()
            {
                
                //Deck = new ICardInfo[]//IEne...インスタンスの生成
                //{
                    
                    
                //    //new Village() { Priority = 2 },
                //},
                Count = 20,
                IsShowAllResult = false
            };
            //やりたいことの雰囲気
                                    
            int numCopper=  int.Parse(NumCopper.text);

            var deck = new List<ICardInfo>();

            //for (int i = 0; i < _numCopper; i++)
            //{
            //    var _copper = new Copper();
            //    deck.Add(_copper);

            //    Debug.Log(i);

            //}
            deck.AddRange(Enumerable.Repeat(new Copper(), numCopper));
            param.Deck = deck;

            //param.Deck = Enumerable.Repeat(new Copper(), numCopper);

            service.Exec(param);

            Debug.Log("終了。Press Any Key.");
            //Console.ReadKey();
        }
    }

    // TODO : あとでちゃんと（ｒｙ
    public class MainService
    {
        public List<PlayerStatus> _allResult;
        public PlayerStatus _playerStatus;

        public MainService()
        {
            _allResult = new List<PlayerStatus>();
        }

        public void Exec(SimulationParam param)
        {

            for (int i = 0; i < param.Count; i++)
            {
                // ex. PS情報設定
                // TODO : リファクタ。関数化。
                _playerStatus = new PlayerStatus();
                _playerStatus.Action = 1;
                _playerStatus.Coin = 0;
                _playerStatus.Buy = 1;
                _playerStatus.Deck = param.Deck.OrderBy(x => Guid.NewGuid()).ToList();
                _playerStatus.Hands = new List<ICardInfo>();
                _playerStatus.Played = new List<ICardInfo>();
                _playerStatus.Discard = new List<ICardInfo>();

                // 0. 初期処理
                // デッキからランダムで5枚引く
                for (int j = 0; j < 5; j++)
                {
                    Draw draw = new Draw(_playerStatus);

                }
                //Debug.Log($"hand num = { _playerStatus.Hands.Count}");//手札は引けていることが確認
                


                // 1. アクション
                // TBD
                while (_playerStatus.Action >= 1)
                {
                    var tmpCard = _playerStatus.Hands.Where(x => x.CardType.HasFlag(CardTypeAttr.Action)).FirstOrDefault();
                    if (tmpCard == null)
                    {
                        break;
                    }
                    
                    if (param.IsShowAllResult)
                    {
                        Debug.Log($"{tmpCard.Name},");
                    }
                    // TODO : IActionCardにCast出来ない場合の例外処理
                    _playerStatus.Action--;
                    ((IActionCard)tmpCard).DoAction(_playerStatus);
                    _playerStatus.Hands.Remove(tmpCard);
                    _playerStatus.Played.Add(tmpCard);
                }

                // 2. 購入
                while (_playerStatus.Hands.Any(x => x.CardType.HasFlag(CardTypeAttr.Treasure)))
                {
                    var tmpCard = _playerStatus.Hands.First(x => x.CardType.HasFlag(CardTypeAttr.Treasure));

                    ((ITresureCard)tmpCard).DoTreasure(_playerStatus);
                    _playerStatus.Hands.Remove(tmpCard);
                    _playerStatus.Played.Add(tmpCard);

                }

                // 3. 夜行

                // 4. クリンナップ

                // 欲しい情報書き出し
                if (param.IsShowAllResult)
                {
                    Debug.Log($"{i + 1}回目：Coin {_playerStatus.Coin}, 残り山札 {_playerStatus.Deck.Count}");
                }
                _allResult.Add(_playerStatus);
            }

            Debug.Log("-----------------------------------");
            Debug.Log($"平均金量：{_allResult.Average(x => x.Coin).ToString("0.###")}");
            Debug.Log($"残り山枚数：{_allResult.Average(x => x.Deck.Count)}");
        }
    }

    // TODO : あとでちゃんとファイルに移す
    public class PlayerStatus
    {
        public int Action { get; set; }
        public int Coin { get; set; }
        public int Buy { get; set; }

        public List<ICardInfo> Deck { get; set; }
        public List<ICardInfo> Hands { get; set; }
        public List<ICardInfo> Played { get; set; }
        public List<ICardInfo> Discard { get; set; }
    }




}





