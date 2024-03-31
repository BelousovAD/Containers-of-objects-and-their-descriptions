using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    [SerializeField] private Sprite _sprite = null;
    [SerializeField] private AssetReferenceT<PlayerData> _playerData = null;

    public Sprite Sprite => _sprite;
    public AssetReferenceT<PlayerData> PlayerData => _playerData;
}
