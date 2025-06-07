namespace FederaProDesktop.Karting
{
    partial class CompeticionesKartingControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridViewCompeticiones;
        private System.Windows.Forms.Button btnActualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dataGridViewCompeticiones = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompeticiones)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(234, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Competiciones Karting";

            // dataGridViewCompeticiones
            this.dataGridViewCompeticiones.AllowUserToAddRows = false;
            this.dataGridViewCompeticiones.AllowUserToDeleteRows = false;
            this.dataGridViewCompeticiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompeticiones.Location = new System.Drawing.Point(20, 70);
            this.dataGridViewCompeticiones.MultiSelect = false;
            this.dataGridViewCompeticiones.Name = "dataGridViewCompeticiones";
            this.dataGridViewCompeticiones.ReadOnly = true;
            this.dataGridViewCompeticiones.RowTemplate.Height = 24;
            this.dataGridViewCompeticiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompeticiones.Size = new System.Drawing.Size(540, 260);
            this.dataGridViewCompeticiones.TabIndex = 1;
            this.dataGridViewCompeticiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompeticiones_CellDoubleClick);

            // btnActualizar
            this.btnActualizar.Location = new System.Drawing.Point(460, 20);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 30);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // CompeticionesKartingControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dataGridViewCompeticiones);
            this.Controls.Add(this.lblTitulo);
            this.Name = "CompeticionesKartingControl";
            this.Size = new System.Drawing.Size(600, 350);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompeticiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
