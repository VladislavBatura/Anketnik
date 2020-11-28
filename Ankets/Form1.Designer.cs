namespace Ankets
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ApplicationTextBox = new System.Windows.Forms.RichTextBox();
            this.ButtonApproved = new System.Windows.Forms.Button();
            this.ButtonMeeting = new System.Windows.Forms.Button();
            this.ButtonNotApproved = new System.Windows.Forms.Button();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ApplicationTextBox
            // 
            this.ApplicationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplicationTextBox.Location = new System.Drawing.Point(397, 29);
            this.ApplicationTextBox.Name = "ApplicationTextBox";
            this.ApplicationTextBox.ReadOnly = true;
            this.ApplicationTextBox.Size = new System.Drawing.Size(545, 509);
            this.ApplicationTextBox.TabIndex = 0;
            this.ApplicationTextBox.Text = "";
            this.ApplicationTextBox.Visible = false;
            // 
            // ButtonApproved
            // 
            this.ButtonApproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonApproved.Location = new System.Drawing.Point(161, 47);
            this.ButtonApproved.Name = "ButtonApproved";
            this.ButtonApproved.Size = new System.Drawing.Size(144, 63);
            this.ButtonApproved.TabIndex = 1;
            this.ButtonApproved.Text = "Принят";
            this.ButtonApproved.UseVisualStyleBackColor = false;
            this.ButtonApproved.Visible = false;
            this.ButtonApproved.Click += new System.EventHandler(this.ButtonApproved_Click);
            // 
            // ButtonMeeting
            // 
            this.ButtonMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ButtonMeeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonMeeting.Location = new System.Drawing.Point(144, 237);
            this.ButtonMeeting.Name = "ButtonMeeting";
            this.ButtonMeeting.Size = new System.Drawing.Size(183, 73);
            this.ButtonMeeting.TabIndex = 2;
            this.ButtonMeeting.Text = "Собеседование";
            this.ButtonMeeting.UseVisualStyleBackColor = false;
            this.ButtonMeeting.Visible = false;
            this.ButtonMeeting.Click += new System.EventHandler(this.ButtonMeeting_Click);
            // 
            // ButtonNotApproved
            // 
            this.ButtonNotApproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ButtonNotApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonNotApproved.Location = new System.Drawing.Point(161, 452);
            this.ButtonNotApproved.Name = "ButtonNotApproved";
            this.ButtonNotApproved.Size = new System.Drawing.Size(144, 63);
            this.ButtonNotApproved.TabIndex = 3;
            this.ButtonNotApproved.Text = "Отказано";
            this.ButtonNotApproved.UseVisualStyleBackColor = false;
            this.ButtonNotApproved.Visible = false;
            this.ButtonNotApproved.Click += new System.EventHandler(this.ButtonNotApproved_Click);
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonReturn.Location = new System.Drawing.Point(12, 12);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(82, 63);
            this.ButtonReturn.TabIndex = 4;
            this.ButtonReturn.Text = "<<";
            this.ButtonReturn.UseVisualStyleBackColor = false;
            this.ButtonReturn.Visible = false;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.Red;
            this.ButtonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonDelete.Location = new System.Drawing.Point(968, 29);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(96, 81);
            this.ButtonDelete.TabIndex = 5;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Visible = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1112, 589);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonNotApproved);
            this.Controls.Add(this.ButtonMeeting);
            this.Controls.Add(this.ButtonApproved);
            this.Controls.Add(this.ApplicationTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Анкетник";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ApplicationTextBox;
        private System.Windows.Forms.Button ButtonApproved;
        private System.Windows.Forms.Button ButtonMeeting;
        private System.Windows.Forms.Button ButtonNotApproved;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonDelete;
    }
}

