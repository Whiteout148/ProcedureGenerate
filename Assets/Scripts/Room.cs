using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    [SerializeField] private List<DoorPoint> _doorPoints = new List<DoorPoint>();

    public bool TryGetDoor(out DoorPoint doorPoint)
    {
        for (int i = 0; i < _doorPoints.Count; i++)
        {
            if (_doorPoints[i].IsBusy == false)
            {
                doorPoint = _doorPoints[i];
                return true;
            }
        }

        doorPoint = null;
        return false;
    }
}
