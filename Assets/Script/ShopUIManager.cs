using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ショップUIのパネル表示を管理するクラス
/// ・複数あるショップパネルの切り替えを担当
/// ・1つだけ表示して、他はすべて非表示にする
/// </summary>
public class ShopUIManager : MonoBehaviour
{
    [Header("表示切り替えするパネル")]
    // 表示対象のパネル一覧
    // Inspectorで順番に登録する
    // 例：
    // 0 = 強化パネル
    // 1 = 修理パネル
    // 2 = その他パネル
    public List<GameObject> panels = new List<GameObject>();

    /// <summary>
    /// 登録されているすべてのパネルを非表示にする
    /// </summary>
    void HideAll()
    {
        // panels に登録されているパネルを1つずつ非表示にする
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }
    }

    /// <summary>
    /// 指定したインデックスのパネルだけを表示する
    /// </summary>
    /// <param name="index">
    /// 表示したいパネルの番号
    /// panels リストの順番と対応する
    /// </param>
    public void ShowPanel(int index)
    {
        // まず全パネルを非表示にする
        HideAll();

        // index が範囲外の場合は何もしない
        if (index < 0 || index >= panels.Count)
        {
            Debug.LogWarning("Panel index が範囲外です");
            return;
        }

        // 指定されたパネルだけを表示
        panels[index].SetActive(true);
    }
}
