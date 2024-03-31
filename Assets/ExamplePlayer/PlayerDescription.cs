using TMPro;
using UnityEngine;

public class PlayerDescription : Description<PlayerData>
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _description;

    public override void Construct(PlayerData data)
    {
        Data = data;

        _name.text = Data.name;
        _level.text = Data.Level.ToString();
        _description.text = Data.Description;
    }
}
