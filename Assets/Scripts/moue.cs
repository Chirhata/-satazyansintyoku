﻿
using UnityEngine;

// マウス位置に追従するオブジェクトにアタッチする（範囲制限つき、2Dプロジェクト用）
// 解説記事　http://negi-lab.blog.jp/MouseFollow2D
public class moue : MonoBehaviour
{
    // X, Y座標の移動可能範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;

    private void Update()
    {
        // マウス位置をスクリーン座標からワールド座標に変換する
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // X, Y座標の範囲を制限する
        targetPos.x = Mathf.Clamp(targetPos.x, bounds.xMin, bounds.xMax);
        targetPos.y = Mathf.Clamp(targetPos.y, bounds.yMin, bounds.yMax);

        // Z座標を修正する
        targetPos.z = 0f;

        // このスクリプトがアタッチされたゲームオブジェクトを、マウス位置に線形補間で追従させる
        transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);
    }
}