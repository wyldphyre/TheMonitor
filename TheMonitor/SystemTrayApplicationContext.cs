﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheMonitor
{
  class SystemTrayApplicationContext : ApplicationContext
  {
    public SystemTrayApplicationContext()
    {
      components = new System.ComponentModel.Container();
      notifyIcon = new NotifyIcon(components)
      {
        ContextMenuStrip = new ContextMenuStrip(),
        Text = Application.ProductName,
        Visible = true
      };
      notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
      notifyIcon.DoubleClick += notifyIcon_DoubleClick;
    }

    public event Action DoubleClickEvent;
    public event System.ComponentModel.CancelEventHandler ContextMenuOpeningEvent;

    public string IconText
    {
      get { return notifyIcon.Text; }
      set { notifyIcon.Text = value; }
    }
    public Icon IconImage
    {
      get { return notifyIcon.Icon; }
    }
    public void SetIconImage(Bitmap image)
    {
      notifyIcon.Icon = Icon.FromHandle(image.GetHicon());
    }

    protected ToolStripItem AddMenuItem(string text, Image image = null, EventHandler clickHandler = null)
    {
      return notifyIcon.ContextMenuStrip.Items.Add(text, image, clickHandler);
    }
    protected void AddMenuSeparator()
    {
      notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
    }

    protected void SetIcon(Icon image)
    {
      notifyIcon.Icon = image;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null) { components.Dispose(); }
    }
    protected override void ExitThreadCore()
    {
      //if (mainForm != null) { mainForm.Close(); }
      notifyIcon.Visible = false; // should remove lingering tray icon!
      base.ExitThreadCore();
    }

    private void notifyIcon_DoubleClick(object sender, EventArgs e)
    {
 	    if (DoubleClickEvent != null)
        DoubleClickEvent();
    }
    private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (ContextMenuOpeningEvent != null)
        ContextMenuOpeningEvent(sender, e);
    }


    private System.ComponentModel.Container components;
    private NotifyIcon notifyIcon;
  }
}
