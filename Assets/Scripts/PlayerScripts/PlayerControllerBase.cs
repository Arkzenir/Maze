using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    //Base class for use of OOP principles
    public bool CanMove { get; protected set; }
    public void SetCanMove(bool move)
    {
        CanMove = move;
    }
}
