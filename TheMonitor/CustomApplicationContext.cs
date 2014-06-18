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
      base.IconDoubleClickEvent += TheMonitor_DoubleClickEvent;
      base.ContextMenuOpeningEvent += TheMonitor_ContextMenuOpeningEvent;

      Initialise();
    }

    private void Initialise()
    {
      // Build constant menu items
      AddMenuItem("Configure", TheMonitor.Properties.Resources.configure_16x16, configureItemClick);
      toggleActivityStateItem = AddMenuItem("", TheMonitor.Properties.Resources.sleep_16x16, toggleActivityStateItemClick);
      AddMenuSeparator();
      AddMenuItem("Exit", TheMonitor.Properties.Resources.exit_16x16, exitItemClick);
      
      Run();
    }

    private void Sleep()
    {
      SetIconImage(TheMonitor.Properties.Resources.sleep_16x16);
      

      Running = false;
    }
    private void Run()
    {
      SetIconImage(TheMonitor.Properties.Resources.run_12x16);
      
      Running = true;
    }

    private void ToggleActivityState()
    {
      if (Running)
        Sleep();
      else
        Run();
    }
    private void TheMonitor_DoubleClickEvent()
    {      
    }
    private void TheMonitor_ContextMenuOpeningEvent(object sender, System.ComponentModel.CancelEventArgs e)
    {
      // Add any items here that might need to be updated each time the menu opens

      if (Running)
      {
        toggleActivityStateItem.Image = TheMonitor.Properties.Resources.sleep_16x16;
        toggleActivityStateItem.Text = "Pause";
      }
      else
      {
        toggleActivityStateItem.Image = TheMonitor.Properties.Resources.run_12x16;
        toggleActivityStateItem.Text = "Run";
      }
    }
    private void exitItemClick(object sender, EventArgs e)
    {
      ExitApplication();
    }
    private void toggleActivityStateItemClick(object sender, EventArgs e)
    {
      ToggleActivityState();
    }
    private void configureItemClick(object sender, EventArgs e)
    {
      // TO DO: 
    }

    private bool Running { get; set; }

    private ToolStripItem toggleActivityStateItem;
  }
}
