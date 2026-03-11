using System;
using System.Collections.Generic;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public class LevelsDto : IDto
    {
        public int CurrentLevelId;
        public HashSet<int> CompletedLevels = new ();
    }
}