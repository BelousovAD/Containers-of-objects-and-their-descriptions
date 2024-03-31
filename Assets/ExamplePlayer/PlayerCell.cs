public class PlayerCell : Cell<PlayerInfo>
{
    public override void Construct(PlayerInfo info)
    {
        Info = info;

        if (Info.Sprite != null)
        {
            image.sprite = Info.Sprite;
        }
    }
}
