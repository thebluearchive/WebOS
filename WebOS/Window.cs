using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebOS
{
    public class Window
    {
        public RenderFragment ChildContent { get; set; }
        public double Width { get; set; } = 400;
        public double Height { get; set; } = 400;
        public double XPos { get; set; } = 200;
        public double YPos { get; set; } = 200;
        public int ZIndex { get; set; } = 0;
        public string Name { get; set; } = "";
        public bool Visible { get; set; } = true;
        public event EventHandler? OnWindowStateChanged;
        public event EventHandler? OnWindowClosed;

        public WindowState windowState = WindowState.Windowed;

        [Inject]
        private IJSRuntime js { get; set; }
        private IJSObjectReference jsModule;

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

        public async Task Maximize()
        {
            if (windowState == WindowState.Windowed)
            {
               windowState = WindowState.Maximized;
            }
            else if (windowState == WindowState.Maximized)
            {
               windowState = WindowState.Windowed;
            }

            if (jsModule is null) {
                jsModule = await js.InvokeAsync<IJSObjectReference>("import", "./Window.js");
            }
            
            XPos = 0;
            YPos = 0;
            Width = await jsModule.InvokeAsync<int>("getParentWidth");
            Height = await jsModule.InvokeAsync<int>("getParentHeight");
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
