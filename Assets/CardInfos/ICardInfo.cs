using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ConsoleApp1.CardInfos
{
    /// <summary>
    /// カード情報 インターフェース
    /// </summary>
    public interface ICardInfo
    {
        /// <summary>
        /// カード名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// カード種別
        /// </summary>
        CardTypeAttr CardType { get; }

        ///// <summary>
        ///// Nightとしてプレイした処理
        ///// </summary>
        ///// <param name="ps">プレイヤー情報</param>
        //void DoNight(PlayerStatus ps);
    }

    public interface IPlayableCard
    {
        /// <summary>
        /// プレイ優先度（数値が高い方を先にプレイ）
        /// </summary>
        int Priority { get; set; }
    }

    public interface IActionCard : IPlayableCard
    {
        /// <summary>
        /// アクションとしてプレイした処理
        /// </summary>
        /// <param name="ps">プレイヤー情報</param>
        void DoAction(PlayerStatus ps);
    }

    public interface ITresureCard
    {
        /// <summary>
        /// 財宝としてプレイした処理
        /// </summary>
        /// <param name="ps">プレイヤー情報</param>
        void DoTreasure(PlayerStatus ps);
    }
}

