using Scoala.Models.BusinessLogic;
using Scoala.Models.EntityLayer;
using Scoala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Scoala.ViewModels
{
    class ElevwVM : BasePropertyChanged
    {
        public static User CurrentUser { get; set; } = Functions.Help_Funct.CurrentUser;
        public static List<string> UserChoices { get; set; } = new List<string> { "Absente", "Note", "Media", "Material" };

        public static ObservableCollection<string> Semesters { get; set; } = new ObservableCollection<string> { "Semestrul 1", "Semestrul 2"};

        MaterieBLL objBLL = new MaterieBLL();

        AbsentaBLL absBLL = new AbsentaBLL();

        NotaBLL notBLL = new NotaBLL();

        Elev_Nota_AbsBLL enaBLL = new Elev_Nota_AbsBLL();

        public ElevwVM()
        {
            ObjList = objBLL.GetAllSubjFromStudent(Functions.Help_Funct.CurrentUser.IDUser);
            MissList = null;
        }
        public ObservableCollection<Materie> ObjList
        {
            get
            {
                return objBLL.StudentObjList;
            }
            set
            {
                objBLL.StudentObjList = value;
            }
        }

        public ObservableCollection<Absenta> MissList
        {
            get
            {
                return absBLL.StudentAbsList;
            }
            set
            {
                absBLL.StudentAbsList = value;
                NotifyPropertyChanged("MissList");
            }
        }

        public ObservableCollection<Nota> MarkList
        {
            get
            {
                return notBLL.StudentNotaList;
            }
            set
            {
                notBLL.StudentNotaList = value;
                NotifyPropertyChanged(" MarkList");
            }
        }

        public ObservableCollection<Elev_Nota_Abs> Elev_Nota_AbsList
        {
            get
            {
                return enaBLL.Elev_Nota_List;
            }
            set
            {
                enaBLL.Elev_Nota_List = value;
                NotifyPropertyChanged("Elev_Nota_AbsList");
            }
        }

        private Materie selectedMat;
        public Materie SelectedMat
        {
            get { return selectedMat; }
            set
            {
                selectedMat = value;
                NotifyPropertyChanged("SelectedMat");
            }
        }

        private string selectedChoice;
        public string SelectedChoice
        {
            get { return selectedChoice; }
            set
            {
                selectedChoice = value;
                Functions.Help_Funct.SelectedChoice = selectedChoice;
                if (selectedChoice == "Media")
                    Semesters.Add("General");
                else
                { if(Semesters.Count>2)
                        if (Semesters.ElementAt(2) == "General")
                            Semesters.RemoveAt(2);
                }
                
                NotifyPropertyChanged("SelectedChoice");
            }
        }

        private string selectedSem;
        public string SelectedSem
        {
            get { return selectedSem; }
            set
            {
                selectedSem = value;
                Functions.Help_Funct.SelectedSem = selectedSem;
                NotifyPropertyChanged("SelectedSem");
            }
        }

        private ICommand vizCommand;
        public ICommand VizCommand
        {
            get
            {
                if (vizCommand == null)
                {
                    vizCommand = new RelayCommand<Materie>(See);
                }
               
                return vizCommand;
            }
        }

        public Elev_Nota_Abs MedieMat(string sem,Materie this_mat)
        {
            double general = 0;           
            MarkList = notBLL.GetObjMarkFromStudent(Functions.Help_Funct.CurrentUser.IDUser, this_mat.IdMaterie);
            int mark = 0;
            int t = 0;
            foreach (Nota a in MarkList)
                if (a.Semestru == sem)
                {
                    if (a.E_teza == "Teza")
                        t = Convert.ToInt32(a.Nota_str);
                    else
                        mark += Convert.ToInt32(a.Nota_str);
                }
            if (mark == 0&& t==0)
                return new Elev_Nota_Abs("Nu sunt note", "", "");
            else
            {
                if (t == 0)
                    general += Math.Round((float)mark / MarkList.Count);
                else
                {
                    mark /= (MarkList.Count - 1);
                    mark *= 3;
                    mark += t;
                    general += Math.Round(mark / 4.0);
                }  
                return new Elev_Nota_Abs(" Media pe semestru", Math.Round(general).ToString(), "");
            }
        }

        public void See(Materie this_mat)
        {
            if (Functions.Help_Funct.SelectedChoice == "Absente")
            {

                Elev_Nota_AbsList = new ObservableCollection<Elev_Nota_Abs>();
                if (this_mat.Nume == "Toate")
                {
                    MissList = absBLL.GetAllMissFromStudent(Functions.Help_Funct.CurrentUser.IDUser);
                    foreach (Absenta a in MissList )
                    {
                        if(a.Semestru==SelectedSem)
                        Elev_Nota_AbsList.Add(new Elev_Nota_Abs(a.Nume, a.E_motiv, a.Data));
                    }
                }
                else
                {
                    if (Elev_Nota_AbsList != null)
                        Elev_Nota_AbsList.Clear();
                    MissList = absBLL.GetAllMissFromStudent(Functions.Help_Funct.CurrentUser.IDUser);
                    foreach (Absenta a in MissList)
                    {
                        if (a.Semestru == SelectedSem)
                            if (a.Nume == this_mat.Nume)
                            Elev_Nota_AbsList.Add(new Elev_Nota_Abs(a.Nume, a.E_motiv, a.Data));
                    }
                    if (Elev_Nota_AbsList.Count < 1)
                        Elev_Nota_AbsList.Add(new Elev_Nota_Abs("Nu sunt absente", "", ""));
                };
            }

            else if (Functions.Help_Funct.SelectedChoice == "Note")
            {
                Elev_Nota_AbsList = new ObservableCollection<Elev_Nota_Abs>();

                if (this_mat.Nume == "Toate")
                {
                    MarkList = notBLL.GetAllMarkFromStudent(Functions.Help_Funct.CurrentUser.IDUser);
                    foreach (Nota a in MarkList)
                        if (a.Semestru == SelectedSem)
                        {
                        var n = (a.E_teza == "Teza") ? "E teza " : "";
                        Elev_Nota_AbsList.Add(new Elev_Nota_Abs(a.Nume, n+ a.Nota_str, a.Data));
                    }
                    
                }
                else
                {
                    if (Elev_Nota_AbsList != null)
                        Elev_Nota_AbsList.Clear();
                    MarkList = notBLL.GetAllMarkFromStudent(Functions.Help_Funct.CurrentUser.IDUser);
                    foreach (Nota a in MarkList)
                        if (a.Semestru == SelectedSem)
                        {
                        var n = (a.E_teza == "Teza") ? "E teza " : "";
                        if (a.Nume == this_mat.Nume)
                            Elev_Nota_AbsList.Add(new Elev_Nota_Abs(a.Nume, n+a.Nota_str, a.Data));
                    }
                    if(Elev_Nota_AbsList.Count<1)
                        Elev_Nota_AbsList.Add(new Elev_Nota_Abs("Nu sunt note", "", ""));
                };
            }
            
            else if (Functions.Help_Funct.SelectedChoice == "Media")
            { 
                Elev_Nota_AbsList = new ObservableCollection<Elev_Nota_Abs>();
                
                if ("General" == SelectedSem)
                {

                    if (this_mat.Nume != "Toate")
                    {
                        float med = 0;
                        Elev_Nota_Abs aux = new Elev_Nota_Abs();
                        foreach (var se in new List<string>() { "Semestrul 1", "Semestrul 2" })
                        {
                            aux = MedieMat(se, this_mat);
                            if (aux.Data != "")
                            {
                                med += Convert.ToInt32(aux.Data);
                            }
                            Elev_Nota_AbsList.Clear();
                            Elev_Nota_AbsList.Add(MedieMat(se, this_mat));
                        }
                        Elev_Nota_AbsList[0].Data = Math.Round(med/2).ToString();

                    }
                    else
                    {
                        {
                            int k = 0;
                            float med = 0;
                            float gen = 0;
                            Elev_Nota_Abs aux = new Elev_Nota_Abs();
                            foreach (var se in new List<string>() { "Semestrul 1", "Semestrul 2" })
                            {
                                k = 0;
                                med = 0;
                                foreach (var i in ObjList) if (i.Nume != "Toate")
                                    {
                                        aux = MedieMat(se, i);
                                        k++;
                                        if (aux.Data != "")
                                        {
                                            med += Convert.ToInt32(aux.Data);
                                            Elev_Nota_AbsList.Add(aux);
                                        }
                                    }
                                Elev_Nota_AbsList.Clear();
                                gen += med / k;
                            }
                            Elev_Nota_AbsList.Add(new Elev_Nota_Abs(" Media generala", Math.Round(gen/2).ToString(), ""));
                        }
                    }
                }
                else
                {
                    if (this_mat.Nume != "Toate")
                    {
                        Elev_Nota_AbsList.Clear();
                        Elev_Nota_AbsList.Add(MedieMat(SelectedSem, this_mat));
                    }
                    else
                    {
                        {
                            int k = 0;
                            float med = 0;
                            Elev_Nota_Abs aux = new Elev_Nota_Abs();
                                foreach (var i in ObjList) if (i.Nume != "Toate")
                                {
                                    aux = MedieMat(SelectedSem, i);
                                k++;
                                if (aux.Data != "")
                                    {
                                    med += Convert.ToInt32(aux.Data);
                                        Elev_Nota_AbsList.Add(aux);
                                    }
                                }
                            Elev_Nota_AbsList.Clear();
                            if(k==0 & med==0)
                                Elev_Nota_AbsList.Add(new Elev_Nota_Abs(" Media generala", "Nu sunt note", ""));
                            else
                            Elev_Nota_AbsList.Add(new Elev_Nota_Abs(" Media generala", Math.Round(med / k).ToString(), ""));
                        }
                    };
                }
            }
                ;
            
        }
    }
}
