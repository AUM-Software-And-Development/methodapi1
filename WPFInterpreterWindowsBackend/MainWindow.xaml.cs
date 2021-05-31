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

namespace WPFInterpreterWindowsBackend
{
    using CSharpInterpreterClasses.Containers.implementations;
    using CSharpInterpreterClasses.Analyzers;
    using CSharpInterpreterClasses.Instructions.implementations;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static HEAP_EventStorage eventStorage = new HEAP_EventStorage();
        private const int index = 0;

        private List<string> GetPOSTRequests()
        {
            List<string> newStrings = new List<string>();
            newStrings.Add(this.APIBox.Text);
            return newStrings;
            // Foreach newline in... / reminder to write method for
            // parsing for endpoints and user error correction later (stream serializat(io)n/server traffic queues)
        }

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "User Interface Interaction";
            this.APIBox.Text = "123456789/colorblue/234unassigned/$%&TEN";
            this.APIBox.TextWrapping = TextWrapping.Wrap;
            this.APIBox.ScrollToEnd();
            this.APIBox.AcceptsTab = true;
            this.APIBox.AcceptsReturn = true;
#if DEBUG
            this.Title += " [***DEBUG***]";
#endif
        }

        private void POSTBox_Click(object sender, RoutedEventArgs e)
        {
            bool testing = true;
            List<List<byte>> hostHistory = new List<List<byte>>();

            try
            {
                string return_release;
                return_release = eventStorage.AllocateStrings(this.GetPOSTRequests(), index);
                if (testing)
                {
                    List<string> add = new List<string>
                    {
                        "00000/TESTING/IO",
                        // TESTINGIO Sum =84+69+83+84+73+78+71+73+79= 694
                    };
                    eventStorage.AllocateStrings(add, index);
                    Lexer.RemoveNonEnglishValues(eventStorage.VolatileDecimalCommands, ref hostHistory);
                    string print = string.Empty;
                    foreach (List<byte> list in hostHistory)
                    {
                        foreach (byte byte_ in list)
                        {
                            print += (char)byte_;
                        }
                        print += "\x0a";
                    }
                    MessageBox.Show(print + "Write this a form. Press ok to continue.");

                    PublicMethodSetter availableMethods = new PublicMethodSetter();
                    availableMethods.AbstractMethod(availableMethods.ColorBlue, 694);
                    availableMethods.MethodJump(694);
                    
                    MessageBox.Show(availableMethods.Return);
                }
                else
                {
                    MessageBox.Show(return_release);
                }
                // Needs another window printing the memory space.
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
