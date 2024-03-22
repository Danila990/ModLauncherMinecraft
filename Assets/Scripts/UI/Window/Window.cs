using UnityEngine;
using Zenject;

public class Window : MonoBehaviour
{
    [SerializeField] private E_WindowType _windowType;

    private WindowAnimation _windowAnimation;
    private WindowController _windowController;

    public E_WindowType WindowType => _windowType;

    [Inject]
    private void Construct(WindowController windowController)
    {
        _windowController = windowController;
    }

    protected virtual void Awake()
    {
        _windowAnimation = GetComponent<WindowAnimation>();
        _windowAnimation.Init();
    }

    public void OpenWindow()
    {
        _windowAnimation.OpenAnimation();
    }

    public void CloseWindow() 
    {
        _windowAnimation.CloseAnimation(CallbackClose);
    }

    private void CallbackClose()
    {
        if (_windowController.CurrentWindow == this)
            return;

        gameObject.SetActive(false);
    }
}
