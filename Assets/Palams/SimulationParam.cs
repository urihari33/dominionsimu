using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ConsoleApp1.Params
{
    /// <summary>
    /// シミュレーション条件パラメータ
    /// </summary>
    public class SimulationParam
    {
        /// <summary>
        /// 試行デッキ
        /// </summary>
        public IEnumerable<ICardInfo> Deck { get; set; }

        /// <summary>
        /// 試行回数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 全ての試行結果を表示するか
        /// </summary>
        public bool IsShowAllResult { get; set; }
    }
}
