﻿using ApprovalTests.Reporters;

#if DEBUG
[assembly: UseReporter(typeof(BeyondCompareReporter))]
#else
[assembly: UseReporter(typeof(DiffReporter))]
#endif

public static class TargetFrameworkResolver
{
    public const string Current =

#if NET45
            "NET45"
#elif NET46
            "NET46"
#elif NET47
            "NET47"
#else
            "Unknown"
#endif
        ;
}
