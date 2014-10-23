using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic
{
    static class TaskEvents
    {
        public delegate void QuestEventHandler(object sender, QuestEventArgs e);
        public static event QuestEventHandler QuestEvent;

        public delegate void FillEventHandler(object sender, FillEventArgs e);
        public static event FillEventHandler FillEvent;
        // Вызов FillEvent(this, e), как построить e смотри ниже
    }

    public class QuestEventArgs
    {
        public IQuest Quest { get; private set; } 
        public Coordinate Coord { get; private set;}
        QuestEventArgs(IQuest quest, Coordinate coord)
        {
            this.Quest = quest;
            this.Coord = coord;
        }
    }

    public class FillEventArgs
    {
        public Coordinate Coord { get; private set;}
        FillEventArgs(Coordinate coord)
        {
            this.Coord = coord;
        }
    }
}
