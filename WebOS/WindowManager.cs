using WebOS.Components;

namespace WebOS
{
    public interface IWindowManager
    {
        public HashSet<Window> OpenWindows { get; set; }
        public event EventHandler OnOpenWindowsChanged;
        void OpenNewWindow(Window window);
        void CloseWindow(Window window);
        void BringToTop(Window window);
    }

    public class WindowManager : IWindowManager
    {
        public HashSet<Window> OpenWindows { get; set; } = new();
        private int maxWindowHeight = 0;
        public event EventHandler? OnOpenWindowsChanged;

        public void OpenNewWindow(Window window)
        {
            window.OnWindowClosed += (obj, args) => CloseWindow((Window)obj);
            maxWindowHeight += 1;
            OpenWindows.Add(window);
            OnOpenWindowsChanged?.Invoke(this, new EventArgs());
        }

        public void CloseWindow(Window window)
        {
            OpenWindows.Remove(window);
            OnOpenWindowsChanged?.Invoke(this, new EventArgs());
        }

        public void BringToTop(Window window)
        {
            // Bringing to top is only necessary if window is not already on top
            if (window.ZIndex == maxWindowHeight) { return; }

            maxWindowHeight += 1;
            window.ZIndex = maxWindowHeight;

            // Keep the window height from growing too large
            if (maxWindowHeight >= 1000)
            {
                ResetWindowHeights();
            }
        }

        private void ResetWindowHeights()
        {
            var windowList = OpenWindows.ToList();
            windowList.Sort((window1, window2) => window1.ZIndex.CompareTo(window2.ZIndex));

            for (int i = 0; i < windowList.Count; i++)
            {
                Window window = windowList[i];
                window.ZIndex = i;
            }
        }
    }
}
