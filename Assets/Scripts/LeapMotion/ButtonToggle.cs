using LMWidgets;
using UnityEngine;
using UnityEngine.Events;

public class ButtonToggle : ButtonToggleBase
{

    [SerializeField]
    UnityEvent OnPush = null;

    [SerializeField]
    UnityEvent OnRelease = null;

    public override void ButtonTurnsOff()
    {
        if (OnRelease == null) return;
        OnRelease.Invoke();
    }

    public override void ButtonTurnsOn()
    {
        if (OnPush == null) return;
        OnPush.Invoke();
    }

    protected override void Start()
    {
        base.Start();
    }
}
