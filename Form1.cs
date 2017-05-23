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
        decimal weekendOpslag = 1.15m;
        decimal uurKostenHoog = 0.45m;
        decimal prijsPerGeredenKilometer = 1.0m;        
        
        private void btnBereken_Click(object sender, EventArgs e)
        {
            int startUur = int.Parse(comboStartUur.Text);
            int eindUur = int.Parse(comboEindeUur.Text);            

            /** bepaling daltarief: alle dagen van de week tussen 800 en 1800 uur tegen € 0,25/ minuut + 1,00/km */
            bool daltarief = (((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Dinsdag") && (startUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Woensdag") && (startUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Donderdag") && (startUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Vrijdag") && (startUur >= 8) && (eindUur < 18)));

            /** bepaling hoogtarief: alle dagen van de week tussen 0.00 en 08.00 uur en tussen 18.00 en 0.00 uur tegen € 0,45/ minuut + 1,00/km, terwijl maandag en vrijdag afwijkende dagen zijn: maandag tussen 07.00 en 08.00 uur en tussen 18.00 en 0.00 en vrijdag tussen 0.00 en 08.00 en tussen 18.00 en 22.00 uur */
            bool maandagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur >= 7) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur >= 18) && (eindUur < 24)));
            bool dinsdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Dinsdag") && (startUur >= 0) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Dinsdag") && (startUur >= 18) && (eindUur < 24)));
            bool woensdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Woensdag") && (startUur >= 0) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Woensdag") && (startUur >= 18) && (eindUur < 24)));
            bool donderdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Donderdag") && (startUur >= 0) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Donderdag") && (startUur >= 18) && (eindUur < 24)));
            bool vrijdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Vrijdag") && (startUur >= 0) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Vrijdag") && (startUur >= 18) && (eindUur < 22)) || ((comboBoxDagVanDeWeek.Text == "Vrijdag") && ((startUur >= 18) && (startUur <22 )) && (eindUur < 24)));

            bool hoogtarief = ((maandagHoogTarief) || (dinsdagHoogTarief) || (woensdagHoogTarief) || (donderdagHoogTarief) || (vrijdagHoogTarief));

            /** bepaling daltarief weekend: zaterdag en zondag daltarief zoals hierboven + 15%*/

            bool daltariefZaterdagZondag= (((comboBoxDagVanDeWeek.Text == "Zaterdag") && (startUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Zondag") && (startUur >= 8) && (eindUur < 18)));

            /** bepaling hoogtarief weekend: zaterdag en zondag hoogtarief zoals hierboven + 15%*/
            bool zaterdagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Zaterdag") && (startUur >= 0) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Zaterdag") && (startUur >= 18) && (eindUur < 24)));
            bool zondagHoogTarief = (((comboBoxDagVanDeWeek.Text == "Zondag") && (startUur >= 0) && (eindUur < 8)) || ((comboBoxDagVanDeWeek.Text == "Zondag") && (startUur >= 18) && (eindUur < 24)));
            
            bool hoogtariefWeekend = ((zaterdagHoogTarief) || (zondagHoogTarief));

            /** bepaling combinatietarief: dinsdag woensdag donderdag conform voorbeeld 1: 1) rit van 01.00 - 10.00 */
            bool combiTariefDiWoDoStartVoorAchtEindTussenAchtEnZes = (((comboBoxDagVanDeWeek.Text == "Dinsdag") && (startUur < 8) && (eindUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Woensdag") && (startUur < 8) && (eindUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Donderdag") && (startUur < 8) && (eindUur >= 8) && (eindUur < 18)));

            /** bepaling combinatietarief: dinsdag woensdag donderdag conform voorbeeld 2: 2) rit van 01.00 - 20.00 3) rit van 09.00 - 20.00 */
            bool combiTariefDiWoDoStartVoorAchtEindNaAchtien = (((comboBoxDagVanDeWeek.Text == "Dinsdag") && (startUur < 8) && (eindUur > 8) && (eindUur >= 18)) || ((comboBoxDagVanDeWeek.Text == "Woensdag") && (startUur < 8) && (eindUur > 8) && (eindUur >= 18)) || ((comboBoxDagVanDeWeek.Text == "Donderdag") && (startUur < 8) && (eindUur > 8) && (eindUur >= 18)));

            /** bepaling combinatietarief: dinsdag woensdag donderdag conform voorbeeld 3: 3) rit van 09.00 - 20.00 */
            bool combiTariefDiWoDoStartTussenAchtEnZesEindNaAchtien = (((comboBoxDagVanDeWeek.Text == "Dinsdag") && (startUur >= 8) && (startUur < 18) && (eindUur >= 18)) || ((comboBoxDagVanDeWeek.Text == "Woensdag") && (startUur >= 8) && (startUur < 18) && (eindUur >= 18)) || ((comboBoxDagVanDeWeek.Text == "Donderdag") && (startUur >= 8) && (startUur < 18) && (eindUur >= 18)));

            /** bepaling combinatietarief: zaterdag en zondag conform voorbeeld 1: 1) rit van 01.00 - 10.00 */
            bool combiTariefZaZoStartVoorAchtEindTussenAchtEnZes = (((comboBoxDagVanDeWeek.Text == "Zaterdag") && (startUur < 8) && (eindUur >= 8) && (eindUur < 18)) || ((comboBoxDagVanDeWeek.Text == "Zondag") && (startUur < 8) && (eindUur >= 8) && (eindUur < 18)));

            /** bepaling combinatietarief: zaterdag en zondag conform voorbeeld 2: 2) rit van 01.00 - 20.00 3) rit van 09.00 - 20.00 */
            bool combiTariefZaZoStartVoorAchtEindNaAchtien = (((comboBoxDagVanDeWeek.Text == "Zaterdag") && (startUur < 8) && (eindUur > 8) && (eindUur >= 18)) || ((comboBoxDagVanDeWeek.Text == "Zondag") && (startUur < 8) && (eindUur > 8) && (eindUur >= 18)));

            /** bepaling combinatietarief: zaterdag en zondag conform voorbeeld 3: 3) rit van 09.00 - 20.00 */
            bool combiTariefZaZoStartTussenAchtEnZesEindNaAchtien = (((comboBoxDagVanDeWeek.Text == "Zaterdag") && (startUur >= 8) && (startUur < 18) && (eindUur >= 18)) || ((comboBoxDagVanDeWeek.Text == "Zondag") && (startUur >= 8) && (startUur < 18) && (eindUur >= 18)));
            
            /** bepaling combinatietarief: maandag start voor 07.00 's ochtends (opslag * 1.15) en eind tussen 08.00 en 18.00 (bijv. van 05.00 - 10.15) */
            bool combiTariefMaandagStartVoorZevenEindTussenAchtEnAchtien = (((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur < 7) && (eindUur >= 8) && (eindUur < 18)));

            /** bepaling combinatietarief: maandag start voor 07.00 's ochtends (opslag * 1.15) en eind na 18.00 (bijv. van 05.00 - 20.15) */
            bool combiTariefMaandagStartVoorZevenEindNaAchtien = (((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur < 7) && (eindUur > 8) && (eindUur > 18)));
                        
            /** bepaling combinatietarief: maandag start voor 07.00 's ochtends (opslag * 1.15) en eind voor 08.00 (bijv. van 05.00 - 07.15)*/
            bool combiTariefMaandagStartVoorZevenEindVoorAcht= (((comboBoxDagVanDeWeek.Text == "Maandag") && (startUur < 7) && (eindUur < 8)));
            


            /** bepaling combinatietarief: Vrijdag start 22.00 or later = opslag * 1.15 (bijv. van 22.15 - 23.30) */
            bool combiTariefVrijdagStartNaTienAvond = ((comboBoxDagVanDeWeek.Text == "Vrijdag") && (startUur >= 22));
                        
            if (textStartMinuutInvoer.Text == "" || textEindetMinuutInvoer.Text == "" || textAantalKilometersInvoer.Text == "")
            {
                textBoxFoutUitvoer.Text = "foutieve invoer: geef zowel het aantal startminuten als het aantal eindminuten en de gereden kilometers op";
                textTotaleKostenRitUitvoer.Text = "";
            }
            else
            {
                bool succesVolleInput = (Decimal.TryParse(textStartMinuutInvoer.Text, out startMinutenInput)) && (Decimal.TryParse(textEindetMinuutInvoer.Text, out eindMinutenInput)) && (int.TryParse(textAantalKilometersInvoer.Text, out kilometersInput));

                decimal kostenTijdUurStartVoorAcht = 8m - startUur;
                decimal kostenTijdUurEindVoorAcht = 8m - eindUur;
                decimal kostenTijdUurStartTussenAchtEnAchtien = 18 - startUur;
                decimal kostenTijdUurEindTussenAchtEnAchtien = eindUur - 8m;
                decimal kostenTijdUurEindNaAchtien = eindUur - 18m;

                decimal startMinutenInputVoorAcht = startMinutenInput * uurKostenHoog;
                decimal startMinutenInputTussenAchtEnAchtien = startMinutenInput * uurKostenDal;
                decimal eindMinutenInputTussenZesEnAcht = eindMinutenInput * uurKostenDal;

                if (succesVolleInput)
                {
                    if (startMinutenInput >= 60 || eindMinutenInput >= 60)
                    {
                        textBoxFoutUitvoer.Text = "foutieve invoer: geef het juiste aantal startminuten en eindminuten op";
                        textTotaleKostenRitUitvoer.Text = "";
                    }
                    else if (int.Parse(comboStartUur.Text) > int.Parse(comboEindeUur.Text) || ((int.Parse(comboStartUur.Text) == int.Parse(comboEindeUur.Text) && startMinutenInput > eindMinutenInput)))
                    {
                        textBoxFoutUitvoer.Text = "foutieve invoer: startijd rit ligt na eindtijd rit";
                        textTotaleKostenRitUitvoer.Text = "";
                    }
                    else if (daltarief)
                    {
                        kostenTijdMinuten = (eindMinutenInput - startMinutenInput) * uurKostenDal;
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer;
                        kostenTijdUur = (eindUur - startUur) * 60 * uurKostenDal;
                        totaleKosten = kostenTijdUur + kostenTijdMinuten + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (hoogtarief)
                    {
                        kostenTijdMinuten = (eindMinutenInput - startMinutenInput) * uurKostenHoog;
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer;
                        kostenTijdUur = (eindUur - startUur) * 60 * uurKostenHoog;
                        totaleKosten = kostenTijdUur + kostenTijdMinuten + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (daltariefZaterdagZondag)
                    {
                        kostenTijdMinuten = (eindMinutenInput - startMinutenInput) * (uurKostenDal * weekendOpslag);
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer * weekendOpslag;
                        kostenTijdUur = (eindUur - startUur) * 60 * (uurKostenDal * weekendOpslag);
                        totaleKosten = kostenTijdUur + kostenTijdMinuten + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (hoogtariefWeekend)
                    {
                        kostenTijdMinuten = (eindMinutenInput - startMinutenInput) * (uurKostenHoog * weekendOpslag);
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer * weekendOpslag;
                        kostenTijdUur = (eindUur - startUur) * 60 * (uurKostenHoog * weekendOpslag);
                        totaleKosten = kostenTijdUur + kostenTijdMinuten + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefDiWoDoStartVoorAchtEindTussenAchtEnZes)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer;
                        kostenTijdUur = (((kostenTijdUurStartVoorAcht * uurKostenHoog) + (kostenTijdUurEindTussenAchtEnAchtien * uurKostenDal)) * 60);
                        totaleKosten = kostenTijdUur + eindMinutenInputTussenZesEnAcht - startMinutenInputVoorAcht + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefDiWoDoStartVoorAchtEindNaAchtien)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer;
                        kostenTijdUur = (((kostenTijdUurStartVoorAcht * uurKostenHoog) + (kostenTijdUurEindNaAchtien * uurKostenHoog)) * 60) + 150m;
                        totaleKosten = kostenTijdUur + (eindMinutenInput * uurKostenHoog) - startMinutenInputVoorAcht + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefDiWoDoStartTussenAchtEnZesEindNaAchtien)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer;
                        kostenTijdUur = (((kostenTijdUurStartTussenAchtEnAchtien * uurKostenDal) + (kostenTijdUurEindNaAchtien * uurKostenHoog)) * 60);
                        totaleKosten = kostenTijdUur + (eindMinutenInput * uurKostenHoog) - startMinutenInputTussenAchtEnAchtien + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefZaZoStartVoorAchtEindTussenAchtEnZes || combiTariefMaandagStartVoorZevenEindTussenAchtEnAchtien)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer * weekendOpslag;
                        kostenTijdUur = (((kostenTijdUurStartVoorAcht * uurKostenHoog) + (kostenTijdUurEindTussenAchtEnAchtien * uurKostenDal)) * 60 * weekendOpslag);
                        totaleKosten = kostenTijdUur + ((eindMinutenInputTussenZesEnAcht - startMinutenInputVoorAcht) * weekendOpslag) + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefZaZoStartVoorAchtEindNaAchtien || combiTariefMaandagStartVoorZevenEindNaAchtien)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer * weekendOpslag;
                        kostenTijdUur = (((((kostenTijdUurStartVoorAcht * uurKostenHoog) + (kostenTijdUurEindNaAchtien * uurKostenHoog)) * 60) + 150m) * weekendOpslag);
                        totaleKosten = kostenTijdUur + (((eindMinutenInput * uurKostenHoog) - (startMinutenInputVoorAcht)) * weekendOpslag) + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefZaZoStartTussenAchtEnZesEindNaAchtien)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer * weekendOpslag;
                        kostenTijdUur = (((kostenTijdUurStartTussenAchtEnAchtien * uurKostenDal) + (kostenTijdUurEindNaAchtien * uurKostenHoog)) * 60 * weekendOpslag);
                        totaleKosten = kostenTijdUur + (((eindMinutenInput * uurKostenHoog) - (startMinutenInputTussenAchtEnAchtien)) * weekendOpslag) + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefMaandagStartVoorZevenEindVoorAcht)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer * weekendOpslag;
                        kostenTijdUur = (((kostenTijdUurStartVoorAcht * uurKostenHoog) - (kostenTijdUurEindVoorAcht * uurKostenHoog)) * 60 * weekendOpslag);
                        totaleKosten = kostenTijdUur + ((eindMinutenInput - startMinutenInput) * uurKostenHoog * weekendOpslag) + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
                    }
                    else if (combiTariefVrijdagStartNaTienAvond)
                    {
                        kostenKilometers = kilometersInput * prijsPerGeredenKilometer * weekendOpslag;
                        kostenTijdUur = (eindUur - startUur) * 60 * (uurKostenHoog * weekendOpslag);
                        totaleKosten = kostenTijdUur + ((eindMinutenInput - startMinutenInput) * uurKostenHoog * weekendOpslag) + kostenKilometers;
                        textTotaleKostenRitUitvoer.Text = totaleKosten.ToString("C");
                        textBoxFoutUitvoer.Text = "";
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
