using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheMonitor
{
  class Target
  {
    public Target(string TargetFolder)
    {
      this.TargetFolder = TargetFolder;
      this.Activities = new List<MonitoredActivity>();
    }

    public string TargetFolder { get; private set; }
    public List<MonitoredActivity> Activities { get; private set; }
  }

  class MonitoredActivity
  {
    public MonitoredActivity(string FileMask, ActivityType Type)
    {
      this.FileMask = FileMask;
      this.Type = Type;
    }

    public string FileMask { get; private set; }
    private ActivityType Type { get; private set; }
  }

  enum ActivityType
  {
    Created,
    Deleted,
    Changed
  }
}
