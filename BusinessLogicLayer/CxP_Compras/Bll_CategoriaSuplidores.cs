﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.CxP_Compras;
using DataAccessLayer.CxC_Compras;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.CxP_Compras
{
  public  class Bll_CategoriaSuplidores
    {

        Dal_CategoriaSuplidores dalCategoriaSuplidores = new Dal_CategoriaSuplidores();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_CategoriaSuplidores enlCategoriaSuplidores)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Categoria de Suplidores") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Categoria de Suplidores")))
                {
                    enlCategoriaSuplidores.Codigo = dalNumeracion.ObtenerPrefijo("Categoria de Suplidores") + dalNumeracion.ObtenerNumero("Categoria de Suplidores").ToString("00000000");
                }
                else
                {
                    enlCategoriaSuplidores.Codigo = dalNumeracion.ObtenerNumero("Categoria de Suplidores").ToString("00000000");
                }

            }

            if (dalCategoriaSuplidores.Search(enlCategoriaSuplidores).Count == 0)
            {
                dalCategoriaSuplidores.Insert(enlCategoriaSuplidores);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");
            
            }
            return enlCategoriaSuplidores.Codigo;

        }

        public void Update(Enl_CategoriaSuplidores enlCategoriaSuplidores)
        {

            //Validaciones De Lugar

            dalCategoriaSuplidores.Update(enlCategoriaSuplidores);

        }

        public bool  Delete(Enl_CategoriaSuplidores enlCategoriaSuplidores)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlCategoriaSuplidores.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalCategoriaSuplidores.Delete(enlCategoriaSuplidores);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                    return true;
                }
            }
            return false;
        }

        public IList<Enl_CategoriaSuplidores> Search(Enl_CategoriaSuplidores enlCategoriaSuplidores)
        {

            //Validaciones de Lugar

            var ListaCategoriaSuplidores = dalCategoriaSuplidores.Search(enlCategoriaSuplidores);

            if (ListaCategoriaSuplidores.Count != 0)
            {

                return ListaCategoriaSuplidores;

            }
            else
            {
                return null;


            }

        }
    }
}
