namespace FederaProDesktop.Karting
{
    partial class PilotosControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewPilotos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;

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
            this.dataGridViewPilotos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPilotos)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewPilotos
            // 
            this.dataGridViewPilotos.AllowUserToAddRows = false;
            this.dataGridViewPilotos.AllowUserToDeleteRows = false;
            this.dataGridViewPilotos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPilotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPilotos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewPilotos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPilotos.MultiSelect = false;
            this.dataGridViewPilotos.Name = "dataGridViewPilotos";
            this.dataGridViewPilotos.ReadOnly = true;
            this.dataGridViewPilotos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPilotos.Size = new System.Drawing.Size(800, 400);
            this.dataGridViewPilotos.TabIndex = 0;
            this.dataGridViewPilotos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPilotos_CellDoubleClick);

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(20, 420);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(140, 420);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // PilotosKartingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dataGridViewPilotos);
            this.Name = "PilotosKartingControl";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPilotos)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
