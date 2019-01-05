using System;

namespace Geekbrains
{
    public class SaveData
    {
        internal readonly int id;

        internal readonly string locationKey;

        internal readonly string playerName;

        internal readonly DateTime savingDateTime;

        internal readonly string pathToImage;

        internal SaveData(int id, string locationKey, string playerName, DateTime savingDateTime, string pathToImage)
        {
            this.id = id;
            this.locationKey = locationKey;
            this.playerName = playerName;
            this.savingDateTime = savingDateTime;
            this.pathToImage = pathToImage;
        }
    }
}