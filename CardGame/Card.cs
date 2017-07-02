using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using System.Windows.Forms;

namespace CardGame
{
    public class Card
    {


        private int cardID = -1;
        private static Card deckCard;
        private static Point player1 = new Point(200, 600);
        private static ArrayList cards = new ArrayList();
        public int CardID { get => cardID; set => cardID = value; }
        public static Card DeckCard { get => deckCard; set => deckCard = value; }



        public Card(int cardID)
        {
            Button b = new Button();
            this.CardID = cardID;
            b = new Button();
            b.Height = 140;
            b.Width = 100;
            b.Cursor = Cursors.Hand;
            b.Location = player1;
            b.Name = CardID + "";
            player1.X += 20;
            b.BackgroundImage = new Bitmap(@"D:\Sebastian\OneDrive\Visual Studio\CardGame\CardGame\Cards\" + CardID + ".jpg");
            b.BackgroundImageLayout = ImageLayout.Stretch;

            b.Click += new EventHandler(CardBtn_Click);

            Form1.ActiveForm.Controls.Add(b);
            cards.Add(b);
        }


        public String getCardName()
        {//Abfrage des Titels mithilfe der KartenID
            String[] cardIndex = new String[] {
            "Herz-Ass","Herz-2","Herz-3","Herz-4","Herz-5","Herz-6","Herz-7","Herz-8","Herz-9","Herz-10","Herz-Bube","Herz-Dame","Herz-König",
            "Karo-Ass","Karo-2","Karo-3","Karo-4","Karo-5","Karo-6","Karo-7","Karo-8","Karo-9","Karo-10","Karo-Bube","Karo-Dame","Karo-König",
            "Kreuz-Ass","Kreuz-2","Kreuz-3","Kreuz-4","Kreuz-5","Kreuz-6","Kreuz-7","Kreuz-8","Kreuz-9","Kreuz-10","Kreuz-Bube","Kreuz-Dame","Kreuz-König",
            "Pik-Ass","Pik-2","Pik-3","Pik-4","Pik-5","Pik-6","Pik-7","Pik-8","Pik-9","Pik-10","Pik-Bube","Pik-Dame","Pik-König",
            };
            return cardIndex[CardID];
        }


        public static void cardToDeck(Card c)
        {
            //entferne alte Stapelkarte falls sie existiert
            if (DeckCard != null)
            {
                Form1.ActiveForm.Controls.Remove(listItem(IDToList(DeckCard.CardID)));
            }
            deckCard = c;
            cards.Remove(deckCard);
            listItem(IDToList(c.CardID)).Click -= new EventHandler(c.CardBtn_Click);
            moveCard(new Point(700, 200), c.cardID);
            update();
        }


        private void CardBtn_Click(object sender, EventArgs e)
        {
            if (cardCompare(this, DeckCard))
            {
                cardToDeck(this);
            }
        }


        private static int IDToList(int i)
        {
            for (int k = 0; k <= cards.Count; k++)
            {
                if (listItem(k).Name == i + "")
                {
                    return k;
                }
            }
            return -1;

        }


        private static Button listItem(int k)
        {
            return (Button)cards[k];
        }


        private bool cardCompare(Card c1, Card c2)
        {
            return c1.getCardName().Substring(0, 2) == c2.getCardName().Substring(0, 2) || ((c1.CardID % 13) == (c2.CardID % 13));
        }


        public static void moveCard(Point p, int i)
        {
            Button b = (Button)cards[IDToList(i)];
            b.Location = p;
        }


        public static void update()
        {
            int x = 200;
            foreach (Button b in cards)
            {
                try
                {
                    if (b.Location.Y == 600)
                    {

                        b.Location = new Point(x, 600);
                        x += 20;
                    }
                }
                catch { }
            }
            player1.X = x;

        }
    }
}

