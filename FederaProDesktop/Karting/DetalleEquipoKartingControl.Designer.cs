namespace FederaProDesktop.Karting
{
    partial class DetalleEquipoKartingControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Button btnDescargarPlantillaPilotos;
        private System.Windows.Forms.Button btnImportarPilotos;

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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.btnDescargarPlantillaPilotos = new System.Windows.Forms.Button();
            this.btnImportarPilotos = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(179, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle Equipo";

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(22, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(100, 77);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(250, 22);
            this.txtNombre.TabIndex = 2;

            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(22, 120);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(37, 17);
            this.lblPais.TabIndex = 3;
            this.lblPais.Text = "País:";

            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(100, 117);
            this.txtPais.Name = "txtPais";
            this.txtPais.ReadOnly = true;
            this.txtPais.Size = new System.Drawing.Size(250, 22);
            this.txtPais.TabIndex = 4;

            // 
            // btnDescargarPlantillaPilotos
            // 
            this.btnDescargarPlantillaPilotos.Location = new System.Drawing.Point(25, 160);
            this.btnDescargarPlantillaPilotos.Name = "btnDescargarPlantillaPilotos";
            this.btnDescargarPlantillaPilotos.Size = new System.Drawing.Size(160, 30);
            this.btnDescargarPlantillaPilotos.TabIndex = 5;
            this.btnDescargarPlantillaPilotos.Text = "Descargar plantilla";
            this.btnDescargarPlantillaPilotos.UseVisualStyleBackColor = true;
            // 
            // btnImportarPilotos
            // 
            this.btnImportarPilotos.Location = new System.Drawing.Point(200, 160);
            this.btnImportarPilotos.Name = "btnImportarPilotos";
            this.btnImportarPilotos.Size = new System.Drawing.Size(150, 30);
            this.btnImportarPilotos.TabIndex = 6;
            this.btnImportarPilotos.Text = "Importar CSV";
            this.btnImportarPilotos.UseVisualStyleBackColor = true;

            // 
            // DetalleEquipoKartingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImportarPilotos);
            this.Controls.Add(this.btnDescargarPlantillaPilotos);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "DetalleEquipoKartingControl";
            this.Size = new System.Drawing.Size(400, 220);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}