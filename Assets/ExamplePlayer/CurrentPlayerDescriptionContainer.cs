using System;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerDescriptionContainer : CurrentElementContainer<PlayerData>
{
    public event Action<PlayerData> OnChoose;

    [SerializeField] private Button _chooseButton;

    private void OnEnable()
    {
        _chooseButton.onClick.AddListener(Emit);
    }

    private void OnDisable()
    {
        _chooseButton.onClick.RemoveListener(Emit);
    }

    private void Emit()
    {
        OnChoose?.Invoke(CurrentElement);
    }
}
