namespace Malchikov6404Client
{
    partial class Client
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
            this.logs = new System.Windows.Forms.RichTextBox();
            this.ipadress = new System.Windows.Forms.TextBox();
            this.filepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.goRSAbutton = new System.Windows.Forms.Button();
            this.sendFile = new System.Windows.Forms.Button();
            this.generateKey = new System.Windows.Forms.Button();
            this.getFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.myIP = new System.Windows.Forms.Label();
            this.Pkey = new System.Windows.Forms.Label();
            this.Qkey = new System.Windows.Forms.Label();
            this.Nkey = new System.Windows.Forms.Label();
            this.Phikey = new System.Windows.Forms.Label();
            this.Ekey = new System.Windows.Forms.Label();
            this.NODkey = new System.Windows.Forms.Label();
            this.Dkey = new System.Windows.Forms.Label();
            this.Ykey = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.superkeyl = new System.Windows.Forms.Label();
            this.genSuperkeyandSent = new System.Windows.Forms.Button();
            this.CryptDecryptFileTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(375, 12);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(189, 470);
            this.logs.TabIndex = 0;
            this.logs.Text = "";
            // 
            // ipadress
            // 
            this.ipadress.Location = new System.Drawing.Point(12, 12);
            this.ipadress.Name = "ipadress";
            this.ipadress.Size = new System.Drawing.Size(266, 20);
            this.ipadress.TabIndex = 1;
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(12, 38);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(266, 20);
            this.filepath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ipV4 - адрес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Путь к файлу";
            // 
            // goRSAbutton
            // 
            this.goRSAbutton.Location = new System.Drawing.Point(12, 154);
            this.goRSAbutton.Name = "goRSAbutton";
            this.goRSAbutton.Size = new System.Drawing.Size(357, 27);
            this.goRSAbutton.TabIndex = 5;
            this.goRSAbutton.Text = "[8] Отправить зашифрованный файл";
            this.goRSAbutton.UseVisualStyleBackColor = true;
            this.goRSAbutton.Click += new System.EventHandler(this.goRSAbutton_Click);
            // 
            // sendFile
            // 
            this.sendFile.Location = new System.Drawing.Point(12, 189);
            this.sendFile.Name = "sendFile";
            this.sendFile.Size = new System.Drawing.Size(357, 23);
            this.sendFile.TabIndex = 6;
            this.sendFile.Text = "(тестовый) Отправить файл";
            this.sendFile.UseVisualStyleBackColor = true;
            this.sendFile.Click += new System.EventHandler(this.sendFile_Click);
            // 
            // generateKey
            // 
            this.generateKey.Location = new System.Drawing.Point(12, 92);
            this.generateKey.Name = "generateKey";
            this.generateKey.Size = new System.Drawing.Size(357, 23);
            this.generateKey.TabIndex = 7;
            this.generateKey.Text = "[4] Получить ключи от сервера";
            this.generateKey.UseVisualStyleBackColor = true;
            this.generateKey.Click += new System.EventHandler(this.generateKey_Click);
            // 
            // getFile
            // 
            this.getFile.Location = new System.Drawing.Point(12, 64);
            this.getFile.Name = "getFile";
            this.getFile.Size = new System.Drawing.Size(357, 23);
            this.getFile.TabIndex = 8;
            this.getFile.Text = "[3] Выбрать файл";
            this.getFile.UseVisualStyleBackColor = true;
            this.getFile.Click += new System.EventHandler(this.getFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // myIP
            // 
            this.myIP.AutoSize = true;
            this.myIP.Location = new System.Drawing.Point(12, 456);
            this.myIP.Name = "myIP";
            this.myIP.Size = new System.Drawing.Size(47, 13);
            this.myIP.TabIndex = 9;
            this.myIP.Text = "Мой IP=";
            // 
            // Pkey
            // 
            this.Pkey.AutoSize = true;
            this.Pkey.Location = new System.Drawing.Point(63, 352);
            this.Pkey.Name = "Pkey";
            this.Pkey.Size = new System.Drawing.Size(13, 13);
            this.Pkey.TabIndex = 10;
            this.Pkey.Text = " -";
            // 
            // Qkey
            // 
            this.Qkey.AutoSize = true;
            this.Qkey.Location = new System.Drawing.Point(63, 365);
            this.Qkey.Name = "Qkey";
            this.Qkey.Size = new System.Drawing.Size(13, 13);
            this.Qkey.TabIndex = 11;
            this.Qkey.Text = " -";
            // 
            // Nkey
            // 
            this.Nkey.AutoSize = true;
            this.Nkey.Location = new System.Drawing.Point(63, 378);
            this.Nkey.Name = "Nkey";
            this.Nkey.Size = new System.Drawing.Size(13, 13);
            this.Nkey.TabIndex = 12;
            this.Nkey.Text = " -";
            // 
            // Phikey
            // 
            this.Phikey.AutoSize = true;
            this.Phikey.Location = new System.Drawing.Point(63, 391);
            this.Phikey.Name = "Phikey";
            this.Phikey.Size = new System.Drawing.Size(13, 13);
            this.Phikey.TabIndex = 13;
            this.Phikey.Text = " -";
            // 
            // Ekey
            // 
            this.Ekey.AutoSize = true;
            this.Ekey.Location = new System.Drawing.Point(63, 404);
            this.Ekey.Name = "Ekey";
            this.Ekey.Size = new System.Drawing.Size(13, 13);
            this.Ekey.TabIndex = 14;
            this.Ekey.Text = " -";
            // 
            // NODkey
            // 
            this.NODkey.AutoSize = true;
            this.NODkey.Location = new System.Drawing.Point(63, 417);
            this.NODkey.Name = "NODkey";
            this.NODkey.Size = new System.Drawing.Size(13, 13);
            this.NODkey.TabIndex = 15;
            this.NODkey.Text = " -";
            // 
            // Dkey
            // 
            this.Dkey.AutoSize = true;
            this.Dkey.Location = new System.Drawing.Point(63, 430);
            this.Dkey.Name = "Dkey";
            this.Dkey.Size = new System.Drawing.Size(13, 13);
            this.Dkey.TabIndex = 16;
            this.Dkey.Text = " -";
            // 
            // Ykey
            // 
            this.Ykey.AutoSize = true;
            this.Ykey.Location = new System.Drawing.Point(63, 443);
            this.Ykey.Name = "Ykey";
            this.Ykey.Size = new System.Drawing.Size(13, 13);
            this.Ykey.TabIndex = 17;
            this.Ykey.Text = " -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ykey=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Dkey=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "NODkey=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ekey=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Phikey=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Nkey=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 365);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Qkey=";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Pkey=";
            // 
            // superkeyl
            // 
            this.superkeyl.AutoSize = true;
            this.superkeyl.Location = new System.Drawing.Point(12, 469);
            this.superkeyl.Name = "superkeyl";
            this.superkeyl.Size = new System.Drawing.Size(58, 13);
            this.superkeyl.TabIndex = 26;
            this.superkeyl.Text = "Superkey=";
            // 
            // genSuperkeyandSent
            // 
            this.genSuperkeyandSent.Location = new System.Drawing.Point(12, 121);
            this.genSuperkeyandSent.Name = "genSuperkeyandSent";
            this.genSuperkeyandSent.Size = new System.Drawing.Size(357, 27);
            this.genSuperkeyandSent.TabIndex = 27;
            this.genSuperkeyandSent.Text = "[6] Зашифровать, сгенерировать суперключ и отправить";
            this.genSuperkeyandSent.UseVisualStyleBackColor = true;
            this.genSuperkeyandSent.Click += new System.EventHandler(this.genSuperkeyandSent_Click);
            // 
            // CryptDecryptFileTest
            // 
            this.CryptDecryptFileTest.Location = new System.Drawing.Point(12, 218);
            this.CryptDecryptFileTest.Name = "CryptDecryptFileTest";
            this.CryptDecryptFileTest.Size = new System.Drawing.Size(357, 23);
            this.CryptDecryptFileTest.TabIndex = 28;
            this.CryptDecryptFileTest.Text = "(тестовый) Зашифровать и расшифровать";
            this.CryptDecryptFileTest.UseVisualStyleBackColor = true;
            this.CryptDecryptFileTest.Click += new System.EventHandler(this.CryptDecryptFileTest_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 490);
            this.Controls.Add(this.CryptDecryptFileTest);
            this.Controls.Add(this.genSuperkeyandSent);
            this.Controls.Add(this.superkeyl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Ykey);
            this.Controls.Add(this.Dkey);
            this.Controls.Add(this.NODkey);
            this.Controls.Add(this.Ekey);
            this.Controls.Add(this.Phikey);
            this.Controls.Add(this.Nkey);
            this.Controls.Add(this.Qkey);
            this.Controls.Add(this.Pkey);
            this.Controls.Add(this.myIP);
            this.Controls.Add(this.getFile);
            this.Controls.Add(this.generateKey);
            this.Controls.Add(this.sendFile);
            this.Controls.Add(this.goRSAbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filepath);
            this.Controls.Add(this.ipadress);
            this.Controls.Add(this.logs);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.TextBox ipadress;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button goRSAbutton;
        private System.Windows.Forms.Button sendFile;
        private System.Windows.Forms.Button generateKey;
        private System.Windows.Forms.Button getFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label myIP;
        private System.Windows.Forms.Label Pkey;
        private System.Windows.Forms.Label Qkey;
        private System.Windows.Forms.Label Nkey;
        private System.Windows.Forms.Label Phikey;
        private System.Windows.Forms.Label Ekey;
        private System.Windows.Forms.Label NODkey;
        private System.Windows.Forms.Label Dkey;
        private System.Windows.Forms.Label Ykey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label superkeyl;
        private System.Windows.Forms.Button genSuperkeyandSent;
        private System.Windows.Forms.Button CryptDecryptFileTest;
    }
}

