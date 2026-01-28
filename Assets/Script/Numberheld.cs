using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// プレイヤーの鉱石最大所持数を管理するクラス
/// </summary>
public class NumberHeld : MonoBehaviour
{
    const int Scale = 25;
    Dictionary<OreType, int> maxDict = new Dictionary<OreType, int>()
    {
        { OreType.Iron,      Scale},
        { OreType.Gold,      Scale},
        { OreType.Diamond,   Scale},
        { OreType.Emerald,   Scale},
        { OreType.Coal,      Scale},
        { OreType.Copper,    Scale}
    };

    /// <summary>
    /// 最大所持数を取得
    /// </summary>
    /// <param name="type">各鉱石の名前</param>
    /// <returns>最大</returns>
    public int GetMax(OreType type)
    {
        return maxDict.ContainsKey(type) ? maxDict[type] : 0;
    }
}
