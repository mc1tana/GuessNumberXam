using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessNumber.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayPage : ContentPage
    {
        Random random = new Random();
        int magicNum;
       
        int life = 5;
        
        public PlayPage()
        {
            InitializeComponent();
            magicNum = random.Next(1, 20);
        }
        
        private void TryGuess(object sender, EventArgs e)
        {
            indice.Text = magicNum.ToString();
            if (/* int.TryParse(Num.Text, out n) */ isConvetible(Num.Text))
            {
                if (ValidValue(Convert.ToInt32(Num.Text)))
                {
                    if (magicNum == Convert.ToInt32(Num.Text))
                    {
                        Navigation.PushAsync(new WinPage(Convert.ToInt32(Num.Text)));
                    }
                    else
                    {
                        life--;
                        if (magicNum < Convert.ToInt32(Num.Text)) { T.Text = "C'est plus petit!!!"; }
                        else
                        {
                            T.Text = "c'est plus grand !!!";

                        }
                    }
                }
                else { DisplayAlert("Erreur Saisi", "Veuillez Saisir un bombre compris entre 1 et 20!!!", "ok"); }
            } else { DisplayAlert("Erreur Saisi", "Veuillez Saisir un nombre!!!", "ok"); }
        }
       
        public bool isConvetible(string c)
        {
            try { 
                Convert.ToInt32(c);
                return true;
            }catch(Exception) { return false; };
        }
        public bool ValidValue(int val)
        {
                if(val>0 && val < 21)
            {
                return true;
            }else
                return false;
        }
    }
} 