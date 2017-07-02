/*using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    class Player
    {
        private int handCount;
        private Player(int handCount)
        {
            this.handCount = handCount;
        }
        public void giveCard()
        {   Card c1 = new Card()
            Button dynamicButton = new Button();
            dynamicButton.Height = 140;
            dynamicButton.Width = 80;
            dynamicButton.BackColor = Color.Red;
            dynamicButton.ForeColor = Color.White;
            dynamicButton.Location = new Point(cardLocation, 400);
            cardLocation += 90;
            dynamicButton.Text = Card.getCardName();

            dynamicButton.Name = getCardName();

            dynamicButton.Font = new Font("Georgia", 16);




            // Add Button to the Form. Placement of the Button

            // will be based on the Location and Size of button

            Form1.ActiveForm.Controls.Add(dynamicButton);
        }
    }
}
*/