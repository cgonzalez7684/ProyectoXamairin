using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil
{
    struct Cred
    {
        public string IdOperacion { get; set; }
        public double Saldo { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreditosPage : ContentPage
	{
        List<Cred> OperaEnca;
		public CreditosPage ()
		{
            OperaEnca = new List<Cred>();

            foreach (Entidades.InfoOperacion item in App.objCliente.Operaciones)
            {
                Cred obj = new Cred();
                obj.IdOperacion = item.Operacion;
                obj.Saldo = item.SaldoActual;
                OperaEnca.Add(obj);
            }

            //listView.SetBinding(ListView.ItemsSourceProperty, new Binding();
            //listView = new ListView();
            listView.ItemsSource = OperaEnca;

            //var listView = new ListView();

            //listView.ItemsSource = new[] { "a", "b", "c" };
            //listView.ItemsSource = App.objCliente.Operaciones;
            //listView.ItemsSource = OperaEnca;



            // Using ItemTapped
            //listView.ItemTapped += async (sender, e) => {

            //    await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
            //    //Debug.WriteLine("Tapped: " + e.Item);
            //    ((ListView)sender).SelectedItem = null; // de-select the row
            //};

            // If using ItemSelected
            //listView.ItemSelected += (sender, e) =>
            //{
            //    if (e.SelectedItem == null) return;
            //    //Debug.WriteLine("Selected: " + e.SelectedItem);
            //    ((ListView)sender).SelectedItem = null; // de-select the row
            //};

            //Padding = new Thickness(0, 20, 0, 0);
            //Content = listView;
        }
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
            DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            //DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");

            //Debug.WriteLine("delete " + mi.CommandParameter.ToString());
           // OperaEnca.Remove(mi.CommandParameter.ToString());
        }

    }
}