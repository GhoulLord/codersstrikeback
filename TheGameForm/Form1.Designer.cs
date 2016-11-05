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
            this.buttonStopSearch = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonStopRace = new System.Windows.Forms.Button();
            this.buttonStartRace = new System.Windows.Forms.Button();
            this.labelPlayerBCheckpoint2 = new System.Windows.Forms.Label();
            this.labelPlayerBCheckpoint1 = new System.Windows.Forms.Label();
            this.labelPlayerBTimeout = new System.Windows.Forms.Label();
            this.labelPlayerBRounds = new System.Windows.Forms.Label();
            this.labelPlayerACheckpoint2 = new System.Windows.Forms.Label();
            this.labelPlayerACheckpoint1 = new System.Windows.Forms.Label();
            this.labelPlayerATimeout = new System.Windows.Forms.Label();
            this.labelPlayerARounds = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelBenchmark = new System.Windows.Forms.Label();
            this.labelGenerations = new System.Windows.Forms.Label();
            this.labelScoreAverage = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelRound = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExecuteRace = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel2.Controls.Add(this.buttonStopSearch);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSearch);
            this.splitContainer1.Panel2.Controls.Add(this.buttonNewGame);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStopRace);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStartRace);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerBCheckpoint2);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerBCheckpoint1);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerBTimeout);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerBRounds);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerACheckpoint2);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerACheckpoint1);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerATimeout);
            this.splitContainer1.Panel2.Controls.Add(this.labelPlayerARounds);
            this.splitContainer1.Panel2.Controls.Add(this.labelTime);
            this.splitContainer1.Panel2.Controls.Add(this.labelBenchmark);
            this.splitContainer1.Panel2.Controls.Add(this.labelGenerations);
            this.splitContainer1.Panel2.Controls.Add(this.labelScoreAverage);
            this.splitContainer1.Panel2.Controls.Add(this.labelScore);
            this.splitContainer1.Panel2.Controls.Add(this.labelRound);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonExecuteRace);
            this.splitContainer1.Panel2.Controls.Add(this.buttonPrev);
            this.splitContainer1.Panel2.Controls.Add(this.buttonNext);
            this.splitContainer1.Panel2.Controls.Add(this.buttonInitRaceSwapped);
            this.splitContainer1.Panel2.Controls.Add(this.buttonInitRace);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 676);
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
            // buttonStopSearch
            // 
            this.buttonStopSearch.Location = new System.Drawing.Point(100, 238);
            this.buttonStopSearch.Name = "buttonStopSearch";
            this.buttonStopSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonStopSearch.TabIndex = 10;
            this.buttonStopSearch.Text = "stop search";
            this.buttonStopSearch.UseVisualStyleBackColor = true;
            this.buttonStopSearch.Click += new System.EventHandler(this.buttonStopSearch_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(6, 238);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(6, 116);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGame.TabIndex = 9;
            this.buttonNewGame.Text = "new game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonStopRace
            // 
            this.buttonStopRace.Enabled = false;
            this.buttonStopRace.Location = new System.Drawing.Point(100, 145);
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
            // labelPlayerBCheckpoint2
            // 
            this.labelPlayerBCheckpoint2.AutoSize = true;
            this.labelPlayerBCheckpoint2.Location = new System.Drawing.Point(59, 532);
            this.labelPlayerBCheckpoint2.Name = "labelPlayerBCheckpoint2";
            this.labelPlayerBCheckpoint2.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerBCheckpoint2.TabIndex = 6;
            this.labelPlayerBCheckpoint2.Text = "label2";
            // 
            // labelPlayerBCheckpoint1
            // 
            this.labelPlayerBCheckpoint1.AutoSize = true;
            this.labelPlayerBCheckpoint1.Location = new System.Drawing.Point(59, 510);
            this.labelPlayerBCheckpoint1.Name = "labelPlayerBCheckpoint1";
            this.labelPlayerBCheckpoint1.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerBCheckpoint1.TabIndex = 6;
            this.labelPlayerBCheckpoint1.Text = "label2";
            // 
            // labelPlayerBTimeout
            // 
            this.labelPlayerBTimeout.AutoSize = true;
            this.labelPlayerBTimeout.Location = new System.Drawing.Point(59, 486);
            this.labelPlayerBTimeout.Name = "labelPlayerBTimeout";
            this.labelPlayerBTimeout.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerBTimeout.TabIndex = 6;
            this.labelPlayerBTimeout.Text = "label2";
            // 
            // labelPlayerBRounds
            // 
            this.labelPlayerBRounds.AutoSize = true;
            this.labelPlayerBRounds.Location = new System.Drawing.Point(59, 462);
            this.labelPlayerBRounds.Name = "labelPlayerBRounds";
            this.labelPlayerBRounds.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerBRounds.TabIndex = 6;
            this.labelPlayerBRounds.Text = "label2";
            // 
            // labelPlayerACheckpoint2
            // 
            this.labelPlayerACheckpoint2.AutoSize = true;
            this.labelPlayerACheckpoint2.Location = new System.Drawing.Point(60, 437);
            this.labelPlayerACheckpoint2.Name = "labelPlayerACheckpoint2";
            this.labelPlayerACheckpoint2.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerACheckpoint2.TabIndex = 6;
            this.labelPlayerACheckpoint2.Text = "label2";
            // 
            // labelPlayerACheckpoint1
            // 
            this.labelPlayerACheckpoint1.AutoSize = true;
            this.labelPlayerACheckpoint1.Location = new System.Drawing.Point(60, 412);
            this.labelPlayerACheckpoint1.Name = "labelPlayerACheckpoint1";
            this.labelPlayerACheckpoint1.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerACheckpoint1.TabIndex = 6;
            this.labelPlayerACheckpoint1.Text = "label2";
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
            // labelGenerations
            // 
            this.labelGenerations.AutoSize = true;
            this.labelGenerations.Location = new System.Drawing.Point(60, 207);
            this.labelGenerations.Name = "labelGenerations";
            this.labelGenerations.Size = new System.Drawing.Size(35, 13);
            this.labelGenerations.TabIndex = 6;
            this.labelGenerations.Text = "label2";
            // 
            // labelScoreAverage
            // 
            this.labelScoreAverage.AutoSize = true;
            this.labelScoreAverage.Location = new System.Drawing.Point(182, 184);
            this.labelScoreAverage.Name = "labelScoreAverage";
            this.labelScoreAverage.Size = new System.Drawing.Size(35, 13);
            this.labelScoreAverage.TabIndex = 6;
            this.labelScoreAverage.Text = "label2";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(59, 184);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(35, 13);
            this.labelScore.TabIndex = 6;
            this.labelScore.Text = "label2";
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
            this.label4.Location = new System.Drawing.Point(2, 462);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "gens";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Score";
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
            // buttonExecuteRace
            // 
            this.buttonExecuteRace.Location = new System.Drawing.Point(6, 145);
            this.buttonExecuteRace.Name = "buttonExecuteRace";
            this.buttonExecuteRace.Size = new System.Drawing.Size(75, 23);
            this.buttonExecuteRace.TabIndex = 4;
            this.buttonExecuteRace.Text = "execute";
            this.buttonExecuteRace.UseVisualStyleBackColor = true;
            this.buttonExecuteRace.Click += new System.EventHandler(this.buttonExecuteRace_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(100, 73);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 3;
            this.buttonPrev.Text = "previous";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(100, 102);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
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
            this.ClientSize = new System.Drawing.Size(1264, 676);
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
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonExecuteRace;
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
        private System.Windows.Forms.Label labelPlayerBCheckpoint1;
        private System.Windows.Forms.Label labelPlayerACheckpoint1;
        private System.Windows.Forms.Label labelPlayerACheckpoint2;
        private System.Windows.Forms.Label labelPlayerBCheckpoint2;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelGenerations;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonStopSearch;
        private System.Windows.Forms.Label labelScoreAverage;
    }
}

