namespace FederaProDesktop.Karting
{
    partial class EquiposKartingControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewEquipos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;

        // NUEVOS BOTONES
        private System.Windows.Forms.Button btnDescargarPlantilla;
        private System.Windows.Forms.Button btnImportarCSV;

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
            this.dataGridViewEquipos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDescargarPlantilla = new System.Windows.Forms.Button();
            this.btnImportarCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipos)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewEquipos
            // 
            this.dataGridViewEquipos.AllowUserToAddRows = false;
            this.dataGridViewEquipos.AllowUserToDeleteRows = false;
            this.dataGridViewEquipos.AllowUserToResizeRows = false;
            this.dataGridViewEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEquipos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewEquipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridViewEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewEquipos.EnableHeadersVisualStyles = false;
            this.dataGridViewEquipos.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewEquipos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEquipos.MultiSelect = false;
            this.dataGridViewEquipos.Name = "dataGridViewEquipos";
            this.dataGridViewEquipos.ReadOnly = true;
            this.dataGridViewEquipos.RowHeadersVisible = false;
            this.dataGridViewEquipos.RowTemplate.Height = 28;
            this.dataGridViewEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEquipos.Size = new System.Drawing.Size(650, 260);
            this.dataGridViewEquipos.TabIndex = 0;
            this.dataGridViewEquipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEquipos_CellDoubleClick);

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(20, 290);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(130, 290);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // btnDescargarPlantilla
            // 
            this.btnDescargarPlantilla.Location = new System.Drawing.Point(240, 290);
            this.btnDescargarPlantilla.Name = "btnDescargarPlantilla";
            this.btnDescargarPlantilla.Size = new System.Drawing.Size(170, 30);
            this.btnDescargarPlantilla.TabIndex = 3;
            this.btnDescargarPlantilla.Text = "Descargar plantilla CSV";
            this.btnDescargarPlantilla.UseVisualStyleBackColor = true;
            this.btnDescargarPlantilla.Click += new System.EventHandler(this.btnDescargarPlantilla_Click);

            // 
            // btnImportarCSV
            // 
            this.btnImportarCSV.Location = new System.Drawing.Point(420, 290);
            this.btnImportarCSV.Name = "btnImportarCSV";
            this.btnImportarCSV.Size = new System.Drawing.Size(130, 30);
            this.btnImportarCSV.TabIndex = 4;
            this.btnImportarCSV.Text = "Importar CSV";
            this.btnImportarCSV.UseVisualStyleBackColor = true;
            this.btnImportarCSV.Click += new System.EventHandler(this.btnImportarCSV_Click);

            // 
            // EquiposKartingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImportarCSV);
            this.Controls.Add(this.btnDescargarPlantilla);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dataGridViewEquipos);
            this.Name = "EquiposKartingControl";
            this.Size = new System.Drawing.Size(650, 340);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipos)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
