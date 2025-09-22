using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    // [Tooltip("把所有只应在本地玩家运行的脚本拖到这里")]
    // public MonoBehaviour[] localOnlyComponents;
    //
    // void Start()
    // {
    //     if (isLocalPlayer)
    //     {
    //         // 本地玩家：启用需要本地输入的脚本
    //         foreach (var comp in localOnlyComponents)
    //             if (comp) comp.enabled = true;
    //     }
    //     else
    //     {
    //         // 远端玩家：禁用它们，显示/插值由网络接收
    //         foreach (var comp in localOnlyComponents)
    //             if (comp) comp.enabled = false;
    //     }
    // }
}
