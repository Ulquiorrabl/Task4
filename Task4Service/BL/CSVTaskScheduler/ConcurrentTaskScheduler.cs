using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Service.Buisness.CSVTaskScheduler
{
    public class ConcurrentTaskScheduler : TaskScheduler
    {
        private List<Task> _tasks = new List<Task>();

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks;
        }

        protected override void QueueTask(Task task)
        {
            _tasks.Add(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            throw new NotImplementedException();
        }
    }
}
