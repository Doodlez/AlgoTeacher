using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic
{
    class TaskCollection: IReadOnlyList<MyTask>
    {
        private readonly List<MyTask> myTasks;

        public TaskCollection()
        {
            myTasks = new List<MyTask>();
        }

        public TaskCollection(MyTask task)
        {
            myTasks = new List<MyTask> {task};
        }

        public MyTask this[int index]
        {
            get { return myTasks[index]; }
        }

        public int Count
        {
            get { return myTasks.Count; }
        }

        public IEnumerator<MyTask> GetEnumerator()
        {
            foreach (var myTask in myTasks)
            {
                yield return myTask;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
