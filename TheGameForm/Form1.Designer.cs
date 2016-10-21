namespace TheGameForm
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gameArena = new TheGameForm.GameArena();
            this.buttonStopRace = new System.Windows.Forms.Button();
            this.buttonStartRace = new System.Windows.Forms.Button();
            this.labelPlayerBTimeout = new System.Windows.Forms.Label();
            this.labelPlayerBRounds = new System.Windows.Forms.Label();
            this.labelPlayerATimeout = new System.Windows.Forms.Label();
            this.labelPlayerARounds = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelBenchmark = new System.Windows.Forms.Label();
            this.labelRound = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonInitRaceSwapped = new System.Windows.Forms.Button();
            this.buttonInitRace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gameArena);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonStopRace);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStartRace);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerBTimeout);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerBRounds);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerATimeout);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerARounds);
            this.splitContainer1.Panel2.Controls.Add(this.labelTime);
            this.splitContainer1.Panel2.Controls.Add(this.labelBenchmark);
            this.splitContainer1.Panel2.Controls.Add(this.labelRound);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.buttonInitRaceSwapped);
            this.splitContainer1.Panel2.Controls.Add(this.buttonInitRace);
            this.splitContainer1.Size = new System.Drawing.Size(991, 676);
            this.splitContainer1.SplitterDistance = 800;
            this.splitContainer1.TabIndex = 1;
            // 
            // gameArena
            // 
            this.gameArena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameArena.Location = new System.Drawing.Point(0, 0);
            this.gameArena.Name = "gameArena";
            this.gameArena.Size = new System.Drawing.Size(800, 676);
            this.gameArena.TabIndex = 0;
            // 
            // buttonStopRace
            // 
            this.buttonStopRace.Enabled = false;
            this.buttonStopRace.Location = new System.Drawing.Point(100, 73);
            this.buttonStopRace.Name = "buttonStopRace";
            this.buttonStopRace.Size = new System.Drawing.Size(75, 23);
            this.buttonStopRace.TabIndex = 8;
            this.buttonStopRace.Text = "stop";
            this.buttonStopRace.UseVisualStyleBackColor = true;
            this.buttonStopRace.Click += new System.EventHandler(this.buttonStopRace_Click);
            // 
            // buttonStartRace
            // 
            this.buttonStartRace.Location = new System.Drawing.Point(100, 12);
            this.buttonStartRace.Name = "buttonStartRace";
            this.buttonStartRace.Size = new System.Drawing.Size(75, 23);
            this.buttonStartRace.TabIndex = 7;
            this.buttonStartRace.Text = "start";
            this.buttonStartRace.UseVisualStyleBackColor = true;
            this.buttonStartRace.Click += new System.EventHandler(this.buttonStartRace_Click);
            // 
            // labelPlayerBTimeout
            // 
            this.labelPlayerBTimeout.AutoSize = true;
            this.labelPlayerBTimeout.Location = new System.Drawing.Point(60, 445);
            this.labelPlayerBTimeout.Name = "labelPlayerBTimeout";
            this.labelPlayerBTimeout.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerBTimeout.TabIndex = 6;
            this.labelPlayerBTimeout.Text = "label2";
            // 
            // labelPlayerBRounds
            // 
            this.labelPlayerBRounds.AutoSize = true;
            this.labelPlayerBRounds.Location = new System.Drawing.Point(60, 421);
            this.labelPlayerBRounds.Name = "labelPlayerBRounds";
            this.labelPlayerBRounds.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerBRounds.TabIndex = 6;
            this.labelPlayerBRounds.Text = "label2";
            // 
            // labelPlayerATimeout
            // 
            this.labelPlayerATimeout.AutoSize = true;
            this.labelPlayerATimeout.Location = new System.Drawing.Point(60, 389);
            this.labelPlayerATimeout.Name = "labelPlayerATimeout";
            this.labelPlayerATimeout.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerATimeout.TabIndex = 6;
            this.labelPlayerATimeout.Text = "label2";
            // 
            // labelPlayerARounds
            // 
            this.labelPlayerARounds.AutoSize = true;
            this.labelPlayerARounds.Location = new System.Drawing.Point(60, 367);
            this.labelPlayerARounds.Name = "labelPlayerARounds";
            this.labelPlayerARounds.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerARounds.TabIndex = 6;
            this.labelPlayerARounds.Text = "label2";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(60, 339);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(35, 13);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "label2";
            // 
            // labelBenchmark
            // 
            this.labelBenchmark.AutoSize = true;
            this.labelBenchmark.Location = new System.Drawing.Point(97, 48);
            this.labelBenchmark.Name = "labelBenchmark";
            this.labelBenchmark.Size = new System.Drawing.Size(35, 13);
            this.labelBenchmark.TabIndex = 6;
            this.labelBenchmark.Text = "label2";
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Location = new System.Drawing.Point(60, 317);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(35, 13);
            this.labelRound.TabIndex = 6;
            this.labelRound.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Player B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Round";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 277);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "1 round";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "race no anim";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonInitRaceSwapped
            // 
            this.buttonInitRaceSwapped.Location = new System.Drawing.Point(3, 73);
            this.buttonInitRaceSwapped.Name = "buttonInitRaceSwapped";
            this.buttonInitRaceSwapped.Size = new System.Drawing.Size(75, 23);
            this.buttonInitRaceSwapped.TabIndex = 1;
            this.buttonInitRaceSwapped.Text = "init swapped";
            this.buttonInitRaceSwapped.UseVisualStyleBackColor = true;
            this.buttonInitRaceSwapped.Click += new System.EventHandler(this.buttonInitRaceSwapped_Click);
            // 
            // buttonInitRace
            // 
            this.buttonInitRace.Location = new System.Drawing.Point(3, 12);
            this.buttonInitRace.Name = "buttonInitRace";
            this.buttonInitRace.Size = new System.Drawing.Size(75, 23);
            this.buttonInitRace.TabIndex = 0;
            this.buttonInitRace.Text = "init";
            this.buttonInitRace.UseVisualStyleBackColor = true;
            this.buttonInitRace.Click += new System.EventHandler(this.buttonInitRace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 676);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GameArena gameArena;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonInitRace;
        private System.Windows.Forms.Button buttonInitRaceSwapped;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labelPlayerBRounds;
        private System.Windows.Forms.Label labelPlayerARounds;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPlayerBTimeout;
        private System.Windows.Forms.Label labelPlayerATimeout;
        private System.Windows.Forms.Button buttonStopRace;
        private System.Windows.Forms.Button buttonStartRace;
        private System.Windows.Forms.Label labelBenchmark;
    }
}

