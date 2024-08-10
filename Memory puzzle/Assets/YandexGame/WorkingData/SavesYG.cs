using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public Dictionary<Difficulty.Names, int> HighScore = new Dictionary<Difficulty.Names, int>{
            { Difficulty.Names.Normal, 0 },
            { Difficulty.Names.Hard, 0 },
            { Difficulty.Names.Impossible, 0 }
        };
    }
}
