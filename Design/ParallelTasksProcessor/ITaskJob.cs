﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParallelTasksProcessor
{
    public interface ITaskJob
    {
        Task ExecteTask();
    }
}
