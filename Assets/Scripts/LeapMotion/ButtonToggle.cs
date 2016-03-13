using LMWidgets;
using UnityEngine;
using UnityEngine.Events;

public class ButtonToggle : ButtonToggleBase
{

    [SerializeField]
    UnityEvent OnPush = null;

    [SerializeField]
    UnityEvent OnRelease = null;

    [SerializeField]
    bool is_game = false;

    bool guard_ = false;

    public override void ButtonTurnsOff()
    {
        guard_ = false;
        if (OnRelease == null) return;
        OnRelease.Invoke();
    }

    public override void ButtonTurnsOn()
    {
        if (guard_) return;
        if (OnPush == null) return;
        OnPush.Invoke();
        guard_ = true;

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);

        if (!is_game) return;
        if (collider.gameObject.layer != LayerMask.NameToLayer("LeapHandUI")) return;

        ButtonTurnsOn();
    }

    protected override void OnTriggerExit(Collider collider)
    {
        base.OnTriggerExit(collider);

        if (!is_game) return;
        if (collider.gameObject.layer != LayerMask.NameToLayer("LeapHandUI")) return;

        ButtonTurnsOff();
    }
}
