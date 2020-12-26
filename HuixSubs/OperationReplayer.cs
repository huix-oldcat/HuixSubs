using System;
using System.Collections.Concurrent;
using System.Threading;

namespace HuixSubs
{
    public class OperationReplayer
    {
        Thread? replayerThread;
        ConcurrentQueue<Commit> CommitQueue = new(); 

        public CancellationToken CancellationToken { get; }

        public OperationReplayer(CancellationToken cancellationToken = default)
        {
            CancellationToken = cancellationToken;
        }

        public void StartReplayerThread()
        {
            if (replayerThread is not null)
            {
                throw new InvalidOperationException("Replayer thread is already running.");
            }
            
            replayerThread = new Thread(ReplayerMain);
            replayerThread.IsBackground = true;
            replayerThread.Start();
        }

        private void ReplayerMain()
        {
            while(!CancellationToken.IsCancellationRequested)
            {
                if (CommitQueue.TryDequeue(out var commit))
                {
                    commit.successCallback(0);
                }
                Thread.Sleep(1);
            }
        }
    }
}
