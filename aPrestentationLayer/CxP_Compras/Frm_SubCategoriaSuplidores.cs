﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using EntityLayer.CxP_Compras;
using BusinessLogicLayer.CxP_Compras;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;

namespace aPrestentationLayer.CxP_Compras
{
    public partial class Frm_SubCategoriaSuplidores : Frm_Plantilla
    {

        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores = new Enl_SubCategoriaSuplidores();
        Bll_SubCategoriaSuplidores bllSubCategoriaSuplidores = new Bll_SubCategoriaSuplidores();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_SubCategoriaSuplidores()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
           // btnBuscar.Click += btnBuscar_Click;
            btnVista.Click += btnVista_Click;
            DGV_SubCategoriaSuplidor.AutoGenerateColumns = false;

        }

  
        void btnNuevo_Click(object sender, EventArgs e)
        {
            //Estado = NUEVO;
            Estado = Helper.EstadoSystema.Creando;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

            }
            BotonNuevo();

            if (bllNumeracion.ObtenerTipo("SubCategoria de Suplidores") == "Automatico")
            {
                txtCodigo.ReadOnly = true;
                txtNombre.Focus();
            }
            else
            {
                txtCodigo.ReadOnly = false;
                txtCodigo.Focus();
            }

        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            enlSubCategoriaSuplidores.Codigo = txtCodigo.Text;
            enlSubCategoriaSuplidores.Nombre = txtNombre.Text;
            enlSubCategoriaSuplidores.Nota = txtNota.Text;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllSubCategoriaSuplidores.Insert(enlSubCategoriaSuplidores);

                if (bllNumeracion.ObtenerTipo("SubCategoria de Suplidores") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("SubCategoria de Suplidores"), "SubCategoria de Suplidores");
                }

            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllSubCategoriaSuplidores.Update(enlSubCategoriaSuplidores);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                }
            }

            BotonGuardar();
            ActualizarDGV = true;
        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_SubCategoriaSuplidor.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_SubCategoriaSuplidor[0, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_SubCategoriaSuplidor[1, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_SubCategoriaSuplidor[2, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                }
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {

                BotonEditar();
                Estado = Helper.EstadoSystema.Editando;
                txtNombre.Focus();
                txtCodigo.Enabled = false;

            }
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Estado == Helper.EstadoSystema.Creando)
            {
                AC.DeshabilitarText(this);
                AC.VaciarText(this);
            }

            if (Estado == Helper.EstadoSystema.Editando)
            {
                enlSubCategoriaSuplidores.Codigo = txtCodigo.Text;
                enlSubCategoriaSuplidores.Nombre = string.Empty;

                var list = bllSubCategoriaSuplidores.Search(enlSubCategoriaSuplidores);

                txtNombre.Text = list[0].Nombre;
                txtNota.Text = list[0].Nota;


            }

            BotonCancelar();

        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_SubCategoriaSuplidor.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_SubCategoriaSuplidor[0, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_SubCategoriaSuplidor[1, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_SubCategoriaSuplidor[2, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlSubCategoriaSuplidores.Codigo = txtCodigo.Text;
           
            if(bllSubCategoriaSuplidores.Delete(enlSubCategoriaSuplidores))
            {

            BotonEliminar();

            ActualizarDGV = true;
             }
        }


        private void Frm_SubCategoriaSuplidores_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlSubCategoriaSuplidores.Codigo = string.Empty;
            enlSubCategoriaSuplidores.Nombre = string.Empty;

            DGV_SubCategoriaSuplidor.DataSource = bllSubCategoriaSuplidores.Search(enlSubCategoriaSuplidores);

        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                enlSubCategoriaSuplidores.Codigo = string.Empty;
                enlSubCategoriaSuplidores.Nombre = string.Empty;

                DGV_SubCategoriaSuplidor.DataSource = bllSubCategoriaSuplidores.Search(enlSubCategoriaSuplidores);
                ActualizarDGV = false;
            }

            if (tabControl1.SelectedTab == tbpMaster)
            {
                tabControl1.TabPages.Remove(tbpMaster);
                tabControl1.TabPages.Add(tbpDetail);
                tabControl1.SelectTab(tbpDetail);
            }
            else
            {
                if (tabControl1.SelectedTab == tbpDetail)
                {
                    tabControl1.TabPages.Remove(tbpDetail);
                    tabControl1.TabPages.Add(tbpMaster);
                    tabControl1.SelectTab(tbpMaster);

                    if (DGV_SubCategoriaSuplidor.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_SubCategoriaSuplidor[0, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_SubCategoriaSuplidor[1, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_SubCategoriaSuplidor[2, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }


        }

        private void DGV_SubCategoriaSuplidor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Isuplidores frm = this.Owner as Isuplidores;
                if (frm != null)
                    frm.CargarSubCategoria(DGV_SubCategoriaSuplidor[0, DGV_SubCategoriaSuplidor.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
        }
 
    }
}
