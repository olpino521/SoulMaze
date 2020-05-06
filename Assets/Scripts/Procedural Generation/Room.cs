using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomState
{
    DARK = 0,
    LIT
}
public class Room: MonoBehaviour
{
    private RoomState roomState;

    public RoomState RoomState { get => roomState; set => roomState = value; }
}
