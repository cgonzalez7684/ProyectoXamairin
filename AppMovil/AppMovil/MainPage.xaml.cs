﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AppMovil
{
    public partial class MainPage : ContentPage
    {

        public Entidades.InfoCliente objCliente { get; set; }

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            BtnConsultar.Command = new Command(() =>
            {
                CargarInfoCliente();

            });

            //BtnConsultar.Clicked += BtnConsultar_Clicked;

            TxtCed.Focused += TxtCed_Focused;
        }

        private void BtnConsultar_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new CreditosPage());
            
        }

        private void TxtCed_Focused(object sender, FocusEventArgs e)
        {
            TxtCed.Text = string.Empty;
            TxtAsociado.Text = string.Empty;
            TxtInstitucion.Text = string.Empty;
            TxtNCred.Text = string.Empty;
            TxtNAh.Text = string.Empty;
            TxtCategoria.Text = string.Empty;
            TxtCPC.Text = string.Empty;
            TxtCPH.Text = string.Empty;
        }

        private async void CargarInfoCliente()
        {
            try
            {
                if (TxtCed.Text.Length <= 0)
                {
                    await DisplayAlert("Validación","Debe ingrear una identificación","Continuar");
                    return;
                }
                var data = await App.Servicio.GetStringAsync(TxtCed.Text);
                if (data == null)
                {
                    await DisplayAlert("Validación", "Identificación no encontrada", "Continuar");
                    TxtCed.Focus();
                    return;
                }
                objCliente = data[0];
                if (objCliente.NombreCliente.Length <= 0)
                {
                    await DisplayAlert("Validación", "Identificación no encontrada", "Continuar");
                    TxtCed.Focus();
                    return;
                }
                TxtAsociado.Text = objCliente.NombreCliente;
                TxtInstitucion.Text = objCliente.Institucion;
                TxtAfiliacion.Text = objCliente.Afiliacion.ToShortDateString();
                TxtFidelidad.Text = objCliente.Fidelidad.ToString();
                TxtNCred.Text = objCliente.NumCreditos.ToString();
                TxtNAh.Text = objCliente.NumAhorros.ToString();
                TxtNIv.Text = objCliente.NumInversiones.ToString();
                TxtCategoria.Text = objCliente.CatSugef;
                TxtCPC.Text = objCliente.Cpc.ToString();
                TxtCPH.Text = objCliente.Cph.ToString();

                //Debug.WriteLine(data[0]);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ha ocurrido un error", ex.Message, "Continuar");
            }
        } 
    }
}
