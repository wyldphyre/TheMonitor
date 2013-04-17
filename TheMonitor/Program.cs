﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TheMonitor
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var context = new TheMonitorApplicationContext();
      Application.Run(context);

      //Application.Run(new Form1());
    }
  }
}
