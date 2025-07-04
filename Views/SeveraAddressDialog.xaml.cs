using System.Windows;

namespace HardwareInfoViewer.Views
{
    public partial class ServerAddressDialog : Window
    {
        public string ServerAddress { get; private set; } = "";

        public ServerAddressDialog()
        {
            InitializeComponent();
            ServerAddressTextBox.Focus();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string input = ServerAddressTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a valid server address.");
                return;
            }

            if (!input.StartsWith("http://") && !input.StartsWith("https://"))
            {
                input = "http://" + input;
            }

            if (!input.Contains(":"))
            {
                input += ":5000";
            }

            ServerAddress = input;

            this.DialogResult = true;
            this.Close();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}