using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.ViewModel
{
    public partial class NotificationViewModel : ObservableRecipient
    {
        [ObservableProperty]
        public string notificationText;
    }
}
