using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       


        int HandCount = 8;
        int CardsLeft = 51;
        Random Rnd = new Random();
        ArrayList Cards = new ArrayList();



        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = true;
            button2.Visible = true;
            
            startGame();

            //Für ein Resize von Bitmaps
           //for(int i = 1; i < 53; i++)
           //Card.resizeBitmap(new Bitmap(@"D:\Sebastian\OneDrive\Visual Studio\CardGame\CardGame\" + i + ".jpg"), i);

        }
    

        private void startGame()
        {   //Deck wird aufgefüllt
            for (int i = 0; i < 52; i++)
            {
                Cards.Add(i);
            }
            //StapelKarte wird festgelegt und Spieler erhält Handkarte
            Card firstCard = new Card(getCard());
            Card.cardToDeck(firstCard);
            for (int i = 0; i < HandCount; i++)
            {
                Card c = new Card(getCard());

            }
        }


        private int getCard()
        {//Zufällige Karte wird aus der Liste gezogen
            int k = -1;
            try{
                k = (int)Cards[Rnd.Next(1, CardsLeft--)]; 
            }
            catch
            { //Deck wird neu aufgefüllt
                for (int i = 0; i < 52; i++)
                {
                    Cards.Add(i);
                }
                CardsLeft = 51;
                k = (int)Cards[Rnd.Next(1, CardsLeft--)];
              
            }
            Cards.Remove(k);
            return k;

        }
 

        private void button2_Click(object sender, EventArgs e)
        {   
            Card c = new Card(getCard());
        }


    }
    }
