using System;

public class PlayerDescriptionSpawner : ContainerSpawner<PlayerData>
{
    public event Action<PlayerData> OnChoose;

    private void OnEnable()
    {
        PlayerCell.OnClick += Spawn;
    }

    private void OnDisable()
    {
        PlayerCell.OnClick -= Spawn;
    }

    private void Spawn(PlayerInfo playerInfo)
    {
        if (ContainerInstance) DestroyContainer();
        SetAssetReference(playerInfo.PlayerData);
        StartCoroutine(SpawnRoutine());
    }

    private void DestroyContainer()
    {
        ContainerInstance.GetComponent<CurrentPlayerDescriptionContainer>().OnChoose -= ReceiveCurrentPlayerData;
        ReleaseReference();
        Destroy(ContainerInstance);
    }

    protected override void FillContainer()
    {
        ContainerInstance.GetComponent<PlayerDescription>().Construct(LoadedAsset);
        ContainerInstance.GetComponent<CurrentPlayerDescriptionContainer>().OnChoose += ReceiveCurrentPlayerData;
    }

    private void ReceiveCurrentPlayerData(PlayerData playerData)
    {
        OnChoose?.Invoke(playerData);
        DestroyContainer();
    }
}
