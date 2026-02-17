using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LoLAPI;

namespace WPFLoLAPI
{
    /// <summary>
    /// Interaction logic for ChampionInfoWindow.xaml
    /// </summary>
    public partial class ChampionInfoWindow : Window
    {
        public ChampionInfoWindow(Champion selectedChampion)
        {
            InitializeComponent();
            if (selectedChampion != null)
            {
                
                this.Title = $"{selectedChampion.Name} Részletei";

                TxtName.Text = selectedChampion.Name;
                TxtTitle.Text = selectedChampion.Title;
                TxtBlurb.Text = selectedChampion.Blurb;

                if (selectedChampion.Info != null)
                {
                    TxtAttack.Text = $"Támadás: {selectedChampion.Info.Attack}";
                    TxtDefense.Text = $"Védekezés: {selectedChampion.Info.Defense}";
                }

                if (selectedChampion.Tags != null)
                {
                    TxtTags.Text = $"Kategória: {string.Join(", ", selectedChampion.Tags)}";
                }
            }
        }
    }
}
