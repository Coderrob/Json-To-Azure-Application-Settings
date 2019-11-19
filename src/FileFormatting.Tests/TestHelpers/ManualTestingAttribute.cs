using System.Diagnostics;
using Xunit;

namespace FileFormatting.Tests.TestHelpers
{
    public sealed class ManualTestingAttribute : FactAttribute
    {
        public ManualTestingAttribute()
        {
            if (!Debugger.IsAttached)
                Skip = "Only running in interactive mode.";
        }
    }
}