using System;
using UnityEngine;

public class DoorPoint : MonoBehaviour
{
    public bool IsBusy { get; private set; } = false;

    public void SetBusy()
    {
        IsBusy = true;
    }
}
