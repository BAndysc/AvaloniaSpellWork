using System;
using System.Reflection;
using System.Windows.Forms;
using SpellWork.ViewModels;

namespace SpellWork.Forms
{
    sealed partial class FormAboutBox : Form
    {
        public FormAboutBox()
        {
            var viewModel = new AboutBoxViewModel();
            InitializeComponent();
            Text = viewModel.Title;
            labelProductName.Text = viewModel.AssemblyProduct;
            labelVersion.Text = String.Format("Version {0} {0}", viewModel.AssemblyVersion);
            labelCopyright.Text = viewModel.AssemblyCopyright;
            labelCompanyName.Text = viewModel.AssemblyCompany;
            textBoxDescription.Text = viewModel.AssemblyDescription;
        }
    }
}
