using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenWindowButton : MonoBehaviour
{
    [SerializeField] private E_WindowType _windowType;

    private WindowController _windowController;

    [Inject]
    private void Construct(WindowController windowController)
    {
        _windowController = windowController;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _windowController.OpenWindow(_windowType);
    }
}
