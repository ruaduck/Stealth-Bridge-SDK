using System;
using System.Collections.Generic;
using Python.Runtime;

namespace StealthBridgeSDK.Movement
{
    public static class MovementWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        // Basic Movement

        public static byte Step(byte direction, bool running = false)
            => _stealth.Step(direction, running);

        public static int StepQ(byte direction, bool running)
            => _stealth.StepQ(direction, running);

        public static bool MoveXYZ(ushort x, ushort y, byte z, int accuracyXY, int accuracyZ, bool running)
            => _stealth.MoveXYZ(x, y, z, accuracyXY, accuracyZ, running);

        public static bool MoveXY(ushort x, ushort y, bool optimized, int accuracy, bool running)
            => _stealth.MoveXY(x, y, optimized, accuracy, running);

        public static void SetBadLocation(ushort x, ushort y)
            => _stealth.SetBadLocation(x, y);

        public static void SetGoodLocation(ushort x, ushort y)
            => _stealth.SetGoodLocation(x, y);

        public static void ClearBadLocationList()
            => _stealth.ClearBadLocationList();

        public static void SetBadObject(ushort type, ushort color, byte radius)
            => _stealth.SetBadObject(type, color, radius);

        public static void ClearBadObjectList()
            => _stealth.ClearBadObjectList();

        public static void StopMover()
            => _stealth.MoverStop();

        // Line of Sight

        public static bool CheckLOS(ushort xf, ushort yf, byte zf, ushort xt, ushort yt, byte zt, byte worldNum, byte losType = 1, uint losOptions = 0)
            => _stealth.CheckLOS(xf, yf, zf, xt, yt, zt, worldNum, losType, losOptions);

        // Pathfinding

        public static List<(ushort X, ushort Y, sbyte Z)> GetPathArray3D(ushort startX, ushort startY, byte startZ, ushort endX, ushort endY, byte endZ, byte worldNum, int accuracyXY, int accuracyZ, bool running)
        {
            var result = new List<(ushort, ushort, sbyte)>();
            using (Py.GIL())
            {
                var pyResult = _stealth.GetPathArray3D(startX, startY, startZ, endX, endY, endZ, worldNum, accuracyXY, accuracyZ, running);
                foreach (var entry in pyResult)
                {
                    result.Add((entry[0].As<ushort>(), entry[1].As<ushort>(), entry[2].As<sbyte>()));
                }
            }
            return result;
        }

        public static List<(ushort X, ushort Y, sbyte Z)> GetPathArray(ushort destX, ushort destY, bool optimized, int accuracy)
        {
            var result = new List<(ushort, ushort, sbyte)>();
            using (Py.GIL())
            {
                var pyResult = _stealth.GetPathArray(destX, destY, optimized, accuracy);
                foreach (var entry in pyResult)
                {
                    result.Add((entry[0].As<ushort>(), entry[1].As<ushort>(), entry[2].As<sbyte>()));
                }
            }
            return result;
        }

        // Direction and Distance Helpers

        public static int Dist(int x1, int y1, int x2, int y2)
            => Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));

        public static (int X, int Y) CalcCoord(int x, int y, int dir)
        {
            switch (dir)
            {
                case 0: return (x, y - 1);
                case 1: return (x + 1, y - 1);
                case 2: return (x + 1, y);
                case 3: return (x + 1, y + 1);
                case 4: return (x, y + 1);
                case 5: return (x - 1, y + 1);
                case 6: return (x - 1, y);
                case 7: return (x - 1, y - 1);
                default: return (x, y);
            }
        }

        public static int CalcDir(int xFrom, int yFrom, int xTo, int yTo)
        {
            int dx = Math.Abs(xTo - xFrom);
            int dy = Math.Abs(yTo - yFrom);

            if (dx == 0 && dy == 0)
                return 100;

            if (dx / (dy + 0.1) >= 2)
                return xFrom > xTo ? 6 : 2;
            if (dy / (dx + 0.1) >= 2)
                return yFrom > yTo ? 0 : 4;

            if (xFrom > xTo)
                return yFrom > yTo ? 7 : 5;
            if (xFrom < xTo)
                return yFrom > yTo ? 1 : 3;

            return 100;
        }

        // Movement Timers (Walking and Running)

        public static void SetRunUnmountTimer(ushort value) => _stealth.SetRunUnmountTimer(value);
        public static void SetWalkMountTimer(ushort value) => _stealth.SetWalkMountTimer(value);
        public static void SetRunMountTimer(ushort value) => _stealth.SetRunMountTimer(value);
        public static void SetWalkUnmountTimer(ushort value) => _stealth.SetWalkUnmountTimer(value);

        public static ushort GetRunMountTimer() => _stealth.GetRunMountTimer();
        public static ushort GetWalkMountTimer() => _stealth.GetWalkMountTimer();
        public static ushort GetRunUnmountTimer() => _stealth.GetRunUnmountTimer();
        public static ushort GetWalkUnmountTimer() => _stealth.GetWalkUnmountTimer();

        // StepQ Utilities

        public static uint GetLastStepQUsedDoor() => _stealth.GetLastStepQUsedDoor();
    }
}
