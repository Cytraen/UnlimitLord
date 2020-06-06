#if mcmMode

using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

namespace UnlimitLord
{
    internal sealed class McmSettings : AttributeGlobalSettings<McmSettings>
    {
        public override string Id => "UnlimitLord";
        public override string DisplayName => "UnlimitLord";
        public override string FolderName => "UnlimitLord";
        public override string Format => "json";

        private bool _disableCompanionAmount = true;
        private bool _disablePartyAmount = true;
        private bool _disablePartySize = true;
        private bool _disablePrisonerAmount = true;
        private bool _disableWorkshopAmount = true;
        private bool _disableClanPartiesEating = true;

        [SettingPropertyBool("Disable Companion Limit", Order = 1, RequireRestart = true)]
        public bool DisableCompanionAmount
        {
            get => _disableCompanionAmount;
            set
            {
                if (_disableCompanionAmount == value) return;
                _disableCompanionAmount = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyBool("Disable Clan Party Limit", Order = 2, RequireRestart = true)]
        public bool DisablePartyAmount
        {
            get => _disablePartyAmount;
            set
            {
                if (_disablePartyAmount == value) return;
                _disablePartyAmount = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyBool("Disable Party Size Limit", Order = 3, RequireRestart = true)]
        public bool DisablePartySize
        {
            get => _disablePartySize;
            set
            {
                if (_disablePartySize == value) return;
                _disablePartySize = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyBool("Disable Prisoner Limit", Order = 4, RequireRestart = true)]
        public bool DisablePrisonerAmount
        {
            get => _disablePrisonerAmount;
            set
            {
                if (_disablePrisonerAmount == value) return;
                _disablePrisonerAmount = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyBool("Disable Workshop Limit", Order = 5, RequireRestart = true)]
        public bool DisableWorkshopAmount
        {
            get => _disableWorkshopAmount;
            set
            {
                if (_disableWorkshopAmount == value) return;
                _disableWorkshopAmount = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyBool("Disable Party Food Consumption", Order = 6, RequireRestart = true)]
        public bool DisableClanPartiesEating
        {
            get => _disableClanPartiesEating;
            set
            {
                if (_disableClanPartiesEating == value) return;
                _disableClanPartiesEating = value;
                OnPropertyChanged();
            }
        }
    }
}

#endif