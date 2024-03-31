using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Cell<T> : Selectable, IPointerClickHandler, ISubmitHandler where T : ScriptableObject
{
    public static event Action<T> OnClick;

    [SerializeField] private T _info;

    public T Info { get { return _info; } protected set { _info = value; } }

    public abstract void Construct(T info);

    private void Press()
    {
        if (!IsActive() || !IsInteractable())
            return;

        OnClick?.Invoke(Info);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        Press();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Press();

        if (!IsActive() || !IsInteractable())
            return;

        DoStateTransition(SelectionState.Pressed, false);
    }
}
