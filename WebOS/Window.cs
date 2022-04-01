using Microsoft.AspNetCore.Components;

namespace WebOS
{
    public class Window
    {
        public RenderFragment ChildContent { get; set; }
        public string Width { get; set; } = "400px";
        public string Height { get; set; } = "400px";
        public double XPos { get; set; } = 200;
        public double YPos { get; set; } = 200;
        public int ZIndex { get; set; } = 0;
        public string Name { get; set; } = "";
        public bool Visible { get; set; } = true;
        public event EventHandler? OnWindowStateChanged;
        public event EventHandler? OnWindowClosed;

        public WindowState windowState = WindowState.Windowed;

        public void Minimize()
        {
            if (windowState == WindowState.Minimized)
            {
                windowState = WindowState.Windowed;
                Visible = true;
            }
            else
            {
                windowState = WindowState.Minimized;
                Visible = false;
            }
            OnWindowStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Maximize()
        {
            if (windowState == WindowState.Windowed)
            {
                windowState = WindowState.Maximized;
            }
            else if (windowState == WindowState.Maximized)
            {
                windowState = WindowState.Windowed;
            }
            XPos = 0;
            YPos = 0;
            Width = "100%";
            Height = "100%";
            OnWindowStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Close()
        {
            // It is the responsibility of the window manager to close
            // the window
            OnWindowClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
