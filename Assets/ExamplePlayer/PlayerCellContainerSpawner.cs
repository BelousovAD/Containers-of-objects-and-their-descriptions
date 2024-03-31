using System;
using UnityEngine;

public class PlayerCellContainerSpawner : ContainerSpawner<PlayerInfosBundle>
{
    public event Action<PlayerInfo, PlayerData> OnChoose;

    [SerializeField] private GameObject _playerCellPrefab;
    [SerializeField] private PlayerDescriptionSpawner _playerDescriptionSpawner;

    private PlayerInfo _currentPlayerInfo;

    private void OnEnable()
    {
        CurrentPlayerCell.OnClick += Spawn;
        _playerDescriptionSpawner.OnChoose += ReceiveCurrentPlayerData;
    }

    private void OnDisable()
    {
        CurrentPlayerCell.OnClick -= Spawn;        
        _playerDescriptionSpawner.OnChoose -= ReceiveCurrentPlayerData;
    }

    private void Spawn(CurrentPlayerData data)
    {
        DestroyContainer();
        StartCoroutine(SpawnRoutine());
    }

    private void DestroyContainer()
    {
        PlayerCell.OnClick -= SetCurrentPlayerInfo;
        ReleaseReference();
        Destroy(ContainerInstance);
    }

    protected override void FillContainer()
    {
        foreach (PlayerInfo playerInfo in LoadedAsset.PlayerInfos)
        {
            GameObject cell = Instantiate(_playerCellPrefab, ContainerInstance.transform);
            cell.GetComponent<PlayerCell>().Construct(playerInfo);
        }
        PlayerCell.OnClick += SetCurrentPlayerInfo;
    }

    private void SetCurrentPlayerInfo(PlayerInfo playerInfo)
    {
        _currentPlayerInfo = playerInfo;
    }

    private void ReceiveCurrentPlayerData(PlayerData playerData)
    {
        OnChoose?.Invoke(_currentPlayerInfo, playerData);
        DestroyContainer();
    }
}
