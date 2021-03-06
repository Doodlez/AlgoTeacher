﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic
{
    public class QuestEvents
    {
        public delegate void QuestEventHandler(object sender, QuestEventArgs e);

        public class QuestEventArgs : EventArgs
        {
            public IQuest Quest
            {
                get;
                private set;
            }
            public Coordinate Coord
            {
                get;
                private set;
            }
            public QuestEventArgs(IQuest quest, Coordinate coord)
            {
                this.Quest = quest;
                this.Coord = coord;
            }
        }
    }
    
    public class FillEvents
    {
        public delegate void FillEventHandler(object sender, FillEventArgs e);
        // Вызов FillEvent(this, e), как построить e смотри ниже
        public class FillEventArgs : EventArgs
        {
            public Coordinate Coord
            {
                get;
                private set;
            }

            public string Value
            {
                get; 
                private set; 
            }

           public FillEventArgs(Coordinate coord, string value)
            {
               Coord = coord;
               Value = value;
            }
        }
    }

   
   
}
