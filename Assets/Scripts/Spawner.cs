
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private const int MinRoomsCount = 1;
    private const int MaxRoomsCount = 5;
    private const int MinPosition = -45;
    private const int MaxPosition = 45;
    private const float SpawnedRotation = -90f;

    [SerializeField] private float _spawnHeight = 0f;

    public List<Room> SpawnRooms(List<Room> roomTypes)
    {
        List<Room> rooms = new List<Room>();

        for (int i = 0; i < roomTypes.Count; i++)
        {
            List<Room> spawnedRooms = SpawnRoomType(roomTypes[i]);
            rooms.AddRange(spawnedRooms);
        }

        return rooms;
    }

    private List<Room> SpawnRoomType(Room roomType)
    {
        int roomsCount = UnityEngine.Random.Range(MinRoomsCount, MaxRoomsCount);
        List<Room> spawnedRooms = new List<Room>();

        for (int i = 0; i < roomsCount; i++)
        {
            Room spawnedObject = Instantiate(roomType, GetSpawnPosition(), Quaternion.identity);
            spawnedObject.transform.localEulerAngles = new Vector3(SpawnedRotation, 0f, 0f);
            spawnedRooms.Add(spawnedObject);
        }

        return spawnedRooms;
    }

    private Vector3 GetSpawnPosition()
    {
        float x = UnityEngine.Random.Range(MinPosition, MaxPosition);
        float y = UnityEngine.Random.Range(MinPosition, MaxPosition);

        return new Vector3(x, _spawnHeight, y);
    }
}
