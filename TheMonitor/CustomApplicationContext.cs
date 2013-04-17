using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheMonitor
{
  class TheMonitorApplicationContext : SystemTrayApplicationContext
  {
    public TheMonitorApplicationContext() : base()
    {
      base.DoubleClickEvent += TheMonitor_DoubleClickEvent;
      base.ContextMenuOpeningEvent += TheMonitor_ContextMenuOpeningEvent;

      Initialise();
    }

    private void Initialise()
    {
      // Build constant menu items
      AddMenuItem("Configure", TheMonitor.Properties.Resources.configure_16x16, configureItemClick);
      AddMenuSeparator();
      AddMenuItem("Exit", TheMonitor.Properties.Resources.exit_16x16, exitItemClick);
      
      Run();
    }

    private void Pause()
    {
      SetIconImage(TheMonitor.Properties.Resources.sleep_16x16);

      Running = false;
    }
    private void Run()
    {
      SetIconImage(TheMonitor.Properties.Resources.play_12x16);
      
      Running = true;
    }

    private void TheMonitor_DoubleClickEvent()
    {
      if (Running)
        Pause();
      else
        Run();
    }
    private void TheMonitor_ContextMenuOpeningEvent(object sender, System.ComponentModel.CancelEventArgs e)
    {
      // Add any items here that might need to be updated each time the menu opens
      //notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
    }
    private void exitItemClick(object sender, EventArgs e)
    {
      ExitThread();
    }
    private void configureItemClick(object sender, EventArgs e)
    {
      // TO DO: 
      throw new ApplicationException("Not implemented");
    }

    private bool Running { get; set; }
  }
}
