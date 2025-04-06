namespace StealthBridgeSDK.Targeting
{
    public static class TargetingHelper
    {
        private static uint? _lastObjectTarget;
        private static (ushort X, ushort Y, sbyte Z)? _lastTileTarget;

        public static void RememberObject(uint serial)
        {
            _lastObjectTarget = serial;
        }

        public static uint? GetLastObject()
        {
            return _lastObjectTarget;
        }

        public static void RememberTile(ushort x, ushort y, sbyte z)
        {
            _lastTileTarget = (x, y, z);
        }

        public static (ushort, ushort, sbyte)? GetLastTile()
        {
            return _lastTileTarget;
        }
    }
}