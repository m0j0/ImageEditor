using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ImageEditor.Infrastructure.Rendering
{
    internal class RenderingWorker : IDisposable
    {
        #region Nested types

        private class Job
        {
            public Job(Action action, bool canSkip)
            {
                Action = action;
                CanSkip = canSkip;
                TaskCompletionSource = new TaskCompletionSource<object>();
            }

            public TaskCompletionSource<object> TaskCompletionSource { get; }

            public Action Action { get; }

            public bool CanSkip { get; }
        }

        #endregion

        #region Fields

        private readonly BlockingCollection<Job> _blockingCollection;

        #endregion

        #region Constructors

        public RenderingWorker()
        {
            _blockingCollection = new BlockingCollection<Job>();

            Task.Run(() =>
            {
                while (!_blockingCollection.IsCompleted)
                {
                    var job = _blockingCollection.Take();
                    if (_blockingCollection.Count == 0 ||
                        !job.CanSkip)
                    {
                        job.Action();
                    }

                    job.TaskCompletionSource.SetResult(null);
                }
            });
        }

        #endregion

        #region Methods

        public void AddJob(Action action)
        {
            var job = new Job(action, false);
            _blockingCollection.Add(job);
        }

        public Task AddJobAsync(Action action)
        {
            var job = new Job(action, false);
            _blockingCollection.Add(job);
            return job.TaskCompletionSource.Task;
        }

        public void AddSkippableJob(Action action)
        {
            var job = new Job(action, true);
            _blockingCollection.Add(job);
        }

        public void Dispose()
        {
            _blockingCollection.CompleteAdding();
        }

        #endregion
    }
}
