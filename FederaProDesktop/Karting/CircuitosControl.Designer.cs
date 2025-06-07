namespace FederaProDesktop.Karting
{
    partial class CircuitosControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewCircuitos;
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
            this.dataGridViewCircuitos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCircuitos)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewCircuitos
            // 
            this.dataGridViewCircuitos.AllowUserToAddRows = false;
            this.dataGridViewCircuitos.AllowUserToDeleteRows = false;
            this.dataGridViewCircuitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCircuitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCircuitos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewCircuitos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCircuitos.MultiSelect = false;
            this.dataGridViewCircuitos.Name = "dataGridViewCircuitos";
            this.dataGridViewCircuitos.ReadOnly = true;
            this.dataGridViewCircuitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCircuitos.Size = new System.Drawing.Size(800, 400);
            this.dataGridViewCircuitos.TabIndex = 0;
            this.dataGridViewCircuitos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCircuitos_CellDoubleClick);

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
            // CircuitosKartingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dataGridViewCircuitos);
            this.Name = "CircuitosKartingControl";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCircuitos)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
