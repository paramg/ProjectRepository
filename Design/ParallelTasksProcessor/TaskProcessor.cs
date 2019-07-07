using DataStructures.Libraries.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParallelTasksProcessor
{
    public class TaskProcessor
    {
        public async void Process(IList<TaskJob> taskJobs)
        {
            IList<Vertex<TaskJob>> taskJobsVertex = this.ConvertToGraphVertex(taskJobs);

            // Detect if the tasks has any cycle.
            Graph<TaskJob> graphTaskJobs = new Graph<TaskJob>(taskJobsVertex);

            if( graphTaskJobs.IsCycleExists())
            {
                throw new Exception("There exists a cycle.");
            }

            // Build the topological stack by resolving the dependencies in DAG.
            // The topoplogical stack will contain the dependency graph that contains the least dependent tasks will be on the top while the most dependent ones will be at the bottom.
            graphTaskJobs.DFS();

            // Process jobs in parallel otherwise.
            while (graphTaskJobs.TopologicalOrderStack.Any())
            {
                TaskJob taskJob = (TaskJob) graphTaskJobs.TopologicalOrderStack.Pop();
                await taskJob.ExecteTask();
            }
        }

        public IList<Vertex<TaskJob>> ConvertToGraphVertex(IList<TaskJob> taskJobs)
        {
            IList<Vertex<TaskJob>> taskJobsVertex = new List<Vertex<TaskJob>>();

            taskJobs.ToList().ForEach((taskJob) => {
                // Create a new vertext from the task.
                Vertex<TaskJob> task = new Vertex<TaskJob>();
                task.node = taskJob;

                taskJob.DependentTasks.ForEach(dependentTask =>
                {
                    task.AddAdjacentNode(new Vertex<TaskJob> { node = dependentTask });
                });

                // Add the vertex task to the list.
                taskJobsVertex.Add(task);
            });

            return taskJobsVertex;
        }
    }
}
