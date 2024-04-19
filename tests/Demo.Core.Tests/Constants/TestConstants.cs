using NodaTime;

namespace Demo.Core.Tests.Constants
{
    public static class TestConstants
    {
        public static readonly Instant MockedTime = Instant.FromUtc(2024, 4, 2, 13, 49, 0);

        public static readonly Instant DefaultTime = Instant.FromUtc(1, 1, 1, 0, 0);
    }
}
