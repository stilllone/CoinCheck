using CommunityToolkit.Mvvm.ComponentModel;

namespace CoinCheck.ViewModel
{
    public partial class NotificationViewModel : ObservableRecipient
    {
        [ObservableProperty]
        public string notificationText;
    }
}
