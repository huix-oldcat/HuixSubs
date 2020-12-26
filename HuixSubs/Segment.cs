using System;
using System.Text;

namespace HuixSubs
{
    /// <summary>一个文本段，用于组成一个现场</summary>
    public struct Segment
    {
        long historyId;
        long left;
        long right;
        byte trackId;
        Memory<byte> content;
    }
}
