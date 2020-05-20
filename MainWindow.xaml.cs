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

namespace kulko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //powinienem to jakos ladniej zrobic, ale program jest na tyle prosty, ze da sie polapac nawet jak wszystko jest w jednym pliku

        bool XO = false; //czyja jest tura (false - O true - X), ale tak naprawde to na odwrot ale to nie istotne

        //sprawdza czyja jest tura
        private string tura() //chcialem dac char ale wtedy zerojeden() nie dziala
        {
            XO = !XO; //zmienia kolko i krzyzyk na przemian
            if (XO)
                return "O";
            else
                return "X";
        }

        //przypisuje wartosci liczbowe O i X zeby sprawdzic czy ktos wygral
        private int zerojeden(Button a)
        {
            if (a.Content == "O") //niech sobie podkresla jak dam .ToString to nie dziala
                return -1;
            else if(a.Content == "X") //niech sobie podkresla jak dam .ToString to nie dziala
                return 1;
            return 0;
        }

        //wbrew nazwie nie konczy programu ale sprawdza czy ktos wygral
        //i jest zdecydowanie za dluga ale nie chcialo mi sie juz rozdzielac
        //prawdopodobnie lepiej by bylo po prostu wypisac wszystkie dziewiec mozliwosci manualnie
        private void koniec()
        {
            Button[,] buttonarray;
            buttonarray = new Button[3, 3]
            {
                { Button_00, Button_01, Button_02 }, 
                { Button_10, Button_11, Button_12 },
                { Button_20, Button_21, Button_22 }
            };

            //sprawdzanie poziomo
            for (int i = 0; i < 3; i++)
            {
                int wartosc = 0;
                for (int j = 0; j < 3; j++)
                    wartosc += zerojeden(buttonarray[i, j]);
                if (wartosc == -3)
                    MessageBox.Show("Wygrywa gracz O");
                else if (wartosc == 3)
                    MessageBox.Show("Wygrywa gracz X");
            }

            //sprawdzanie pionowo
            for (int i = 0; i < 3; i++)
            {
                int wartosc = 0;
                for (int j = 0; j < 3; j++)
                    wartosc += zerojeden(buttonarray[j, i]);
                if (wartosc == -3)
                    MessageBox.Show("Wygrywa gracz O");
                else if (wartosc == 3)
                    MessageBox.Show("Wygrywa gracz X");
            }

            //sprawdzanie ukosnie z lewy gora
            int wartoscukosna = 0; //przepraszam
            for (int i = 0; i < 3; i++)
            {
                wartoscukosna += zerojeden(buttonarray[i, i]);
            }
            if (wartoscukosna == -3)
                MessageBox.Show("Wygrywa gracz O");
            else if (wartoscukosna == 3)
                MessageBox.Show("Wygrywa gracz X");

            //sprawdzanie ukosnie z prawy gora
            wartoscukosna = 0; //to jest istotne wbrew temu co mowi visual studio
            wartoscukosna = zerojeden(buttonarray[0, 2]) + zerojeden(buttonarray[1, 1]) + zerojeden(buttonarray[2, 0]); //pewnie jest lepszy sposob, ale ten dziala
            if (wartoscukosna == -3)
                MessageBox.Show("Wygrywa gracz O");
            else if (wartoscukosna == 3)
                MessageBox.Show("Wygrywa gracz X");

            //sprawdzanie czy koniec ruchow
            int aktywnepola = 0;
            foreach (var item in buttonarray)
            {
                if (item.IsEnabled == true)
                    aktywnepola++;
            }
            if (aktywnepola == 0)
                MessageBox.Show("Remis");
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = tura(); //przypisuje do danego przycisku O albo X w zaleznosci do tego czyja jest tura
            ((Button)sender).IsEnabled = false; //blokuje przycisk, zeby nie dalo sie kliknac tego samego dwa razy
            koniec(); //sprawdza czy ktos wygral po kazdym ruchu
        }

    }
}
