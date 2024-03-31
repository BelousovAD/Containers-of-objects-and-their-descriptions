using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfosBundle")]
public class PlayerInfosBundle : ScriptableObject
{
    [SerializeField] private List<PlayerInfo> _playerInfos;

    public List<PlayerInfo> PlayerInfos => _playerInfos;
}
