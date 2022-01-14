using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinecraftFarmMaterialHelp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string ConvertMcStacks (int amount)
        {
            string result;
            int leftOver = 0;
            int stacks = 0;

            while (amount > 64)
            {
                stacks++;
                amount = amount - 64;
            }
            leftOver = amount;

            if (leftOver == 64)
            {
                stacks++;
                leftOver = 0;
            }

            result = $"Stacks: {stacks} / {leftOver}";

            return result;
        }

        private void comboBoxBlock_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>(); // 14
            data.Add("Hopper");
            data.Add("Piston");
            data.Add("Observer");
            data.Add("RS-Repeater");
            data.Add("RS-Comperator");
            data.Add("Dispenser");
            data.Add("Dropper");
            data.Add("Lectern");
            data.Add("Lever");
            data.Add("RS-Lamp");
            data.Add("Noteblock");
            data.Add("Target");
            data.Add("DL-Detector");
            data.Add("Chest");


            var combo = sender as ComboBox;
            combo.ItemsSource = data;
        }

        private void comboBoxBlock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboItem = sender as ComboBox;
            string item = selectedComboItem.SelectedItem as string;
        }

        private void btnGetItemBlocks_Click(object sender, RoutedEventArgs e)
        {
            string item, result, newline;
            int amount;

            newline = Environment.NewLine;
            result = "Invalid";
            item = comboBoxBlock.Text;


            bool tryParseSuccess = int.TryParse(txtItemAmount.Text, out amount);
            if (tryParseSuccess)
            {
                switch (item)
                {
                    case "Piston":
                        result = $"Planks: {ConvertMcStacks(3 * amount)}{newline}Cobblestone: {ConvertMcStacks(4 * amount)}{newline}Iron Ingot: {ConvertMcStacks(amount)}{newline}Redstone Dust: {ConvertMcStacks(amount)}";
                        break;

                    case "Observer":
                        result = $"Redstone Dust: {ConvertMcStacks(2 * amount)}{newline}Quartz: {ConvertMcStacks(amount)}{newline}Cobblestone: {ConvertMcStacks(6 * amount)}";
                        break;



                    case "RS-Repeater":
                        result = $"Stone: {ConvertMcStacks(3 * amount)}{newline}Redstone Torch: {ConvertMcStacks(2 * amount)}{newline}Redstone Dust: {ConvertMcStacks(amount)}";
                        break;



                    case "RS-Comperator":
                        result = $"Stone: {ConvertMcStacks(3 * amount)}{newline}Quartz: {ConvertMcStacks(amount)}{newline}Redstone Torch: {ConvertMcStacks(3 * amount)}";
                        break;



                    case "Hopper":
                        result = $"Iron Ingot: {ConvertMcStacks(amount * 5)}{newline}Chest: {ConvertMcStacks(amount)}";
                        break;


                    case "Dispenser":
                        result = $"Cobblestone: {ConvertMcStacks(amount * 7)}{newline}Redstone Dust: {ConvertMcStacks(amount)}{newline}Bow: {ConvertMcStacks(amount)}";
                        break;




                    case "Dropper":
                        result = $"Cobblestone: {ConvertMcStacks(amount * 7)}{newline}Redstone Dust: {ConvertMcStacks(amount)}";
                        break;


                    case "Lectern":
                        result = $"Wood Slabs: {ConvertMcStacks(amount * 4)}{newline}Book Shelf: {ConvertMcStacks(amount)}";
                        break;



                    case "Target":
                        result = $"Hay Bale: {ConvertMcStacks(amount)}{newline}Redstone Dust: {ConvertMcStacks(amount * 4)}";
                        break;



                    case "Lever":
                        result = $"Cobblestone: {ConvertMcStacks(amount)}{newline}Sticks: {ConvertMcStacks(amount)}";
                        break;





                    case "DL-Sensor":
                        result = $"Glass: {ConvertMcStacks(amount * 3)}{newline}Quartz: {ConvertMcStacks(amount * 3)}{newline}Wood Slabs: {ConvertMcStacks(amount * 3)}";
                        break;



                    case "RS-Lamp":
                        result = $"Glowstone: {ConvertMcStacks(amount)}{newline}Redstone Dust: {ConvertMcStacks(amount * 4)}";
                        break;






                    case "Noteblock":
                        result = $"Planks: {ConvertMcStacks(amount * 8)}{newline}Redstone Dust: {ConvertMcStacks(amount)}";
                        break;











                    case "Chest":
                        result = $"Planks: {ConvertMcStacks(amount * 8)}";
                        break;


                    default:
                        result = "Invalid item";
                        break;
                
                }





            }

            MessageBox.Show(result, "Result");


        }
    }
}
