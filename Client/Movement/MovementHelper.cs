using System;
using System.Threading;
using System.Collections.Generic;
using StealthBridgeSDK.Movement;
using StealthBridgeSDK.Characters;
using StealthBridgeSDK.Mobiles;

namespace StealthBridgeSDK.Helpers
{
    public static class MovementHelper
    {
        private static readonly int RetryDelayMs = 100; // Delay between retries
        private static readonly int StepDelayMs = 300; // Default delay between steps
        private static readonly int MaxRetryCount = 5; // Retry max times if blocked

        /// <summary>
        /// Simple Move to Coordinate (2D XY only)
        /// </summary>
        public static bool MoveTo(int targetX, int targetY, int accuracy = 1, bool running = false)
        {
            for (int attempt = 0; attempt < MaxRetryCount; attempt++)
            {
                if (MovementWrapper.MoveXY((ushort)targetX, (ushort)targetY, optimized: true, accuracy, running))
                    return true;

                Logger.Warn($"[Movement] Move attempt {attempt + 1} failed. Retrying...");
                Thread.Sleep(RetryDelayMs);
            }
            Logger.Error("[Movement] MoveTo failed after retries.");
            return false;
        }

        /// <summary>
        /// Move to a 3D Point (XYZ)
        /// </summary>
        public static bool MoveTo3D(int targetX, int targetY, int targetZ, int accuracyXY = 1, int accuracyZ = 5, bool running = false)
        {
            for (int attempt = 0; attempt < MaxRetryCount; attempt++)
            {
                if (MovementWrapper.MoveXYZ((ushort)targetX, (ushort)targetY, (byte)targetZ, accuracyXY, accuracyZ, running))
                    return true;

                Logger.Warn($"[Movement] Move3D attempt {attempt + 1} failed. Retrying...");
                Thread.Sleep(RetryDelayMs);
            }
            Logger.Error("[Movement] MoveTo3D failed after retries.");
            return false;
        }

        /// <summary>
        /// Step in a direction
        /// </summary>
        public static bool TryStep(byte direction, bool running = false)
        {
            byte result = MovementWrapper.Step(direction, running);
            if (result == 0)
            {
                Logger.Info($"[Movement] Step {direction} successful.");
                Thread.Sleep(StepDelayMs);
                return true;
            }
            Logger.Warn($"[Movement] Step {direction} failed.");
            return false;
        }

        /// <summary>
        /// Smart walk toward a target using pathfinding (3D aware)
        /// </summary>
        public static bool FollowPathTo3D(int destX, int destY, int destZ, int accuracyXY = 1, int accuracyZ = 5, bool running = false)
        {
            Logger.Info($"[Movement] Finding path to ({destX},{destY},{destZ})...");
            var path = MovementWrapper.GetPathArray3D(
                Character.GetX(),
                Character.GetY(),
                Character.GetZ(),
                (ushort)destX, (ushort)destY, (byte)destZ,
                Character.WorldNum(),
                accuracyXY, accuracyZ, running
            );

            if (path == null || path.Count == 0)
            {
                Logger.Error("[Movement] No path found!");
                return false;
            }

            Logger.Info($"[Movement] Path found with {path.Count} steps.");

            foreach (var step in path)
            {
                if (!MoveTo((int)step.X, (int)step.Y, accuracyXY, running))
                {
                    Logger.Error("[Movement] Failed to step along path.");
                    return false;
                }
            }

            Logger.Info("[Movement] Destination reached!");
            return true;
        }

        /// <summary>
        /// Retry step logic, with smart direction adjusting
        /// </summary>
        public static bool SmartStepTo(int targetX, int targetY, bool running = false)
        {
            var currentX = Character.GetX();
            var currentY = Character.GetY();

            int dir = MovementWrapper.CalcDir(currentX, currentY, targetX, targetY);
            if (dir == 100)
            {
                Logger.Error("[Movement] Unable to calculate direction.");
                return false;
            }

            for (int attempt = 0; attempt < MaxRetryCount; attempt++)
            {
                if (TryStep((byte)dir, running))
                    return true;

                Logger.Warn($"[Movement] Retrying step toward {targetX},{targetY}...");
                Thread.Sleep(RetryDelayMs);
            }

            Logger.Error("[Movement] Failed to step after retries.");
            return false;
        }

        /// <summary>
        /// Emergency Stop Mover
        /// </summary>
        public static void StopMovement()
        {
            Logger.Warn("[Movement] Emergency Stop!");
            MovementWrapper.StopMover();
        }
        /// <summary>
        /// Automatically follows a moving target.
        /// </summary>
        /// <param name="targetSerial">The serial ID of the mobile to follow.</param>
        /// <param name="stopDistance">Distance to maintain (0 = stand on top of target).</param>
        /// <param name="maxFollowTimeMs">Optional maximum follow time in milliseconds (0 = infinite).</param>
        /// <param name="run">Whether to run or walk.</param>
        public static void AutoFollow(uint targetSerial, int stopDistance = 1, int maxFollowTimeMs = 0, bool run = false)
        {
            Console.WriteLine($"[AutoFollow] Starting follow of 0x{targetSerial:X} with stop distance {stopDistance}");

            var startTime = DateTime.Now;

            while (true)
            {
                // Check for timeout
                if (maxFollowTimeMs > 0 && (DateTime.Now - startTime).TotalMilliseconds >= maxFollowTimeMs)
                {
                    Console.WriteLine("[AutoFollow] Timed out.");
                    break;
                }

                // Check if target still exists
                var mobile = Mobile.GetHP(targetSerial);
                if (mobile == null || mobile == 0)
                {
                    Console.WriteLine("[AutoFollow] Target disappeared.");
                    break;
                }

                // Calculate distance
                int dx = Math.Abs(Character.GetX() - Mobile.GetX(targetSerial));
                int dy = Math.Abs(Character.GetY() - Mobile.GetY(targetSerial));
                int distance = Math.Max(dx, dy);

                // Are we already close enough?
                if (distance <= stopDistance)
                {
                    Thread.Sleep(100); // Check again in a little bit
                    continue;
                }

                // Move closer
                MovementWrapper.MoveXY(Mobile.GetX(targetSerial), Mobile.GetY(targetSerial), false, stopDistance, run);

                Thread.Sleep(200); // Give it a little time before rechecking
            }

            Console.WriteLine("[AutoFollow] Done following.");
        }
    }
}
