﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace PhotinoNET
{
    public interface IPhotinoWindow
    {
        IntPtr WindowHandle { get; }

        PhotinoWindow Parent { get; }
        List<PhotinoWindow> Children { get; }

        string Title { get; set; }
        bool Resizable { get; set; }
        Size Size { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Point Location { get; set; }
        int Left { get; set; }
        int Top { get; set; }
        IReadOnlyList<Structs.Monitor> Monitors { get; }
        Structs.Monitor MainMonitor { get; }
        uint ScreenDpi { get; }
        bool IsOnTop { get; set; }
        bool WasShown { get; }

        event EventHandler WindowCreating;
        event EventHandler WindowCreated;

        event EventHandler WindowClosing;

        event EventHandler<Size> SizeChanged;
        event EventHandler<Point> LocationChanged;

        event EventHandler<string> WebMessageReceived;

        PhotinoWindow AddChild(PhotinoWindow child);
        PhotinoWindow RemoveChild(PhotinoWindow child, bool childIsDisposing);
        PhotinoWindow RemoveChild(Guid id, bool childIsDisposing);

        PhotinoWindow SetIconFile(string path);

        PhotinoWindow Show();
        PhotinoWindow Hide();
        void Close();
        void WaitForClose();

        PhotinoWindow UserCanResize(bool isResizable);
        PhotinoWindow Resize(Size size);
        PhotinoWindow Resize(int width, int height, string unit);
        PhotinoWindow Minimize();
        PhotinoWindow Maximize();
        PhotinoWindow Fullscreen();
        PhotinoWindow Restore();

        PhotinoWindow MoveTo(Point location, bool allowOutsideWorkArea);
        PhotinoWindow MoveTo(int left, int top, bool allowOutsideWorkArea);
        PhotinoWindow Offset(Point offset);
        PhotinoWindow Offset(int left, int top);
        PhotinoWindow Center();

        PhotinoWindow Load(Uri uri);
        PhotinoWindow Load(string path);
        PhotinoWindow LoadRawString(string content);

        PhotinoWindow OpenAlertWindow(string title, string message);

        PhotinoWindow SendWebMessage(string message);

        PhotinoWindow RegisterWindowClosingHandler(EventHandler handler);

        PhotinoWindow RegisterSizeChangedHandler(EventHandler<Size> handler);
        PhotinoWindow RegisterLocationChangedHandler(EventHandler<Point> handler);

        PhotinoWindow RegisterWebMessageReceivedHandler(EventHandler<string> handler);
    }
}