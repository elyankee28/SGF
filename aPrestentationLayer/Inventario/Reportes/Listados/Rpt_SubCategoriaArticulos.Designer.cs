﻿namespace aPrestentationLayer.Inventario.Reportes.Listados
{
    partial class Rpt_SubCategoriaArticulos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sGFDataSet = new aPrestentationLayer.Inventario.SGFDataSet();
            this.subCategoriaArticulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subCategoriaArticulosTableAdapter = new aPrestentationLayer.Inventario.SGFDataSetTableAdapters.SubCategoriaArticulosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sGFDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoriaArticulosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.subCategoriaArticulosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "aPrestentationLayer.Inventario.Reportes.Listados.Rpt_SubCategoriaArticulos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(721, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // sGFDataSet
            // 
            this.sGFDataSet.DataSetName = "SGFDataSet";
            this.sGFDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // subCategoriaArticulosBindingSource
            // 
            this.subCategoriaArticulosBindingSource.DataMember = "SubCategoriaArticulos";
            this.subCategoriaArticulosBindingSource.DataSource = this.sGFDataSet;
            // 
            // subCategoriaArticulosTableAdapter
            // 
            this.subCategoriaArticulosTableAdapter.ClearBeforeFill = true;
            // 
            // Rpt_SubCategoriaArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 425);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Rpt_SubCategoriaArticulos";
            this.Text = "Rpt_SubCategoriaArticulos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Rpt_SubCategoriaArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sGFDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoriaArticulosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SGFDataSet sGFDataSet;
        private System.Windows.Forms.BindingSource subCategoriaArticulosBindingSource;
        private SGFDataSetTableAdapters.SubCategoriaArticulosTableAdapter subCategoriaArticulosTableAdapter;
    }
}