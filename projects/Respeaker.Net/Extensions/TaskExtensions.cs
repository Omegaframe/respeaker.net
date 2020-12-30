using System;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net.Extensions
{
    static class TaskExtensions
    {
        public static async Task AllowCancellation(this Task task)
        {
            try
            {
                await task;
            }
            catch (TaskCanceledException) { /* this is fine */}
            catch (ThreadAbortException) { /* this is fine */}
            catch (OperationCanceledException) { /* this is fine */ }
            catch (AggregateException) { /* this is fine */ }
        }
    }
}
