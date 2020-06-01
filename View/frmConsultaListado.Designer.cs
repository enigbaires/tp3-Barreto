namespace View
{
    partial class frmConsultaListado
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
            this.dgvConsultaListado = new System.Windows.Forms.DataGridView();
            this.btnConsultaDetalle = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsultaListado
            // 
            this.dgvConsultaListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConsultaListado.Location = new System.Drawing.Point(12, 61);
            this.dgvConsultaListado.MultiSelect = false;
            this.dgvConsultaListado.Name = "dgvConsultaListado";
            this.dgvConsultaListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaListado.Size = new System.Drawing.Size(728, 318);
            this.dgvConsultaListado.TabIndex = 2;
            // 
            // btnConsultaDetalle
            // 
            this.btnConsultaDetalle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaDetalle.Location = new System.Drawing.Point(479, 12);
            this.btnConsultaDetalle.Name = "btnConsultaDetalle";
            this.btnConsultaDetalle.Size = new System.Drawing.Size(93, 34);
            this.btnConsultaDetalle.TabIndex = 3;
            this.btnConsultaDetalle.Text = "Detalle";
            this.btnConsultaDetalle.UseVisualStyleBackColor = true;
            this.btnConsultaDetalle.Click += new System.EventHandler(this.btnConsultaDetalle_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(662, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 34);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(578, 12);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(78, 34);
            this.btnAtras.TabIndex = 24;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmConsultaListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 391);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConsultaDetalle);
            this.Controls.Add(this.dgvConsultaListado);
            this.MinimumSize = new System.Drawing.Size(768, 430);
            this.Name = "frmConsultaListado";
            this.Text = "Gestión Artículos -Consulta - Listado";
            this.Load += new System.EventHandler(this.frmConsultaListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConsultaDetalle;
        public System.Windows.Forms.DataGridView dgvConsultaListado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAtras;
    }
}