namespace Taxikosten
{
    partial class formTaxiKosten
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTaxiKosten));
            this.comboBoxDagVanDeWeek = new System.Windows.Forms.ComboBox();
            this.textAlgemeen = new System.Windows.Forms.TextBox();
            this.textDag = new System.Windows.Forms.TextBox();
            this.textTijdVanaf = new System.Windows.Forms.TextBox();
            this.textVanafUur = new System.Windows.Forms.TextBox();
            this.comboStartUur = new System.Windows.Forms.ComboBox();
            this.textVanafMinuten = new System.Windows.Forms.TextBox();
            this.textStartMinuutInvoer = new System.Windows.Forms.TextBox();
            this.textEindetMinuutInvoer = new System.Windows.Forms.TextBox();
            this.textTotMinuten = new System.Windows.Forms.TextBox();
            this.comboEindeUur = new System.Windows.Forms.ComboBox();
            this.textTotUur = new System.Windows.Forms.TextBox();
            this.textTijdTot = new System.Windows.Forms.TextBox();
            this.textAantalKilometersInvoer = new System.Windows.Forms.TextBox();
            this.textAantalKilometers = new System.Windows.Forms.TextBox();
            this.textTotaleKosten = new System.Windows.Forms.TextBox();
            this.textTotaleKostenRitUitvoer = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBereken = new System.Windows.Forms.Button();
            this.textBoxFoutUitvoer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxDagVanDeWeek
            // 
            this.comboBoxDagVanDeWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDagVanDeWeek.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDagVanDeWeek.FormattingEnabled = true;
            this.comboBoxDagVanDeWeek.Items.AddRange(new object[] {
            "Maandag",
            "Dinsdag",
            "Woensdag",
            "Donderdag",
            "Vrijdag",
            "Zaterdag",
            "Zondag"});
            this.comboBoxDagVanDeWeek.Location = new System.Drawing.Point(199, 79);
            this.comboBoxDagVanDeWeek.Name = "comboBoxDagVanDeWeek";
            this.comboBoxDagVanDeWeek.Size = new System.Drawing.Size(194, 32);
            this.comboBoxDagVanDeWeek.TabIndex = 0;
            this.comboBoxDagVanDeWeek.SelectedIndexChanged += new System.EventHandler(this.comboBoxDagVanDeWeek_SelectedIndexChanged);
            // 
            // textAlgemeen
            // 
            this.textAlgemeen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textAlgemeen.Font = new System.Drawing.Font("Calibri", 12F);
            this.textAlgemeen.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textAlgemeen.Location = new System.Drawing.Point(13, 13);
            this.textAlgemeen.Name = "textAlgemeen";
            this.textAlgemeen.ReadOnly = true;
            this.textAlgemeen.Size = new System.Drawing.Size(485, 30);
            this.textAlgemeen.TabIndex = 1;
            this.textAlgemeen.TabStop = false;
            this.textAlgemeen.Text = "BEREKEN TAXIKOSTEN PER RIT";
            this.textAlgemeen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textDag
            // 
            this.textDag.BackColor = System.Drawing.SystemColors.Control;
            this.textDag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textDag.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDag.Location = new System.Drawing.Point(13, 79);
            this.textDag.Name = "textDag";
            this.textDag.ReadOnly = true;
            this.textDag.Size = new System.Drawing.Size(100, 25);
            this.textDag.TabIndex = 2;
            this.textDag.Text = "Dag";
            // 
            // textTijdVanaf
            // 
            this.textTijdVanaf.BackColor = System.Drawing.SystemColors.Control;
            this.textTijdVanaf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTijdVanaf.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTijdVanaf.Location = new System.Drawing.Point(12, 144);
            this.textTijdVanaf.Name = "textTijdVanaf";
            this.textTijdVanaf.ReadOnly = true;
            this.textTijdVanaf.Size = new System.Drawing.Size(101, 25);
            this.textTijdVanaf.TabIndex = 3;
            this.textTijdVanaf.Text = "Starttijd rit";
            // 
            // textVanafUur
            // 
            this.textVanafUur.BackColor = System.Drawing.SystemColors.Control;
            this.textVanafUur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textVanafUur.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVanafUur.Location = new System.Drawing.Point(155, 144);
            this.textVanafUur.Name = "textVanafUur";
            this.textVanafUur.ReadOnly = true;
            this.textVanafUur.Size = new System.Drawing.Size(38, 25);
            this.textVanafUur.TabIndex = 4;
            this.textVanafUur.Text = "Uur";
            this.textVanafUur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textVanafUur.TextChanged += new System.EventHandler(this.textVanafUur_TextChanged);
            // 
            // comboStartUur
            // 
            this.comboStartUur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStartUur.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStartUur.FormattingEnabled = true;
            this.comboStartUur.Items.AddRange(new object[] {
            "0 ",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.comboStartUur.Location = new System.Drawing.Point(199, 144);
            this.comboStartUur.Name = "comboStartUur";
            this.comboStartUur.Size = new System.Drawing.Size(91, 32);
            this.comboStartUur.TabIndex = 5;
            this.comboStartUur.SelectedIndexChanged += new System.EventHandler(this.comboStartUur_SelectedIndexChanged);
            // 
            // textVanafMinuten
            // 
            this.textVanafMinuten.BackColor = System.Drawing.SystemColors.Control;
            this.textVanafMinuten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textVanafMinuten.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVanafMinuten.Location = new System.Drawing.Point(310, 144);
            this.textVanafMinuten.Name = "textVanafMinuten";
            this.textVanafMinuten.ReadOnly = true;
            this.textVanafMinuten.Size = new System.Drawing.Size(79, 25);
            this.textVanafMinuten.TabIndex = 6;
            this.textVanafMinuten.Text = "Minuut";
            this.textVanafMinuten.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textVanafMinuten.TextChanged += new System.EventHandler(this.textVanafMinuten_TextChanged);
            // 
            // textStartMinuutInvoer
            // 
            this.textStartMinuutInvoer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textStartMinuutInvoer.Location = new System.Drawing.Point(396, 144);
            this.textStartMinuutInvoer.Name = "textStartMinuutInvoer";
            this.textStartMinuutInvoer.Size = new System.Drawing.Size(102, 32);
            this.textStartMinuutInvoer.TabIndex = 7;
            this.textStartMinuutInvoer.TextChanged += new System.EventHandler(this.textStartMinuut_TextChanged);
            // 
            // textEindetMinuutInvoer
            // 
            this.textEindetMinuutInvoer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEindetMinuutInvoer.Location = new System.Drawing.Point(395, 212);
            this.textEindetMinuutInvoer.Name = "textEindetMinuutInvoer";
            this.textEindetMinuutInvoer.Size = new System.Drawing.Size(103, 32);
            this.textEindetMinuutInvoer.TabIndex = 12;
            this.textEindetMinuutInvoer.TextChanged += new System.EventHandler(this.textEindetMinuutInvoer_TextChanged);
            // 
            // textTotMinuten
            // 
            this.textTotMinuten.BackColor = System.Drawing.SystemColors.Control;
            this.textTotMinuten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTotMinuten.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotMinuten.Location = new System.Drawing.Point(309, 212);
            this.textTotMinuten.Name = "textTotMinuten";
            this.textTotMinuten.ReadOnly = true;
            this.textTotMinuten.Size = new System.Drawing.Size(79, 25);
            this.textTotMinuten.TabIndex = 11;
            this.textTotMinuten.Text = "Minuut";
            this.textTotMinuten.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotMinuten.TextChanged += new System.EventHandler(this.textTotMinuten_TextChanged);
            // 
            // comboEindeUur
            // 
            this.comboEindeUur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEindeUur.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEindeUur.FormattingEnabled = true;
            this.comboEindeUur.Items.AddRange(new object[] {
            "0 ",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.comboEindeUur.Location = new System.Drawing.Point(198, 212);
            this.comboEindeUur.Name = "comboEindeUur";
            this.comboEindeUur.Size = new System.Drawing.Size(91, 32);
            this.comboEindeUur.TabIndex = 10;
            // 
            // textTotUur
            // 
            this.textTotUur.BackColor = System.Drawing.SystemColors.Control;
            this.textTotUur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTotUur.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotUur.Location = new System.Drawing.Point(154, 212);
            this.textTotUur.Name = "textTotUur";
            this.textTotUur.ReadOnly = true;
            this.textTotUur.Size = new System.Drawing.Size(38, 25);
            this.textTotUur.TabIndex = 9;
            this.textTotUur.Text = "Uur";
            this.textTotUur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textTijdTot
            // 
            this.textTijdTot.BackColor = System.Drawing.SystemColors.Control;
            this.textTijdTot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTijdTot.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTijdTot.Location = new System.Drawing.Point(11, 212);
            this.textTijdTot.Name = "textTijdTot";
            this.textTijdTot.ReadOnly = true;
            this.textTijdTot.Size = new System.Drawing.Size(101, 25);
            this.textTijdTot.TabIndex = 8;
            this.textTijdTot.Text = "Eindtijd rit";
            // 
            // textAantalKilometersInvoer
            // 
            this.textAantalKilometersInvoer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAantalKilometersInvoer.Location = new System.Drawing.Point(198, 278);
            this.textAantalKilometersInvoer.Name = "textAantalKilometersInvoer";
            this.textAantalKilometersInvoer.Size = new System.Drawing.Size(89, 32);
            this.textAantalKilometersInvoer.TabIndex = 14;
            // 
            // textAantalKilometers
            // 
            this.textAantalKilometers.BackColor = System.Drawing.SystemColors.Control;
            this.textAantalKilometers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textAantalKilometers.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAantalKilometers.Location = new System.Drawing.Point(11, 281);
            this.textAantalKilometers.Name = "textAantalKilometers";
            this.textAantalKilometers.ReadOnly = true;
            this.textAantalKilometers.Size = new System.Drawing.Size(159, 25);
            this.textAantalKilometers.TabIndex = 13;
            this.textAantalKilometers.Text = "Aantal kilometers";
            this.textAantalKilometers.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textTotaleKosten
            // 
            this.textTotaleKosten.BackColor = System.Drawing.SystemColors.Control;
            this.textTotaleKosten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTotaleKosten.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotaleKosten.Location = new System.Drawing.Point(13, 362);
            this.textTotaleKosten.Name = "textTotaleKosten";
            this.textTotaleKosten.ReadOnly = true;
            this.textTotaleKosten.Size = new System.Drawing.Size(159, 25);
            this.textTotaleKosten.TabIndex = 15;
            this.textTotaleKosten.Text = "Totale kosten rit:";
            // 
            // textTotaleKostenRitUitvoer
            // 
            this.textTotaleKostenRitUitvoer.BackColor = System.Drawing.SystemColors.Control;
            this.textTotaleKostenRitUitvoer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTotaleKostenRitUitvoer.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.textTotaleKostenRitUitvoer.Location = new System.Drawing.Point(199, 362);
            this.textTotaleKostenRitUitvoer.Name = "textTotaleKostenRitUitvoer";
            this.textTotaleKostenRitUitvoer.ReadOnly = true;
            this.textTotaleKostenRitUitvoer.Size = new System.Drawing.Size(159, 27);
            this.textTotaleKostenRitUitvoer.TabIndex = 16;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.DarkRed;
            this.btnReset.Location = new System.Drawing.Point(396, 368);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 34);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBereken
            // 
            this.btnBereken.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBereken.ForeColor = System.Drawing.Color.Black;
            this.btnBereken.Location = new System.Drawing.Point(395, 278);
            this.btnBereken.Name = "btnBereken";
            this.btnBereken.Size = new System.Drawing.Size(103, 34);
            this.btnBereken.TabIndex = 18;
            this.btnBereken.Text = "Bereken";
            this.btnBereken.UseVisualStyleBackColor = true;
            this.btnBereken.Click += new System.EventHandler(this.btnBereken_Click);
            // 
            // textBoxFoutUitvoer
            // 
            this.textBoxFoutUitvoer.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFoutUitvoer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFoutUitvoer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Italic);
            this.textBoxFoutUitvoer.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxFoutUitvoer.Location = new System.Drawing.Point(13, 418);
            this.textBoxFoutUitvoer.Multiline = true;
            this.textBoxFoutUitvoer.Name = "textBoxFoutUitvoer";
            this.textBoxFoutUitvoer.ReadOnly = true;
            this.textBoxFoutUitvoer.Size = new System.Drawing.Size(485, 50);
            this.textBoxFoutUitvoer.TabIndex = 19;
            // 
            // formTaxiKosten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 480);
            this.Controls.Add(this.textBoxFoutUitvoer);
            this.Controls.Add(this.btnBereken);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.textTotaleKostenRitUitvoer);
            this.Controls.Add(this.textTotaleKosten);
            this.Controls.Add(this.textAantalKilometersInvoer);
            this.Controls.Add(this.textAantalKilometers);
            this.Controls.Add(this.textEindetMinuutInvoer);
            this.Controls.Add(this.textTotMinuten);
            this.Controls.Add(this.comboEindeUur);
            this.Controls.Add(this.textTotUur);
            this.Controls.Add(this.textTijdTot);
            this.Controls.Add(this.textStartMinuutInvoer);
            this.Controls.Add(this.textVanafMinuten);
            this.Controls.Add(this.comboStartUur);
            this.Controls.Add(this.textVanafUur);
            this.Controls.Add(this.textTijdVanaf);
            this.Controls.Add(this.textDag);
            this.Controls.Add(this.textAlgemeen);
            this.Controls.Add(this.comboBoxDagVanDeWeek);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formTaxiKosten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taxikosten";
            this.Load += new System.EventHandler(this.formTaxiKosten_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDagVanDeWeek;
        private System.Windows.Forms.TextBox textAlgemeen;
        private System.Windows.Forms.TextBox textDag;
        private System.Windows.Forms.TextBox textTijdVanaf;
        private System.Windows.Forms.TextBox textVanafUur;
        private System.Windows.Forms.ComboBox comboStartUur;
        private System.Windows.Forms.TextBox textVanafMinuten;
        private System.Windows.Forms.TextBox textStartMinuutInvoer;
        private System.Windows.Forms.TextBox textEindetMinuutInvoer;
        private System.Windows.Forms.TextBox textTotMinuten;
        private System.Windows.Forms.ComboBox comboEindeUur;
        private System.Windows.Forms.TextBox textTotUur;
        private System.Windows.Forms.TextBox textTijdTot;
        private System.Windows.Forms.TextBox textAantalKilometersInvoer;
        private System.Windows.Forms.TextBox textAantalKilometers;
        private System.Windows.Forms.TextBox textTotaleKosten;
        private System.Windows.Forms.TextBox textTotaleKostenRitUitvoer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBereken;
        private System.Windows.Forms.TextBox textBoxFoutUitvoer;
    }
}

