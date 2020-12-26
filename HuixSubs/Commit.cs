using System;

namespace HuixSubs
{
    public record Commit(int CommitId, Operation[] operations, Action<long> successCallback, Action failureCallback);
}
