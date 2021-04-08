using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Windowing.Desktop;

namespace RenderWindow
{
    public class Scene : GameWindow
    {
        public static Scene New(int width, int height, string title)
        {
            GameWindowSettings setting = new GameWindowSettings();
            NativeWindowSettings nativeSettings = new NativeWindowSettings();
            nativeSettings.Size = new OpenTK.Mathematics.Vector2i(width, height);
            nativeSettings.Title = title;
            return new Scene(setting, nativeSettings);
        }

        public Scene(GameWindowSettings setting, NativeWindowSettings nativeSettings)
            : base(setting, nativeSettings)
        { }
    }
}
