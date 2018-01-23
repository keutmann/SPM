using System;
namespace SPM2.SharePoint.Model
{
    public interface IActionItem
    {
        EventHandler Click { get; set; }
        bool Enabled { get; set; }
        string Icon { get; set; }
        ISPNode Node { get; set; }
        string Scope { get; set; }
        string Text { get; set; }
        string ToolTipText { get; set; }
    }
}
