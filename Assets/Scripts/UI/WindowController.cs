using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] private Window[] _windows;
    [SerializeField] private Window _currentWindow;
    
    public Window CurrentWindow => _currentWindow;

    public Window GetWindow(E_WindowType windowType)
    {
        foreach (var window in _windows) 
        {
            if(window.WindowType.Equals(windowType))
                return window;
        }

        return null;
    }

    public void OpenWindow(E_WindowType windowType)
    {
        _currentWindow.CloseWindow();

        foreach (var windows in _windows)
        {
            if(windows.WindowType.Equals(windowType))
            {
                _currentWindow = windows;
                _currentWindow.gameObject.SetActive(true);
                _currentWindow.OpenWindow();
                break; 
            }
        }
    }
}
