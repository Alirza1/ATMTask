using AtmTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AtmTask.Commands;
using AtmTask.Models;

namespace TransferMoney.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                cardNumber = value;
            }

        }

        public List<User> Users { get; set; }


        private User user;

        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand InsertCardCommand { get; set; }
        public MainViewModel()
        {
            IsEnabled = false;
            User = new User();
            Users = new List<User>()
            {
                new User
                {
                     CardNumber="2342424824487428",
                     FullName="Alirza Zaidov",
                     Balance=5001.23
                },
                new User
                {
                    CardNumber="22333444444222245",
                    FullName="Ilkin Suleymanov",
                    Balance=2343.34
                },
                new User
                {
                    CardNumber="23423424478987878",
                    FullName = "Elvin Camalzade",
                    Balance = 14092.21
                }

            };
            
            InsertCardCommand = new RelayCommand((o) =>
            {
                IsEnabled = !IsEnabled;
            });

            LoadDataCommand = new RelayCommand((o) =>
                {
                    User = Users.FirstOrDefault((u) => { return u.CardNumber == CardNumber; });
                    if (User == null) MessageBox.Show("User not found");
                });
        }


    }
}