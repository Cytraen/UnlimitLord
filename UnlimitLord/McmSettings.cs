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

        private int _numOfCompanions = -1;
        private int _numOfParties = -1;
        private int _partySize = -1;
        private int _numOfPrisoners = -1;
        private int _numOfWorkshops = -1;
        private bool _disableClanPartiesEating = false;
        private bool _disableItemWeight = false;

        [SettingPropertyInteger("Max. Number of Companions", -1, 1000000, Order = 1, RequireRestart = false, HintText = "-1 will disable this setting.")]
        public int NumOfCompanions
        {
            get => _numOfCompanions;
            set
            {
                if (_numOfCompanions == value) return;
                _numOfCompanions = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyInteger("Max. Number of Parties in Clan", -1, 1000000, Order = 2, RequireRestart = false, HintText = "-1 will disable this setting.")]
        public int NumOfParties
        {
            get => _numOfParties;
            set
            {
                if (_numOfParties == value) return;
                _numOfParties = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyInteger("Max. Party Size", -1, 1000000, Order = 3, RequireRestart = false, HintText = "-1 will disable this setting.")]
        public int PartySize
        {
            get => _partySize;
            set
            {
                if (_partySize == value) return;
                _partySize = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyInteger("Max. Number of Prisoners", -1, 1000000, Order = 4, RequireRestart = false, HintText = "-1 will disable this setting.")]
        public int NumOfPrisoners
        {
            get => _numOfPrisoners;
            set
            {
                if (_numOfPrisoners == value) return;
                _numOfPrisoners = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyInteger("Max. Number of Workshops", -1, 1000000, Order = 5, RequireRestart = false, HintText = "-1 will disable this setting.")]
        public int NumOfWorkshops
        {
            get => _numOfWorkshops;
            set
            {
                if (_numOfWorkshops == value) return;
                _numOfWorkshops = value;
                OnPropertyChanged();
            }
        }

        [SettingPropertyBool("Disable Party Food Consumption", Order = 6, RequireRestart = false)]
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

        [SettingPropertyBool("All Items Weightless", Order = 7, RequireRestart = false)]
        public bool DisableItemWeight
        {
            get => _disableItemWeight;
            set
            {
                if (_disableItemWeight == value) return;
                _disableItemWeight = value;
                OnPropertyChanged();
            }
        }
    }
}

#endif