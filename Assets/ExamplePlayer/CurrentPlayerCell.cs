using UnityEngine;

public class CurrentPlayerCell : Cell<CurrentPlayerData>
{
    [SerializeField] private PlayerCellContainerSpawner _playerCellContainerSpawner;

    protected override void OnEnable()
    {
        _playerCellContainerSpawner.OnChoose += ReceiveCurrentPlayerData;
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        _playerCellContainerSpawner.OnChoose -= ReceiveCurrentPlayerData;
        base.OnDisable();
    }

    public override void Construct(CurrentPlayerData info)
    {
        Info = info;
        Redraw();
    }

    private void ReceiveCurrentPlayerData(PlayerInfo info, PlayerData data)
    {
        Info.PlayerInfo = info;
        Info.PlayerData = data;
        Redraw();
    }

    private void Redraw()
    {
        if (Info.PlayerInfo.Sprite != null)
        {
            image.sprite = Info.PlayerInfo.Sprite;
        }
    }
}
