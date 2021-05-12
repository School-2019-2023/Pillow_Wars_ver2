using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MoveData�Ɠ����t�@�C���ŗǂ��Ȃ�...?
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/RuleData", order = 3)]
public class RuleData : ScriptableObject
{
    public int maxHp;
    public float pillowThrowCT;
    public float pillowHeadShotStunLength;
}