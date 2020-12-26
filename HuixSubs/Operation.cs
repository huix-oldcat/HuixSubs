using System;

namespace HuixSubs
{
    public record Operation();

    public record AddSegmentOperation
    (
        long left,
        long right,
        byte trackId,
        Memory<byte> content
    ) : Operation;
}
