﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PadronApi.Dto;
using PadronApi.Model;

namespace Organismos
{
    /// <summary>
    /// Interaction logic for ListaOrganismos.xaml
    /// </summary>
    public partial class ListaOrganismos : UserControl
    {

        public ObservableCollection<Organismo> CatalogoOrganismo;
        public Organismo SelectedOrganismo;

        public ListaOrganismos()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CatalogoOrganismo = new OrganismoModel().GetOrganismos();
            GOrganismos.DataContext = CatalogoOrganismo;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String tempString = ScjnUtilities.StringUtilities.PrepareToAlphabeticalOrder( ((TextBox)sender).Text);

            if (!String.IsNullOrEmpty(tempString))
                GOrganismos.DataContext = (from n in CatalogoOrganismo
                                          where n.OrganismoStr.Contains(tempString) 
                                          select n).ToList();
            else
                GOrganismos.DataContext = CatalogoOrganismo;
        }

        private void GOrganismos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedOrganismo = GOrganismos.SelectedItem as Organismo;
        }
    }
}
