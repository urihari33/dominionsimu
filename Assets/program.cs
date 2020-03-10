using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ConsoleApp1.CardInfos;
using ConsoleApp1.Params;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new MainService();

            // TODO : 実行時にユーザーが画面で指定する情報
            var param = new SimulationParam()
            {
                Deck = new ICardInfo[]
                {
                    new Copper(),
                    new Copper(),
                    new Copper(),
                    new Copper(),
                    new Copper(),
                    new Copper(),
                    new Copper(),
                    new Estate(),
                    new Estate(),
                    new Estate(),
                    new Smithy() { Priority = 1 },
                    new Smithy() { Priority = 1 },
                    new Smithy() { Priority = 1 },
                    new Village() { Priority = 2 },
                    new Village() { Priority = 2 },
                    new Village() { Priority = 2 },
                    new Village() { Priority = 2 },
                    new Village() { Priority = 2 },
                },
                Count = 20,
                IsShowAllResult = true
            };

            service.Exec(param);

            Console.WriteLine("終了。Press Any Key.");
            Console.ReadKey();
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
                    var tmpCard = _playerStatus.Deck.FirstOrDefault();
                    if (tmpCard == null)
                    {
                        break;
                    }
                    _playerStatus.Deck.Remove(tmpCard);
                    _playerStatus.Hands.Add(tmpCard);
                }

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
                        Console.Write($"{tmpCard.Name},");
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
                    Console.WriteLine($"{i + 1}回目：Coin {_playerStatus.Coin}, 残り山札 {_playerStatus.Deck.Count}");
                }
                _allResult.Add(_playerStatus);
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"平均金量：{_allResult.Average(x => x.Coin).ToString("0.###")}");
            Console.WriteLine($"残り山枚数：{_allResult.Average(x => x.Deck.Count)}");
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
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
