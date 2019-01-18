using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page11 : ContentPage
	{
		public Page11 ()
		{
			InitializeComponent ();
            BtnVolver.Clicked += ClickVolver;
		}

        void ClickVolver(object sr, EventArgs ev)
        {
            Navigation.PopAsync();
        }
	}
}