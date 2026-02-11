using UnityEngine;
using System.Collections.Generic;

public class RoomConnecter : MonoBehaviour
{
    public void ConnectRooms(List<Room> rooms)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            Room currentRoom = rooms[i];

            if (currentRoom.TryGetDoor(out DoorPoint connectPoint))
            {
                DoorPoint pointToConnect;

                if (TryGetConnectObject(rooms, i, out pointToConnect))
                {
                    SnapRoomToRoom(currentRoom, connectPoint, pointToConnect);
                }
            }
        }
    }

    private bool TryGetConnectObject(List<Room> rooms, int currentRoomIndex, out DoorPoint doorToConnect)
    {
        int roomToConnectIndex = Random.Range(0, rooms.Count);

        while (currentRoomIndex == roomToConnectIndex)
        {
            roomToConnectIndex = Random.Range(0, rooms.Count);
        }

        Room roomToConnect = rooms[roomToConnectIndex];

        if (roomToConnect.TryGetDoor(out doorToConnect))
        {
            return true;
        }

        return false;
    }

    private void SnapRoomToRoom(Room room, DoorPoint door, DoorPoint targetDoor)
    {
        Transform roomRoot = room.transform;

        Quaternion rotDelta = Quaternion.FromToRotation(door.transform.forward, - targetDoor.transform.forward);

        roomRoot.rotation = rotDelta * roomRoot.rotation;

        Vector3 delta = targetDoor.transform.position - door.transform.position;

        roomRoot.position += delta;

        door.SetBusy();
        targetDoor.SetBusy();
    }
}
