using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public sealed class ButtonTogglersDto : IDto
    {
        public bool OstVolumeEnabled = true;
        public bool SfxVolumeEnabled = true;
    }
}