using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public sealed class ButtonTogglersDto : IDto
    {
        private bool _ostVolumeEnabled = true;
        private bool _sfxVolumeEnabled = true;

        public bool OstVolumeEnabled
        {
            get => _ostVolumeEnabled;
            set => _ostVolumeEnabled = value;
        }

        public bool SfxVolumeEnabled
        {
            get => _sfxVolumeEnabled;
            set => _sfxVolumeEnabled = value;
        }
    }
}