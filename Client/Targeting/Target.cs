using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace StealthBridgeSDK.Targeting
{

    public static class Target
    {
        private static dynamic _stealth => PythonImport.Stealth;
        /// <summary>
        /// Gets the current target ID.
        /// </summary>
        /// <returns>uint</returns>
        public static uint TargetID()
        {
            using (Py.GIL())
            {
                return _stealth.TargetID();
            }
        }
        /// <summary>
        /// Lets you know if the target cursor is up
        /// </summary>
        /// <returns>bool</returns>
        public static bool TargetPresent()
        {
            using (Py.GIL())
            {
                return _stealth.TargetPresent();
            }
        }

        /// <summary>
        /// Waits maximum timeout milliseconds for a target cursor to show up
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>bool</returns>
        public static bool WaitForTarget(int timeout)
        {
            using (Py.GIL())
            {
                return _stealth.WaitForTarget(timeout);
            }
        }
        /// <summary>
        /// Sets the target cursor to a specific object
        /// </summary>
        /// <param name="serial"></param>
        public static void TargetToObject(uint serial)
        {
            using (Py.GIL())
            {
                _stealth.TargetToObject(serial);
            }
        }

        /// <summary>
        /// Selects Last Target with the Target Cursor.
        /// </summary>
        /// <returns></returns>
        public static uint LastTarget()
        {
            using (Py.GIL())
            {
                return _stealth.LastTarget();
            }
        }

        /// <summary>
        /// Sets the target cursor to a specific tile
        /// </summary>
        /// <param name="tileid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void TargetToTile(ushort tileid,ushort x, ushort y, sbyte z)
        {
            using (Py.GIL())
            {
                _stealth.TargetToTile(tileid,x, y, z);
            }
        }
        /// <summary>
        /// Cancels the target cursor.
        /// </summary>
        public static void CancelTarget()
        {
            using (Py.GIL())
            {
                _stealth.CancelTarget();
            }
        }
        /// <summary>
        /// Sets the target cursor to a specific location in the world.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void TargetToXYZ(ushort x, ushort y, sbyte z)
        {
            using (Py.GIL())
            {
                _stealth.TargetToXYZ(x, y, z);
            }
        }
        public enum TileGroup
        {
            Land = 0,
            Static = 1
        }
        public static uint GetTileFlags(TileGroup group, ushort tile)
        {
            return _stealth.GetTileFlags((byte)group, tile);
        }

        public static List<string> ConvertIntegerToFlags(TileGroup group, uint flags)
        {
            using (Py.GIL())
            {
                var pyResult = _stealth.ConvertIntegerToFlags((byte)group, flags);
                var result = new List<string>();
                foreach (var entry in pyResult)
                    result.Add(entry.As<string>());
                return result;
            }
        }
        public class LandTileData
        {
            public List<string> Flags { get; set; }
            public List<string> Flags2 { get; set; }
            public ushort TextureID { get; set; }
            public string Name { get; set; }
        }

        public static LandTileData GetLandTileData(ushort tile)
        {
            using (Py.GIL())
            {
                var pyData = _stealth.GetLandTileData(tile);
                return new LandTileData
                {
                    Flags = new List<string>(pyData["Flags"].As<List<string>>()),
                    Flags2 = new List<string>(pyData["Flags2"].As<List<string>>()),
                    TextureID = pyData["TextureID"].As<ushort>(),
                    Name = pyData["Name"].As<string>()
                };
            }
        }
        public class StaticTileData
        {
            public List<string> Flags { get; set; }
            public ushort Weight { get; set; }
            public ushort AnimID { get; set; }
            public int Height { get; set; }
            public byte[] RadarColorRGBA { get; set; }
            public string Name { get; set; }
        }

        public static StaticTileData GetStaticTileData(ushort tile)
        {
            using (Py.GIL())
            {
                var pyData = _stealth.GetStaticTileData(tile);
                return new StaticTileData
                {
                    Flags = new List<string>(pyData["Flags"].As<List<string>>()),
                    Weight = pyData["Weight"].As<ushort>(),
                    AnimID = pyData["AnimID"].As<ushort>(),
                    Height = pyData["Height"].As<int>(),
                    RadarColorRGBA = pyData["RadarColorRGBA"].As<byte[]>(),
                    Name = pyData["Name"].As<string>()
                };
            }
        }
        public static (ushort Tile, sbyte Z) GetCell(ushort x, ushort y, byte world)
        {
            var pyResult = _stealth.GetCell(x, y, world);
            return (
                pyResult["Tile"].As<ushort>(),
                pyResult["Z"].As<sbyte>()
            );
        }
        public static byte GetLayerCount(ushort x, ushort y, byte world)
    => _stealth.GetLayerCount(x, y, world);

        public static sbyte GetSurfaceZ(ushort x, ushort y, byte world)
            => _stealth.GetSurfaceZ(x, y, world);

        public static (bool Passable, sbyte ZDelta) IsWorldCellPassable(ushort currX, ushort currY, sbyte currZ, ushort destX, ushort destY, byte world)
        {
            using (Py.GIL())
            {
                var res = _stealth.IsWorldCellPassable(currX, currY, currZ, destX, destY, world);
                return (res[0].As<bool>(), res[1].As<sbyte>());
            }
        }
        public static List<(ushort Tile, ushort X, ushort Y, sbyte Z, ushort Color)> ReadStaticsXY(ushort x, ushort y, byte world)
        {
            var result = new List<(ushort, ushort, ushort, sbyte, ushort)>();
            var pyResult = _stealth.ReadStaticsXY(x, y, world);
            foreach (var entry in pyResult)
                result.Add((
                    entry["Tile"].As<ushort>(),
                    entry["X"].As<ushort>(),
                    entry["Y"].As<ushort>(),
                    entry["Z"].As<sbyte>(),
                    entry["Color"].As<ushort>()
                ));
            return result;
        }

        public static List<(ushort Tile, ushort X, ushort Y, sbyte Z, ushort Color)> GetStaticTilesArray(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte world, ushort[] tileTypes)
        {
            var result = new List<(ushort, ushort, ushort, sbyte, ushort)>();
            using (Py.GIL())
            {
                var pyResult = _stealth.GetStaticTilesArray(xmin, ymin, xmax, ymax, world, tileTypes);
                foreach (var tuple in pyResult)
                    result.Add((tuple[0].As<ushort>(), tuple[1].As<ushort>(), tuple[2].As<ushort>(), tuple[3].As<sbyte>(), tuple[4].As<ushort>()));
            }
            return result;
        }

        public static List<(ushort Tile, ushort X, ushort Y, sbyte Z, ushort Color)> GetLandTilesArray(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte world, ushort[] tileTypes)
        {
            var result = new List<(ushort, ushort, ushort, sbyte, ushort)>();
            using (Py.GIL())
            {
                var pyResult = _stealth.GetLandTilesArray(xmin, ymin, xmax, ymax, world, tileTypes);
                foreach (var tuple in pyResult)
                    result.Add((tuple[0].As<ushort>(), tuple[1].As<ushort>(), tuple[2].As<ushort>(), tuple[3].As<sbyte>(), tuple[4].As<ushort>()));
            }
            return result;
        }
        /// <summary>
        /// Requests an object selection (target an item, NPC, etc).
        /// </summary>
        public static void ClientRequestObjectTarget()
        {
            _stealth.ClientRequestObjectTarget();
        }

        /// <summary>
        /// Requests a tile selection (target a ground tile).
        /// </summary>
        public static void ClientRequestTileTarget()
        {
            _stealth.ClientRequestTileTarget();
        }

        /// <summary>
        /// Returns true if a client target response is pending.
        /// </summary>
        public static bool ClientTargetResponsePresent()
        {
            return _stealth.ClientTargetResponsePresent();
        }

        /// <summary>
        /// Retrieves the target response (object ID, tile, coordinates).
        /// </summary>
        public static TargetInfo GetClientTargetResponse()
        {
            using (Py.GIL())
            {
                var pyResult = _stealth.ClientTargetResponse();
                if (pyResult == null)
                    return null;

                return new TargetInfo
                {
                    ID = pyResult.GetItem("ID").As<uint>(),
                    Tile = pyResult.GetItem("Tile").As<ushort>(),
                    X = pyResult.GetItem("X").As<ushort>(),
                    Y = pyResult.GetItem("Y").As<ushort>(),
                    Z = pyResult.GetItem("Z").As<sbyte>()
                };
            }
        }

        /// <summary>
        /// Waits for a client target response within the specified max time (milliseconds).
        /// </summary>
        public static bool WaitForClientTargetResponse(int maxWaitTimeMs)
        {
            var end = DateTime.UtcNow.AddMilliseconds(maxWaitTimeMs);

            while (DateTime.UtcNow < end)
            {
                if (ClientTargetResponsePresent())
                    return true;

                Thread.Sleep(10);
            }
            return false;
        }

        // --- Internal Type ---
        public class TargetInfo
        {
            public uint ID { get; set; }
            public ushort Tile { get; set; }
            public ushort X { get; set; }
            public ushort Y { get; set; }
            public sbyte Z { get; set; }

            public override string ToString()
            {
                return $"[TargetInfo] ID={ID:X8}, Tile={Tile:X4}, Pos=({X},{Y},{Z})";
            }
        }
    }

}

