using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public sealed class ButtonTogglersDto : IDto
    {
        public bool OstVolumeEnabled;
        public bool SfxVolumeEnabled;
    }
}