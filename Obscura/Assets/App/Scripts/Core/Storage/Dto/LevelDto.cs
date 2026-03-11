using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public class LevelDto : IDto
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}