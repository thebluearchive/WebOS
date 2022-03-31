using WebOS.Components;

namespace WebOS
{
    public interface IWindowManager
    {
        public Dictionary<Window, int> OpenWindows { get; set; }
        void OpenNewWindow();
        void CloseWindow(Window window);
        void BringToTop(Window window);
    }

    public class WindowManager : IWindowManager
    {
        // Stores windows along with their associated window heights
        public Dictionary<Window, int> OpenWindows { get; set; } = new();
        private int maxWindowHeight = 0;

        public void OpenNewWindow()
        {
            Window window = new();
            maxWindowHeight += 1;
            OpenWindows.Add(window, maxWindowHeight);
        }

        public void CloseWindow(Window window)
        {
            OpenWindows.Remove(window);
        }

        public void BringToTop(Window window)
        {
            // Bringing to top is only necessary if window is not already on top
            int currentWindowHeight = OpenWindows[window];
            if (currentWindowHeight == maxWindowHeight) { return; }

            maxWindowHeight += 1;
            OpenWindows[window] = maxWindowHeight;

            // Keep the window height from growing too large
            if (maxWindowHeight >= 1000)
            {
                ResetWindowHeights();
            }
        }
        private void ResetWindowHeights()
        {
            var windowList = OpenWindows.ToList();
            windowList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            for (int i = 0; i < windowList.Count; i++)
            {
                Window window = windowList[i].Key;
                int height = windowList[i].Value;
                OpenWindows[window] = i;
            }
        }
    }
}
