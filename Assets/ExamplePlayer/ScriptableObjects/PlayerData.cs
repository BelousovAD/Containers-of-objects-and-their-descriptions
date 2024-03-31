using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private string _name = "";
    [SerializeField] private int _level = 0;
    [SerializeField] private string _description = "";

    public string Name => _name;
    public int Level => _level;
    public string Description => _description;
}
