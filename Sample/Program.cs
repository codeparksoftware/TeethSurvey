using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeetSurvey.Repository.Model;

namespace Sample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var action = new Action(CloseInitFormAmdOpenSelectionForm);
            var frm = new frmAdmin();
            Application.Run(frm);
        }

        static void CloseInitFormAmdOpenSelectionForm()
        {
            //Survey survey = null;
            //if(Application.OpenForms[0] is frmAdmin  ){
            //    survey = ((InitForm)Application.OpenForms[0]).Survey;
            //}
            //Application.OpenForms[0]?.Hide();
            //var select = new SelectForm(survey);
            //select.Text = survey.SurveyId+"";
            //    select.Show(); 
        }
    }
}
