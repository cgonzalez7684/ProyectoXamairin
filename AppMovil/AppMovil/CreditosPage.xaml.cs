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
	public partial class CreditosPage : ContentPage
	{
		public CreditosPage ()
		{
			InitializeComponent ();
            var EstiloCaja = new Style(typeof(TxtCaja))
            {
                Setters = {
                      new Setter { Property = Entry.TextColorProperty, Value = Color.DarkBlue },
                      new Setter { Property = Entry.FontSizeProperty, Value = 20 },
                      new Setter { Property = Entry.HorizontalTextAlignmentProperty, Value = "Center" },
                      new Setter { Property = Entry.InputTransparentProperty, Value = true }
                    }

                //< Setter Property = "TextColor" Value = "DarkBlue" ></ Setter >
                //< Setter Property = "FontSize" Value = "Medium" ></ Setter >
                //< Setter Property = "HorizontalTextAlignment" Value = "Center" ></ Setter >
                //< Setter Property = "InputTransparent" Value = "True" ></ Setter >

            };

            var grid = new Grid() { RowSpacing = 2};
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(230) });

            var caja = new TxtCaja { Text = "CRED321444", Style = EstiloCaja };
            var caja2 = new TxtCaja { Text = "3500000", Style = EstiloCaja };
            var caja3 = new TxtCaja { Text = "CRED213432", Style = EstiloCaja };
            var caja4 = new TxtCaja { Text = "1000000", Style = EstiloCaja };

            grid.Children.Add(caja, 0, 0);
            grid.Children.Add(caja2, 1, 0);
            grid.Children.Add(caja3, 0, 1);
            grid.Children.Add(caja4, 1, 1);

            this.Content = grid;
        }
	}
}