using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.config.handlers.tiles.class_id;

namespace DayData.config.handlers.tiles
{
    public class TileManager
    {
        List<Tile> tiles;
        public static TileManager create()
        {
            return new TileManager();
        }
        public TileManager()
        {
            tiles = GlobalHandlers.DatabaseHandler.loadTiles();
            GlobalHandlers.Debugger.write("[TileManager]: Total Tiles Loaded: " + tiles.Count);

        }
        public List<Tile> getTiles()
        {
            return tiles;
        }
    }
}