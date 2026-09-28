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

namespace MozijegyFoglaloWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inputBtnBooking_Click(object sender, RoutedEventArgs e)
        {
            if (!isNameValid()) { return; }
            if (!isAgeValid()) { return; }
            if (!isMoviePicked()) { return; }
            if (!isTicketChosen()) { return; }
            if (!isTicketNumberValid()) { return; }
            if (!areTermsAccepted()) { return; }

            int price = 0;
            int ticketAmount = Convert.ToInt32(inputTicketAmount.Text.Trim());
            int ticketNormal = 2500; int ticketStudent = 1900; int ticketVip = 4000;
            int ticketMulti = 0;
            int extraPopcorn = 1200; int extraDrink = 800; int extra3dGlasses = 500;
            int extras = 0;
            if (inputRbNormalTicket.IsChecked == true){ticketMulti = ticketNormal;}
            if (inputRbStudentTicket.IsChecked == true){ticketMulti = ticketStudent;}
            if (inputRbVipTicket.IsChecked == true){ticketMulti = ticketVip;}
            if (inputChkbPopcorn.IsChecked == true){extras += extraPopcorn;}
            if (inputChkbDrink.IsChecked == true){extras += extraDrink;}
            if (inputChkb3dGlasses.IsChecked == true){extras -= extra3dGlasses;}
            price = ticketAmount * ticketMulti + extras;
        }

        private bool isNameValid()
        {
            string name = inputName.Text.Trim();
            if (name == "")
            {
                MessageBox.Show
                (
                    "A név mező nem lehet üres!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            if (name.Length < 3)
            {
                MessageBox.Show
                (
                    "A névnek legalább 3 karakter hosszúnak kell lennie!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            return true;
        }
        private bool isAgeValid()
        {
            try
            {
                int age = Convert.ToInt32(inputAge.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show
                (
                    "Az életkornak számnak kell lennie!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            if (Convert.ToInt32(inputAge.Text.Trim()) <= 0)
            {
                MessageBox.Show
                (
                    "Az életkornak nagyobbnak kell lennie mint 0!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            if (Convert.ToInt32(inputAge.Text.Trim()) > 120)
            {
                MessageBox.Show
                (
                    "Az életkornak nem lehet nagyobb mint 120!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            return true;
        }
        private bool isMoviePicked()
        {
            if (inputCmbMovie.SelectedItem == null)
            {
                MessageBox.Show
                (
                    "Nincsen film kiválasztva!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            return true;
        }
        private bool isTicketChosen()
        {
            if 
            (inputRbNormalTicket.IsChecked == false &&
            inputRbStudentTicket.IsChecked == false &&
            inputRbVipTicket.IsChecked == false
            )
            {
                MessageBox.Show
                (
                    "Nincsen jegytípus kiválasztva!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            return true;
        }
        private bool isTicketNumberValid()
        {
            try
            {
                int num = Convert.ToInt32(inputTicketAmount.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show
                (
                    "A jegyek mennyiségének számnak kell lennie!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            if (Convert.ToInt32(inputTicketAmount.Text.Trim()) <= 0)
            {
                MessageBox.Show
                (
                    "A jegyek számának legalább 1-nek kell lennie!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            if (Convert.ToInt32(inputTicketAmount.Text.Trim()) > 10)
            {
                MessageBox.Show
                (
                    "A jegyek száma nem haladhatja meg a 10-et!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }
            return true;
        }
        private bool areTermsAccepted()
        {
            if (inputChkbTerms.IsChecked == false)
            {
                MessageBox.Show
                (
                    "A vásárlási feltételeket el kell fogadnia!",
                    "Hiba történt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
            return true;
        }

    }
}