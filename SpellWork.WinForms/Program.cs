﻿using SpellWork.Forms;
using SpellWork.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpellWork.Services;
using SpellWork.ViewModels;

namespace SpellWork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Globals.FileSystem = new LocalFileSystem();
            Globals.MessageBoxService = new WinFormsMessageBoxService();

            /*var dbcPath = $"{Settings.Default.DbcPath}\\{Settings.Default.Locale}";
            if (!Directory.Exists(dbcPath))
            {
                MessageBox.Show($"Files in {Path.GetFullPath(dbcPath)} missing", @"Missing files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            try
            {
                var mainForm = new FormMain();
                Task.Run(async () =>
                {
                    try
                    {
                        await DBC.DBC.Load(progress =>
                        {
                            if (mainForm.InvokeRequired)
                                mainForm.Invoke(new Action(() => mainForm.SetLoadingProgress(progress)));
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while loading DBC: " + ex.Message);
                    }
                    finally
                    {
                        if (mainForm.InvokeRequired)
                            mainForm.Invoke(new Action(() => mainForm.Unblock()));
                        else
                            mainForm.Unblock();
                    }
                });
                Application.Run(mainForm);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show(dnfe.Message, @"Missing required DBC file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, @"DBC file has wrong structure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"SpellWork Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
