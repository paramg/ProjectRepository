using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParallelTasksProcessor
{
    public class TaskJob : ITaskJob
    {
        public int Rank { get; set; }

        public string TaskName { get; set; }

        public List<TaskJob> DependentTasks { get; set; }

        public Task ExecteTask()
        {
            // Define action to execute any tasks...
            Action action = () => { 
                // Execute the task...

            };

            return Task.Run(action);
        }
    }
}
