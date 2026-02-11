using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private RoomConnecter _connecter;
    [SerializeField] private List<Room> _roomTypes = new List<Room>();
    private List<Room> _rooms;

    private void Awake()
    {
        _rooms = _spawner.SpawnRooms(_roomTypes);
    }

    private void Start()
    {
        _connecter.ConnectRooms(_rooms);
    }
}
