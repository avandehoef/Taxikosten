using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxikosten
{
    public partial class formTaxiKosten : Form
    {
        /**
        Een taxibedrijf hanteert het volgende tarief:
        
        Per gereden km € 1,=. 
        
        Daarboven een bedrag per gereden minuut: € 0,25 tussen 8.00 en 18.00 uur, 
        € 0,45 buiten deze periode.
        
        Van vrijdagavond 22.00 uur tot maandagochtend 7.00 uur worden de ritprijzen verhoogd 
        met een weekendtoeslag van 15%. 
        Deze toeslag wordt alleen toegepast als de rit begint in de genoemde periode.

        De te ontwikkelen software moet aan de hand van de ritgegevens de ritprijs berekenen. 
        Je mag er vanuit gaan dat een rit op één en dezelfde dag begint en eindigt.
         */

        public formTaxiKosten()
        {
            InitializeComponent();
        }

        private void formTaxiKosten_Load(object sender, EventArgs e)
        {
            comboBoxDagVanDeWeek.SelectedIndex = 0;
            comboStartUur.SelectedIndex = 0;
            comboEindeUur.SelectedIndex = 0;
        }

        decimal totaleKosten = 0m;
        decimal kostenTijdUur = 0m;
        decimal kostenTijdMinuten = 0m;
        decimal kostenKilometers = 0m;
        decimal startMinutenInput;
        decimal eindMinutenInput;
        int kilometersInput;
        decimal uurKostenDal = 0.25m;
        decimal uurKostenHoog = 0.45m;
        decimal prijsPerGeredenKilometer = 1.0m;
        
        private void btnBereken_Click(object sender, EventArgs e)
        {
            int startUur = int.Parse(comboStartUur.Text);
            int eindUur = int.Parse(comboEindeUur.Text);
            
            /** bepaling daltarief: alle dagen van de week tussen 800 en 1800 uur tegen € 0,25/ minuut + 1,00/km */
            bool daltarief = (((comboBoxDagVanDeWeek.Text == "Maandag") && (int.Parse(comboStartUur.Text) >= 8) && (int.Parse(comboEindeUur.Text) < 18)) || ((comboBoxDagVanDeWeek.Text == "Dinsdag") && (int.Parse(comboStartUur.Text) >= 8) && (int.Parse(comboEindeUur.Text) < 18)) || ((comboBoxDagVanDeWeek.Text == "Woensdag") && (int.Parse(comboStartUur.Text) >= 8) && (int.Parse(comboEindeUur.Text) < 18)) || ((comboBoxDagVanDeWeek.Text == "Donderdag") && (int.Parse(comboStartUur.Text) >= 8) && (int.Parse(comboEindeUur.Text) < 18)) || ((comboBoxDagVanDeWeek.Text == "Vrijdag") && (int.Parse(comboStartUur.Text) >= 8) && (int.Parse(comboEindeUur.Text) < 18)));

            /** bepaling hoogtarief: alle dagen van de week tussen 0.00 en 08.00 uur en tussen 18.00 en 0.00 uur tegen € 0,45/ minuut + 1,00/km, terwijl maandag en vrijdag afwijkende dagen zijn: maandag tussen 07.00 en 08.00 uur en tussen 18.00 en 0.00 en vrijdag tussen 0.00 en 08.00 en tussen 18.00 en 22.00 uur */

            bool maandagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur >= 7) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur >= 18) && (eindUur < 24)));
            bool dinsdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Dinsdag") && (int.Parse(comboStartUur.Text) >= 0) && (int.Parse(comboEindeUur.Text) < 8)) || ((comboBoxDagVanDeWeek.Text == "Dinsdag") && (int.Parse(comboStartUur.Text) >= 18) && (int.Parse(comboEindeUur.Text) < 24)));
            bool woensdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Woensdag") && (int.Parse(comboStartUur.Text) >= 0) && (int.Parse(comboEindeUur.Text) < 8)) || ((comboBoxDagVanDeWeek.Text == "Woensdag") && (int.Parse(comboStartUur.Text) >= 18) && (int.Parse(comboEindeUur.Text) < 24)));
            bool donderdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Donderdag") && (int.Parse(comboStartUur.Text) >= 0) && (int.Parse(comboEindeUur.Text) < 8)) || ((comboBoxDagVanDeWeek.Text == "Donderdag") && (int.Parse(comboStartUur.Text) >= 18) && (int.Parse(comboEindeUur.Text) < 24)));
            bool vrijdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Vrijdag") && (int.Parse(comboStartUur.Text) >= 0) && (int.Parse(comboEindeUur.Text) < 8)) || ((comboBoxDagVanDeWeek.Text == "Vrijdag") && (int.Parse(comboStartUur.Text) >= 18) && (int.Parse(comboEindeUur.Text) < 22)));

            bool hoogtarief = ((maandagHoogTarief) || (dinsdagHoogTarief) || (woensdagHoogTarief) || (donderdagHoogTarief) || (vrijdagHoogTarief));


            if (textStartMinuutInvoer.Text == "" || textEindetMinuutInvoer.Text == "" || textAantalKilometersInvoer.Text == "")
            {
                textBoxFoutUitvoer.Text = "foutieve invoer: geef zowel het aantal startminuten als het aantal eindminuten en de gereden kilometers op";
                textTotaleKostenRitUitvoer.Text = "";
            }
            else
            {
                bool succesVolleInput = (Decimal.TryParse(textStartMinuutInvoer.Text, out startMinutenInput)) && (Decimal.TryParse(textEindetMinuutInvoer.Text, out eindMinutenInput)) && (int.TryParse(textAantalKilometersInvoer.Text, out kilometersInput));
                
                if (succesVolleInput == true)
                {
                    if (startMinutenInput >= 60 || eindMinutenInput >= 60)
                    {
                        textBoxFoutUitvoer.Text = "foutieve invoer: geef het juiste aantal startminuten en eindminuten op";
                        textTotaleKostenRitUitvoer.Text = "";
                    }
                    else
                    {
                        if (int.Parse(comboStartUur.Text) > int.Parse(comboEindeUur.Text) || ((int.Parse(comboStartUur.Text) == int.Parse(comboEindeUur.Text) && startMinutenInput > eindMinutenInput)))
                        {
                            textBoxFoutUitvoer.Text = "foutieve invoer: startijd rit ligt na eindtijd rit";
                            textTotaleKostenRitUitvoer.Text = "";
                        }
                        else
                        {
                            if (daltarief)
                            {
                                kostenTijdMinuten = (eindMinutenInput - startMinutenInput) * uurKostenDal;
                                kostenKilometers = kilometersInput * prijsPerGeredenKilometer;
                                kostenTijdUur = (Decimal.Parse(comboEindeUur.Text) - Decimal.Parse(comboStartUur.Text)) * 60 * uurKostenDal;
                                totaleKosten = kostenTijdUur + kostenTijdMinuten + kostenKilometers;
                                textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                                textBoxFoutUitvoer.Text = "";
                            }
                            else
                            {
                                if (hoogtarief)
                                {
                                    kostenTijdMinuten = (eindMinutenInput - startMinutenInput) * uurKostenHoog;
                                    kostenKilometers = kilometersInput * prijsPerGeredenKilometer;
                                    kostenTijdUur = (Decimal.Parse(comboEindeUur.Text) - Decimal.Parse(comboStartUur.Text)) * 60 * uurKostenHoog;
                                    totaleKosten = kostenTijdUur + kostenTijdMinuten + kostenKilometers;
                                    textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                                    textBoxFoutUitvoer.Text = "";
                                }
                            }
                        }
                    }
                }
                else
                {
                    textBoxFoutUitvoer.Text= ("foutieve invoer: geef alleen (hele) getallen op");
                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBoxDagVanDeWeek.SelectedIndex = 0;
            comboStartUur.SelectedIndex = 0;
            comboEindeUur.SelectedIndex = 0;
            textTotaleKostenRitUitvoer.Text = "";
            textBoxFoutUitvoer.Text = "";
            textAantalKilometersInvoer.Text = "";
            textStartMinuutInvoer.Text = "";
            textEindetMinuutInvoer.Text = "";

        }


        private void textVanafUur_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDagVanDeWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboStartUur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textVanafMinuten_TextChanged(object sender, EventArgs e)
        {

        }

        private void textStartMinuut_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textTotMinuten_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textEindetMinuutInvoer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
