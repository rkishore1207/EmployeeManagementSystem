﻿namespace Utilities.Helpers
{
    public class AsyncHelper
    {
        private static readonly TaskFactory taskFactory = new TaskFactory(CancellationToken.None,TaskCreationOptions.None,TaskContinuationOptions.None,TaskScheduler.Default);

        public static void RunSync(Func<Task> func)
        {
            taskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
        }

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return taskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
        }
    }
}
