using System;

public class TaskLists
{
    public decimal Id {get; set; }
    public string Text {get; set; }
    public int IsImportant {get; set; }
    public DateTime DateStarted {get; set; }
    public DateTime? DateFinished {get; set; }
    public int IsCompleted {get; set; }
}