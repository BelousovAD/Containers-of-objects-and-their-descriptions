using UnityEngine;

[CreateAssetMenu(fileName = "CurrentPlayerData")]
public class CurrentPlayerData : ScriptableObject
{
    public PlayerInfo PlayerInfo { get; set; }
    public PlayerData PlayerData { get; set; }
}
