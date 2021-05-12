using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// RuleDataと同じファイルで良いのでは...？
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/MoveData", order = 2)]
public class MoveData : ScriptableObject
{
    public float moveSpd;
    public float viewMoveSpd;
    public float jumpForce;
    public float throwForce;

    [Header("カメラ操作")]
    public float minFOV;
    public float maxFOV;
    public float fovChangeSpd;
    public float limitRotY;
}
