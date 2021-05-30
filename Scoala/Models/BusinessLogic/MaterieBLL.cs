using Scoala.Models.DataLayer;
using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scoala.Models.BusinessLogic
{
    class MaterieBLL
    {

        MaterieDAL matDAL = new MaterieDAL();
        public ObservableCollection<Materie> GetAllSubjFromStudent(int ?smt)
        {
            return matDAL.GetAllSubjFromStudent(smt);
        }

        public ObservableCollection<Materie> MateriList { get; set; }

        public ObservableCollection<Materie> MateriAnSpecList { get; set; }
        public ObservableCollection<Materie> GetAllMaterii()
        {
            return matDAL.GetAllMaterii();
        }

        public ObservableCollection<Materie> GetAllMateriiAnSpec()
        {
            return matDAL.GetAllMateriiAnSpec();
        }
        public ObservableCollection<Materie> StudentObjList { get; set; }
        public void AddMat(string mat)
        {
            MaterieDAL mateDAL = new MaterieDAL();
            mateDAL.AddMat(mat);
            
        }

        public void DeleteMat(Materie mat)
        {
            MaterieDAL mateDAL = new MaterieDAL();
            mateDAL.DeleteMaterie(mat);
            MateriList.Remove(mat);

        }
        public void ModifyMat(Materie mat)
        {

            MaterieDAL materieDAL = new MaterieDAL();
            materieDAL.ModifMat(mat);
        }

        public void Cuplaj(Materie mat)
        {
            int k = 0;
            foreach (var m in MateriAnSpecList)
                if (m.IdMaterie == mat.IdMaterie)
                    k++;
            if (k == 0)
            {
                matDAL.Cuplaj(mat);
                MateriAnSpecList.Add(mat);
            }
            else MessageBox.Show("Materia e deja");
       
        }
    }
}
