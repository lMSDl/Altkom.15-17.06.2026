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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dices.Controls
{
    /// <summary>
    /// Interaction logic for DiceButtonControl.xaml
    /// </summary>
    public partial class DiceButtonControl : Button
    {
        public DiceButtonControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty NumberProperty = DependencyProperty.Register(
            nameof(Number),
            typeof(int),
            typeof(DiceButtonControl));

        public int Number
        {
            get => (int)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }

        public static DependencyProperty IsBlockedProperty = DependencyProperty.Register(
            nameof(IsBlocked),
            typeof(bool),
            typeof(DiceButtonControl));

        public bool IsBlocked
        {
            get => (bool)GetValue(IsBlockedProperty);
            set => SetValue(IsBlockedProperty, value);
        }

    }
}
