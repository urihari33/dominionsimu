using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ConsoleApp1.CardInfos;
using ConsoleApp1.Params;
using ConsoleApp1;
using System;
using UnityEngine.UI;

namespace ConsoleApp1.CardEffects
{
    class BuildDeck:MonoBehaviour
    {
        //オブジェクトと結びつける
        public InputField NumCopper;
        public InputField NumSilver;

        
        public SimulationParam prm;
        public BuildDeck(SimulationParam prm) //コンストラクタを 
        {
            NumCopper = NumCopper.GetComponent<InputField>();
            NumSilver = NumSilver.GetComponent<InputField>();

            int numCopper = int.Parse(NumCopper.text);
            int numSilver = int.Parse(NumSilver.text);

            var deck = new List<ICardInfo>();

            //for (int i = 0; i < _numCopper; i++)
            //{
            //    var _copper = new Copper();
            //    deck.Add(_copper);

            //    Debug.Log(i);

            //}
            deck.AddRange(Enumerable.Repeat(new Copper(), numCopper));
            deck.AddRange(Enumerable.Repeat(new Silver(), numSilver));

            prm.Deck = deck;

           

        }
    }




}