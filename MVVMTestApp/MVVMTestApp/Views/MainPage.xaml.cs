using MVVMTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMTestApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            //BindingContext = new MainViewModel();
		}

        protected override void OnAppearing()
        {
            this.MainViewModel.Load();
        }
    }
}
