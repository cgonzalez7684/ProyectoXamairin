using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil
{
    struct Credito
    {
        public string IdOperacion { get; set; }
        public double Saldo { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListadoCreditos : ContentPage
	{
        List<Credito> OperaEnca;
        public ListadoCreditos ()
		{
			InitializeComponent ();
            OperaEnca = new List<Credito>();
            
            foreach (Entidades.InfoOperacion item in App.objCliente.Operaciones)
            {
                Credito obj = new Credito();
                obj.IdOperacion = item.Operacion;
                obj.Saldo = item.SaldoActual;
                OperaEnca.Add(obj);
            }
            LstOperaciones.ItemsSource = OperaEnca;
        }
	}
}