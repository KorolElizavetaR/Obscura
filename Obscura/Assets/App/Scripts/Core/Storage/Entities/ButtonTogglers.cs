using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public class ButtonTogglers : IEntity<ButtonTogglersDto>
    {
        public bool OstVolumeEnabled { get; set; } = true;
        public bool SfxVolumeEnabled { get; set; } = true;

        public ButtonTogglers() {}

        public ButtonTogglers(ButtonTogglersDto dto)
        {
            OstVolumeEnabled = dto.OstVolumeEnabled;
            SfxVolumeEnabled = dto.SfxVolumeEnabled;
        }
        
        public ButtonTogglersDto ToDto()
        {
            return new ButtonTogglersDto()
            {
                OstVolumeEnabled = OstVolumeEnabled,
                SfxVolumeEnabled = SfxVolumeEnabled
            };
        }
    }
}