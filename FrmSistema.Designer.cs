namespace FinalLabPL2
{
    partial class FrmSistema
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDelProgramadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sociosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarSocioNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.buscarSocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeUnSocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.listadoDeTodosLosSociosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeSociosDeudoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeSociosDeUnaActividadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeSociosDeUnBarrioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.sociosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDelProgramadorToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // acercaDelProgramadorToolStripMenuItem
            // 
            this.acercaDelProgramadorToolStripMenuItem.Name = "acercaDelProgramadorToolStripMenuItem";
            this.acercaDelProgramadorToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.acercaDelProgramadorToolStripMenuItem.Text = "Acerca del Programador";
            this.acercaDelProgramadorToolStripMenuItem.Click += new System.EventHandler(this.acercaDelProgramadorToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // sociosToolStripMenuItem
            // 
            this.sociosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarSocioNuevoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.buscarSocioToolStripMenuItem,
            this.consultaDeUnSocioToolStripMenuItem,
            this.toolStripMenuItem2,
            this.listadoDeTodosLosSociosToolStripMenuItem,
            this.listadoDeSociosDeudoresToolStripMenuItem,
            this.listadoDeSociosDeUnaActividadToolStripMenuItem,
            this.listadoDeSociosDeUnBarrioToolStripMenuItem});
            this.sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            this.sociosToolStripMenuItem.Size = new System.Drawing.Size(80, 29);
            this.sociosToolStripMenuItem.Text = "Socios";
            // 
            // agregarSocioNuevoToolStripMenuItem
            // 
            this.agregarSocioNuevoToolStripMenuItem.Name = "agregarSocioNuevoToolStripMenuItem";
            this.agregarSocioNuevoToolStripMenuItem.Size = new System.Drawing.Size(386, 34);
            this.agregarSocioNuevoToolStripMenuItem.Text = "Agregar socio Nuevo";
            this.agregarSocioNuevoToolStripMenuItem.Click += new System.EventHandler(this.agregarSocioNuevoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(383, 6);
            // 
            // buscarSocioToolStripMenuItem
            // 
            this.buscarSocioToolStripMenuItem.Name = "buscarSocioToolStripMenuItem";
            this.buscarSocioToolStripMenuItem.Size = new System.Drawing.Size(386, 34);
            this.buscarSocioToolStripMenuItem.Text = "Buscar socio";
            this.buscarSocioToolStripMenuItem.Click += new System.EventHandler(this.buscarSocioToolStripMenuItem_Click);
            // 
            // consultaDeUnSocioToolStripMenuItem
            // 
            this.consultaDeUnSocioToolStripMenuItem.Name = "consultaDeUnSocioToolStripMenuItem";
            this.consultaDeUnSocioToolStripMenuItem.Size = new System.Drawing.Size(386, 34);
            this.consultaDeUnSocioToolStripMenuItem.Text = "Consulta de un socio";
            this.consultaDeUnSocioToolStripMenuItem.Click += new System.EventHandler(this.consultaDeUnSocioToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(383, 6);
            // 
            // listadoDeTodosLosSociosToolStripMenuItem
            // 
            this.listadoDeTodosLosSociosToolStripMenuItem.Name = "listadoDeTodosLosSociosToolStripMenuItem";
            this.listadoDeTodosLosSociosToolStripMenuItem.Size = new System.Drawing.Size(386, 34);
            this.listadoDeTodosLosSociosToolStripMenuItem.Text = "Listado de todos los socios";
            this.listadoDeTodosLosSociosToolStripMenuItem.Click += new System.EventHandler(this.listadoDeTodosLosSociosToolStripMenuItem_Click);
            // 
            // listadoDeSociosDeudoresToolStripMenuItem
            // 
            this.listadoDeSociosDeudoresToolStripMenuItem.Name = "listadoDeSociosDeudoresToolStripMenuItem";
            this.listadoDeSociosDeudoresToolStripMenuItem.Size = new System.Drawing.Size(386, 34);
            this.listadoDeSociosDeudoresToolStripMenuItem.Text = "Listado de socios deudores";
            this.listadoDeSociosDeudoresToolStripMenuItem.Click += new System.EventHandler(this.listadoDeSociosDeudoresToolStripMenuItem_Click);
            // 
            // listadoDeSociosDeUnaActividadToolStripMenuItem
            // 
            this.listadoDeSociosDeUnaActividadToolStripMenuItem.Name = "listadoDeSociosDeUnaActividadToolStripMenuItem";
            this.listadoDeSociosDeUnaActividadToolStripMenuItem.Size = new System.Drawing.Size(386, 34);
            this.listadoDeSociosDeUnaActividadToolStripMenuItem.Text = "Listado de socios de una actividad";
            this.listadoDeSociosDeUnaActividadToolStripMenuItem.Click += new System.EventHandler(this.listadoDeSociosDeUnaActividadToolStripMenuItem_Click);
            // 
            // listadoDeSociosDeUnBarrioToolStripMenuItem
            // 
            this.listadoDeSociosDeUnBarrioToolStripMenuItem.Name = "listadoDeSociosDeUnBarrioToolStripMenuItem";
            this.listadoDeSociosDeUnBarrioToolStripMenuItem.Size = new System.Drawing.Size(386, 34);
            this.listadoDeSociosDeUnBarrioToolStripMenuItem.Text = "Listado de socios de un barrio";
            this.listadoDeSociosDeUnBarrioToolStripMenuItem.Click += new System.EventHandler(this.listadoDeSociosDeUnBarrioToolStripMenuItem_Click);
            // 
            // FrmSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de gestion de clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDelProgramadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sociosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarSocioNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarSocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeUnSocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem listadoDeTodosLosSociosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeSociosDeudoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeSociosDeUnaActividadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeSociosDeUnBarrioToolStripMenuItem;
    }
}

