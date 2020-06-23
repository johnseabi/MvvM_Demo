using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvM_Demo.ViewModels
{
    public class AddContactViewModel : INotifyPropertyChanged
    {

        public AddContactViewModel()
        {
                
        }

        public AddContactViewModel(string name, string website, bool bestFriend, bool isBusy)
        {
            this.Name = name;
            this.Website = website;
            this.BestFriend = bestFriend;
            this.IsBusy = isBusy;
        }

        string name = "John Seabi";
        string website = "https://www.google.com";
        bool bestFriend, isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Website
        {
            get => website;
            set
            {
                website = value;
                OnPropertyChanged();
            }
        }

        public bool BestFriend
        {
            get => bestFriend;
            set
            {
                bestFriend = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public bool IsBusy { get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));

            }
        }

        public string DisplayMessage()
        {

            return $"Your new friend is named {Name} and" + $"{(bestFriend ? "is" : "is not")} your best friend";
        }

        void LaunchWebsite()
        {
            try
            {
                Device.OpenUri(new Uri(website));
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task SaveContact()
        {
            isBusy = true;
            await Task.Delay(4000);

            isBusy = false;

            await Application.Current.MainPage.DisplayAlert("Save", "Save the contact", "OK", "Cancel");

        }
    }
}
