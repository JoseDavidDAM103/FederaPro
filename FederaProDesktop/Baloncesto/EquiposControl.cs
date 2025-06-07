using FederaProDesktop.Modelos.DTO;
using FederaProDesktop.Servicios.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class EquiposControl : UserControl
    {
        public event Action<BasketEquipoDTO> VerDetalleEquipo;
        private readonly EquipoApiService _apiService = new EquipoApiService();
        public bool editar = false;

        public EquiposControl()
        {
            InitializeComponent();
            ConfigurarComponentes();
            InicializarColumnasAccion();
            _ = CargarEquiposAsync();
        }

        private void ConfigurarComponentes()
        {
            PrepararPlaceholder(txtNombre, "Nombre del equipo");
            PrepararPlaceholder(txtCiudad, "Ciudad");
        }

        private async Task CargarEquiposAsync()
        {
            try
            {
                dgvEquipos.DataSource = null;
                var equipos = await _apiService.GetEquiposAsync();
                dgvEquipos.DataSource = equipos;
                dgvEquipos.Columns["Id"].Visible = false;
                OcultarColumnasAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message);
            }
        }

        private void PrepararPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void InicializarColumnasAccion()
        {
            if (!dgvEquipos.Columns.Contains("btnGuardar"))
            {
                var btnGuardar = new DataGridViewButtonColumn
                {
                    Name = "btnGuardar",
                    HeaderText = "",
                    Text = "Guardar",
                    UseColumnTextForButtonValue = true,
                    Visible = false
                };
                dgvEquipos.Columns.Add(btnGuardar);
            }

            if (!dgvEquipos.Columns.Contains("btnCancelar"))
            {
                var btnCancelar = new DataGridViewButtonColumn
                {
                    Name = "btnCancelar",
                    HeaderText = "",
                    Text = "Cancelar",
                    UseColumnTextForButtonValue = true,
                    Visible = false
                };
                dgvEquipos.Columns.Add(btnCancelar);
            }
        }

        private void OcultarColumnasAccion()
        {
            this.editar = false;
            dgvEquipos.Columns["btnGuardar"].Visible = false;
            dgvEquipos.Columns["btnCancelar"].Visible = false;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.ForeColor == Color.Gray ? "" : txtNombre.Text.Trim();
            string ciudad = txtCiudad.ForeColor == Color.Gray ? "" : txtCiudad.Text.Trim();

            try
            {
                dgvEquipos.DataSource = null;
                var equipos = await _apiService.BuscarEquiposAsync(nombre, ciudad);
                dgvEquipos.DataSource = equipos;
                dgvEquipos.Columns["Id"].Visible = false;
                OcultarColumnasAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar equipos: " + ex.Message);
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            var equipos = dgvEquipos.DataSource as List<BasketEquipoDTO>;
            dgvEquipos.DataSource = null;

            var lista = equipos != null ? new List<BasketEquipoDTO>(equipos) : new List<BasketEquipoDTO>();

            lista.Add(new BasketEquipoDTO { Id = 0, Nombre = "", Ciudad = "" });

            this.editar = true;
            dgvEquipos.DataSource = lista;
            dgvEquipos.Columns["Id"].Visible = false;
            dgvEquipos.Columns["btnGuardar"].Visible = true;
            dgvEquipos.Columns["btnCancelar"].Visible = true;

            var nuevaFila = dgvEquipos.Rows[dgvEquipos.RowCount - 1];
            nuevaFila.ReadOnly = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para editar.");
                return;
            }

            var fila = dgvEquipos.SelectedRows[0];
            fila.ReadOnly = false;
            this.editar = true;
            dgvEquipos.Columns["btnGuardar"].Visible = true;
            dgvEquipos.Columns["btnCancelar"].Visible = true;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un equipo para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de que deseas eliminar este equipo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var fila = dgvEquipos.SelectedRows[0];
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                await _apiService.EliminarEquipoAsync(id);
                await CargarEquiposAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar equipo: " + ex.Message);
            }
        }

        private async void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columna = dgvEquipos.Columns[e.ColumnIndex];
            var fila = dgvEquipos.Rows[e.RowIndex];

            if (columna.Name == "btnGuardar")
            {
                string nombre = fila.Cells["Nombre"].Value?.ToString();
                string ciudad = fila.Cells["Ciudad"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ciudad))
                {
                    MessageBox.Show("Nombre y ciudad son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (fila.Cells["Id"].Value != null && Convert.ToInt32(fila.Cells["Id"].Value) != 0)
                    {
                        var equipo = new BasketEquipoDTO { Id = Convert.ToInt32(fila.Cells["Id"].Value), Nombre = nombre, Ciudad = ciudad };
                        await _apiService.ActualizarEquipoAsync(equipo.Id, equipo);
                    }
                    else
                    {
                        var equipo = new BasketEquipoDTO { Nombre = nombre, Ciudad = ciudad };
                        await _apiService.CrearEquipoAsync(equipo);
                    }

                    await CargarEquiposAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar equipo: " + ex.Message);
                }
            }
            else if (columna.Name == "btnCancelar")
            {
                if (fila.Cells["Id"].Value == null || Convert.ToInt32(fila.Cells["Id"].Value) == 0)
                    dgvEquipos.Rows.RemoveAt(e.RowIndex);
                else
                    await CargarEquiposAsync();
            }
        }


        private void dgvEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.editar == true) return;
            if (e.RowIndex >= 0)
            {
                var equipo = (BasketEquipoDTO)dgvEquipos.Rows[e.RowIndex].DataBoundItem;
                VerDetalleEquipo?.Invoke(equipo);
            }
        }
        private async void btnCSV_Click(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _apiService.CargarEquiposDesdeCSVAsync(openDialog.FileName);
                    MessageBox.Show("Equipos cargados correctamente.");
                    await CargarEquiposAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar CSV: " + ex.Message);
                }
            }
        }

        private async void btnDescargarCSV_Click(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "plantilla_equipos.csv"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _apiService.DescargarPlantillaCSVAsync(saveDialog.FileName);
                    MessageBox.Show("Plantilla descargada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al descargar plantilla: " + ex.Message);
                }
            }
        }
    }
}
